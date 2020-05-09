import { Component, OnInit } from '@angular/core';
import { AppPostService } from 'src/app/services/post.service';
import { BehaviorSubject } from 'rxjs';
import { debounceTime, filter } from 'rxjs/operators';
import { Coordinate, MarkerWithPosts } from 'src/typing';
import { GoogleapiService } from 'src/app/services/googleapi.service';

@Component({
  selector: 'app-map-view',
  templateUrl: './map-view.component.html',
  styleUrls: ['./map-view.component.scss']
})
export class MapViewComponent implements OnInit {

  public selectedMarker: Marker | null = null;
  public markersOnMap: MarkerWithPosts[] = [];
  public initialPlace!: Marker;

  public mapCenter$ = new BehaviorSubject<Coordinate>({ latitude: 0, longitude: 0});
  public mapZoom$ = new BehaviorSubject<number>(10);

  public recommendations: any[] = [];

  constructor(private readonly postService: AppPostService, private readonly googleApiService: GoogleapiService) { }

  ngOnInit() {
    this.setCurrentPosition();

    this.mapCenter$.pipe(
      filter(c => !!c),
      debounceTime(1200)
    ).subscribe((center: Coordinate) => {
      this.postService.getMarkersWithPostsInRadius(center, 5.0).subscribe(response => {
        this.markersOnMap = response;
        const selectedMarker = this.markersOnMap.find(m => m.id === this.selectedMarker!.id);

        if (selectedMarker) {
          this.selectedMarker = selectedMarker;
        }
      });
    });
  }

  public handleMarkerSelect(marker: Marker): void {
    this.selectedMarker = marker;
  }

  public handleCenterChange(coordinate: Coordinate): void {
    this.mapCenter$.next(coordinate);
  }

  public handleZoomChange(zoom: number): void {
    this.mapZoom$.next(zoom);
  }

  public handleSendPost({ message, location, tags, recommended }: {message: string, location: string, tags: string[], recommended: boolean}): void {
    if(!this.selectedMarker) {
      return;
    }

    const post = { message, location, tags, marker: this.selectedMarker, id: 0, recommended };
    this.postService.add(post).subscribe(markers => {
      this.selectedMarker = markers[0];
      this.markersOnMap = [...this.markersOnMap, ...markers];
    });
  }

  public handleDeletePost(post: any): void {
    this.postService.deletePost(post.id)
      .subscribe(_ => {
        this.markersOnMap.forEach(m => m.posts = m.posts.filter(p => p.id !== post.id));
        this.markersOnMap = this.markersOnMap.filter(m => m.posts.length);
      });
  }

  public handleToggleLikePost(post: any): void {
    this.postService.toggleLike(post.id)
      .subscribe(timesLiked => 
        this.markersOnMap.forEach(m => m.posts = m.posts.map(p => {
          if (p.id === post.id) {
            p.liked = !p.liked;
            p.timesLiked = timesLiked;
          }

          return p;
        })))
  }

  public getRecommendations(): void {
    this.googleApiService.placesNearPlaces(this.mapCenter$.value.latitude, this.mapCenter$.value.longitude)
      .subscribe(places => {
        const filteredValues = places.filter((p: any) => p.types.some((t: string) => p.photos && relaxTypes.indexOf(t) != -1)).slice(0, 3);
        this.recommendations = filteredValues
          .map(p => ({
            name: p.name,
            photoLink: this.googleApiService.getPhotoLinkByReference(p.photos[0].photo_reference),
            address: p.vicinity,
            type: this.translate(p.types.find((t: string) => relaxTypes.indexOf(t) != -1)),
            location: { 
              latitude: p.geometry.location.lat, 
              longitude: p.geometry.location.lng
            },
            distance: p.geometry.location // meters
          }));

      });
  }

  public selectRecommendation(recommendation: any): void {
    this.mapCenter$.next(recommendation.location);
    this.selectedMarker = recommendation.location;
    this.initialPlace = recommendation.location;
  }

  private setCurrentPosition(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(position => {
        const { latitude, longitude } = position.coords
        this.initialPlace = position.coords;
        
        this.handleMarkerSelect({ latitude, longitude } as Marker);
        this.mapCenter$.next({latitude, longitude});
      });

    } else {
      // AppModalService
      alert("Geolocation is not supported by this browser, please use google chrome.");
    }
  }

  private translate(key: string): string {
    return translations[key];
  }

}

const translations: {
  [key: string]: string,
 } = {
  amusement_park: '',
  aquarium: '',
  art_gallery: '',
  bakery: '',
  bar: '',
  bicycle_store: '',
  book_store: '',
  bowling_alley: '',
  cafe: '',
  campground: '',
  casino: '',
  city_hall: '',
  clothing_store: '',
  convenience_store: '',
  department_store: '',
  electronics_store: '',
  florist: '',
  furniture_store: '',
  grocery_or_supermarket: '',
  gym: '',
  hardware_store: '',
  hindu_temple: '',
  home_goods_store: '',
  jewelry_store: '',
  library: '',
  light_rail_station: '',
  liquor_store: '',
  lodging: '',
  meal_delivery: '',
  meal_takeaway: '',
  mosque: '',
  movie_rental: '',
  movie_theater: '',
  moving_company: '',
  museum: '',
  night_club: '',
  painter: '',
  park: '',
  pet_store: '',
  restaurant: '',
  roofing_contractor: '',
  rv_park: '',
  shoe_store: '',
  shopping_mall: '',
  spa: '',
  stadium: '',
  supermarket: '',
  synagogue: '',
  tourist_attraction: '',
  zoo: '',  
};

const relaxTypes = Object.keys(translations);

import { Component, OnInit } from '@angular/core';
import { AppPostService } from 'src/app/services/post.service';
import { BehaviorSubject } from 'rxjs';
import { debounceTime, filter } from 'rxjs/operators';
import { Coordinate, MarkerWithPosts, TagModel } from 'src/typing';
import { GoogleapiService } from 'src/app/services/googleapi.service';
import { RecommendationService } from 'src/app/services/recommendation.service';

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
  public isRecommendationsLoad = false;

  public tags: TagModel[] = [];
  public selectedTags: TagModel[] = [];

  constructor(
    private readonly postService: AppPostService,
    private readonly googleApiService: GoogleapiService,
    private readonly recommendationService: RecommendationService) { }

  ngOnInit() {
    this.setCurrentPosition();

    this.mapCenter$.pipe(
      filter(c => !!c),
      debounceTime(1200)
    ).subscribe((center: Coordinate) => {
      this.postService.getMarkersWithPostsInRadius(center).subscribe(response => {
        if (this.selectedTags.length > 0) {
          response.forEach(m => m.posts = m.posts.filter(p => this.selectedTags.some(t => p.tags.indexOf(t.tag) != -1)));
          response = response.filter(m => m.posts.length > 0);
        }
        
        this.markersOnMap = response;
        const selectedMarker = this.markersOnMap.find(m => m.id === this.selectedMarker!.id);

        if (selectedMarker) {
          this.selectedMarker = selectedMarker;
        }
      });
    });

    this.recommendationService.getUserPreferredTypes();
    this.postService.getTags().subscribe(t => this.tags = t);
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

  public handleSelectedTagsChange(tags: TagModel[]): void {
    this.markersOnMap = [];
    this.selectedTags = tags;
    this.mapCenter$.next(this.mapCenter$.value);
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
    this.isRecommendationsLoad = true;
    this.recommendations = [];

    this.googleApiService.placesNearPlaces(this.mapCenter$.value.latitude, this.mapCenter$.value.longitude)
      .subscribe(places => {
        const filteredValues = places.filter((p: any) => p.types.some((t: string) => p.photos && relaxTypes.indexOf(t) != -1))
          .map(p => ({
            name: p.name,
            photoLink: this.googleApiService.getPhotoLinkByReference(p.photos[0].photo_reference),
            address: p.vicinity,
            type: this.translate(p.types.find((t: string) => relaxTypes.indexOf(t) != -1)),
            location: { 
              latitude: p.geometry.location.lat, 
              longitude: p.geometry.location.lng
            },
            distance: Math.round(this.distance(
              p.geometry.location.lat,
              p.geometry.location.lng,
              this.mapCenter$.value.latitude,
              this.mapCenter$.value.longitude
            ))
          }));

        // popular places will be placed in the end
        filteredValues.sort((place1, place2) => {
          return this.recommendationService.preferredTypes$.value.indexOf(place2.type) - this.recommendationService.preferredTypes$.value.indexOf(place1.type);
        });
        filteredValues.reverse();

        this.recommendations = filteredValues.slice(0, 3);
        this.isRecommendationsLoad = false;
      });
  }

  public selectRecommendation(recommendation: any): void {
    this.mapCenter$.next(recommendation.location);
    this.selectedMarker = recommendation.location;
    this.initialPlace = recommendation.location;

    this.recommendationService.selectRecommendation(recommendation.type).subscribe();
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

  private distance(lat1: number, lon1: number, lat2: number, lon2: number): number
  {
    const R = 6371e3; // metres
    const φ1 = lat1 * Math.PI/180; // φ, λ in radians
    const φ2 = lat2 * Math.PI/180;
    const Δφ = (lat2-lat1) * Math.PI/180;
    const Δλ = (lon2-lon1) * Math.PI/180;

    const a = Math.sin(Δφ/2) * Math.sin(Δφ/2) +
              Math.cos(φ1) * Math.cos(φ2) *
              Math.sin(Δλ/2) * Math.sin(Δλ/2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));

    return R * c; // in metres
  }

}

const translations: {
  [key: string]: string,
 } = {
  amusement_park: 'парк',
  aquarium: 'акваріум',
  art_gallery: 'галерея',
  bakery: 'пекарня',
  bar: 'бар',
  book_store: 'книжний',
  bowling_alley: 'боулінг',
  cafe: 'кафе',
  campground: 'кемпінг',
  casino: 'казино',
  city_hall: 'ратуша',
  clothing_store: 'одяг',
  florist: 'квіти',
  gym: 'спортзал',
  hindu_temple: 'храм',
  home_goods_store: 'затишок',
  library: 'бібліотека',
  liquor_store: 'алкоголь',
  meal_delivery: 'їжа',
  meal_takeaway: 'їжа',
  mosque: 'мечеть',
  movie_rental: 'кіно',
  movie_theater: 'театр',
  moving_company: 'кіно',
  museum: 'музей',
  night_club: 'клуб',
  painter: 'мистецтво',
  park: 'парк',
  pet_store: 'зоомагазин',
  restaurant: 'ресторан',
  rv_park: 'парк',
  shoe_store: 'взуття',
  shopping_mall: 'трц',
  spa: 'спа',
  stadium: 'стадіон',
  //supermarket: 'супермаркет',
  synagogue: 'синагога',
  tourist_attraction: 'пам\'ятка',
  zoo: 'зоопарк',  
};

const relaxTypes = Object.keys(translations);

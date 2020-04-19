import { Component, OnInit } from '@angular/core';
import { AppPostService } from 'src/app/services/post.service';
import { BehaviorSubject } from 'rxjs';
import { debounceTime, filter } from 'rxjs/operators';
import { Coordinate, MarkerWithPosts } from 'src/typing';

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

  constructor(private readonly postService: AppPostService) { }

  ngOnInit() {
    this.setCurrentPosition();

    this.mapCenter$.pipe(
      filter(c => !!c),
      debounceTime(400)
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

  public handleSendPost({ message, location }: {message: string, location: string}): void {
    if(!this.selectedMarker) {
      return;
    }

    const post = { message, location, marker: this.selectedMarker, id: 0 };
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

}

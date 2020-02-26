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
      });
    });
  }

  public handleMarkerSelect(marker: Marker): void {
    this.selectedMarker = marker;
    console.log('mam', marker);
       
  }

  public handleCenterChange(coordinate: Coordinate): void {
    this.mapCenter$.next(coordinate);
  }

  public handleZoomChange(zoom: number): void {
    this.mapZoom$.next(zoom);
  }

  public handleSendPost(message: string): void {
    if(!this.selectedMarker) {
      return;
    }

    const post = { message, marker: this.selectedMarker, id: 0 };
    this.postService.add(post).subscribe(markers => {
      this.selectedMarker = markers[0];
      this.markersOnMap = [...this.markersOnMap, ...markers];
    });
  }

  private setCurrentPosition(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(position => {
        const { latitude, longitude } = position.coords
        this.initialPlace = position.coords;
        this.handleMarkerSelect({ latitude, longitude });
        this.mapCenter$.next({latitude, longitude});
      });

    } else {
      // AppModalService
      alert("Geolocation is not supported by this browser, please use google chrome.");
    }
  }

}

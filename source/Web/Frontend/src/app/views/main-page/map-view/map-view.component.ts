import { Component, OnInit } from '@angular/core';
import { AppPostService } from 'src/app/services/post.service';
import { BehaviorSubject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-map-view',
  templateUrl: './map-view.component.html',
  styleUrls: ['./map-view.component.scss']
})
export class MapViewComponent implements OnInit {

  public selectedMarker: Marker | null = null;
  public markersOnMap: MarkerWithPosts[] = [];

  public mapCenter$ = new BehaviorSubject<Coordinate>(null);
  public mapZoom$ = new BehaviorSubject<number>(10);

  constructor(private readonly postService: AppPostService) { }

  ngOnInit() {
    this.mapCenter$.pipe(
      debounceTime(400)
    ).subscribe((center: Coordinate) => {
      this.postService.getMarkersWithPostsInRadius(center, 5.0).subscribe(response => {
        this.markersOnMap = response;
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

  public handleSendPost(message: string): void {
    if(!this.selectedMarker) {
      return;
    }

    const post = { message, marker: this.selectedMarker, id: 0 };
    this.postService.add(post).subscribe(id => post.id = id);
  }

}

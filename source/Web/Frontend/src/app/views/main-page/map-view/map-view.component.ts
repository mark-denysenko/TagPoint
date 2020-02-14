import { Component, OnInit } from '@angular/core';
import { AppPostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-map-view',
  templateUrl: './map-view.component.html',
  styleUrls: ['./map-view.component.scss']
})
export class MapViewComponent implements OnInit {

  public selectedMarker: Marker = {latitude: 0, longitude: 0};

  constructor(private readonly postService: AppPostService) { }

  ngOnInit() {
  }

  public handleMarkerSelect(marker: Marker): void {
    this.selectedMarker = marker;
  }

  public handleSendPost(message: string): void {
    const post = { message, marker: this.selectedMarker, id: 0 };
    this.postService.add(post).subscribe(id => post.id = id);
  }

}

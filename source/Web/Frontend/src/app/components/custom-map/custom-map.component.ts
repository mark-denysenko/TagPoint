import { Component, OnInit } from '@angular/core';

interface Marker {
  latitude: number;
  longitude: number;
}

@Component({
  selector: 'app-custom-map',
  templateUrl: './custom-map.component.html',
  styleUrls: ['./custom-map.component.scss']
})
export class CustomMapComponent implements OnInit {
  public initialPlace?: Marker;
  public currentMarker?: Marker;
  public markers: Marker[] = [];

  constructor() { }

  ngOnInit() {
    this.initialPlace = {
      latitude: 50.4547,
      longitude: 30.5238
    };

    this.currentMarker = this.initialPlace;
    this.markers = [this.initialPlace];
  }

  public handleMapClick(event: any): void {
    this.currentMarker = {
      latitude: event.coords.lat,
      longitude: event.coords.lng
    };
    console.log('event click', event);
    
  }

}

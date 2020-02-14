import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AgmInfoWindow } from '@agm/core';

@Component({
  selector: 'app-custom-map',
  templateUrl: './custom-map.component.html',
  styleUrls: ['./custom-map.component.scss']
})
export class CustomMapComponent implements OnInit {
  public initialPlace?: Marker;
  public currentMarker?: Marker;
  @Input() public markers: Marker[] = [];

  @Output() public selectMarker = new EventEmitter<Marker>();

  private currentIW: AgmInfoWindow | null = null;
  private previousIW: AgmInfoWindow | null = null;

  constructor() { }

  ngOnInit() {
    this.setCurrentPosition();
  }

  public handleMapClick(event: any): void {
    console.log('event click', event);
    this.currentMarker = {
      latitude: event.coords.lat,
      longitude: event.coords.lng
    };
    
    if (this.currentIW) {
      this.currentIW.close();
    }
  }

  public handleCenterChange(event: any): void {
    console.log('event', event);
  }

  public onMarkerSelect(event: any, infoWindow: any, marker: Marker): void {
    this.previousIW = this.currentIW;
    this.currentIW = infoWindow;

    if (this.previousIW) {
      this.previousIW.close();
    }

    this.selectMarker.emit(marker);

    console.log('event click', event);
    console.log('infoWindow', infoWindow);
  }

  private setCurrentPosition(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(position => {
        const { latitude, longitude } = position.coords
        this.initialPlace = {
            latitude,
            longitude
        }
        this.currentMarker = this.initialPlace;
        this.markers = [
          { id: 222, latitude: this.initialPlace.latitude + 0.01, longitude: this.initialPlace.longitude + 0.01},
          { id: 333, latitude: this.initialPlace.latitude - 0.01, longitude: this.initialPlace.longitude - 0.01},
        ];
      });

    } else {
      alert("Geolocation is not supported by this browser, please use google chrome.");
    }
  }

}

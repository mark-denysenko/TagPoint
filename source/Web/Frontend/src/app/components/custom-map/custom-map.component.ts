import { Component, OnInit, Input } from '@angular/core';
import { AgmInfoWindow } from '@agm/core';

interface Marker {
  latitude: number;
  longitude: number;
  label?: string;
}

@Component({
  selector: 'app-custom-map',
  templateUrl: './custom-map.component.html',
  styleUrls: ['./custom-map.component.scss']
})
export class CustomMapComponent implements OnInit {
  public initialPlace?: Marker;
  public currentMarker?: Marker;
  @Input() public markers: Marker[] = [];

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
    
  }

  public selectMarker(event: any, infoWindow: any): void {
    this.previousIW = this.currentIW;
    this.currentIW = infoWindow;

    if (this.previousIW) {
      this.previousIW.close();
    }

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
          { latitude: this.initialPlace.latitude + 0.01, longitude: this.initialPlace.longitude + 0.01},
          { latitude: this.initialPlace.latitude - 0.01, longitude: this.initialPlace.longitude - 0.01},
        ];
      });

    } else {
      alert("Geolocation is not supported by this browser, please use google chrome.");
    }
  }

}

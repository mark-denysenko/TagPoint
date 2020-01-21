import { Component, OnInit } from '@angular/core';

interface Location {
  latitude: number;
  longitude: number;
  zoom: number;
  mapType?: string;
}

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
  public location?: Location;
  public markers: Marker[] = [{ latitude: 50.4547,  longitude: 30.5238 }];

  constructor() { }

  ngOnInit() {
    this.location = {
      latitude: 50.4547,
      longitude: 30.5238,
      mapType: "satelite",
      zoom: 10
    };
  }

}

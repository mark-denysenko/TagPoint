import { Component, OnInit } from '@angular/core';

interface Location {
  latitude: number;
  longitude: number;
  mapType?: string;
}

@Component({
  selector: 'app-custom-map',
  templateUrl: './custom-map.component.html',
  styleUrls: ['./custom-map.component.scss']
})
export class CustomMapComponent implements OnInit {
  public location?: Location;

  constructor() { }

  ngOnInit() {
    this.location = {
      latitude: -28.68352,
      longitude: -147.20785,
      mapType: "satelite"
    };
  }

}

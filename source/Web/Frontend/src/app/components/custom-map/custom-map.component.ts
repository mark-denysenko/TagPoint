import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AgmInfoWindow } from '@agm/core';

@Component({
  selector: 'app-custom-map',
  templateUrl: './custom-map.component.html',
  styleUrls: ['./custom-map.component.scss']
})
export class CustomMapComponent implements OnInit {
  @Input() public initialPlace?: Marker;
  @Input() public currentMarker?: Marker;
  @Input() public zoom!: number;
  @Input() public markers!: MarkerWithPosts[];

  @Output() public selectMarker = new EventEmitter<Marker>();
  @Output() public centerChange = new EventEmitter<Coordinate>();
  @Output() public zoomChange = new EventEmitter<number>();

  private currentIW: AgmInfoWindow | null = null;
  private previousIW: AgmInfoWindow | null = null;

  constructor() { }

  ngOnInit() {
  }

  public handleMapClick(event: any): void {
    //console.log('event click', event);
    this.currentMarker = {
      latitude: event.coords.lat,
      longitude: event.coords.lng
    };
    this.selectMarker.emit(this.currentMarker);
    
    if (this.currentIW) {
      this.currentIW.close();
    }
  }

  public handleCenterChange({ lng, lat }: any): void {
    console.log('handleCenterChange', event);
    this.centerChange.emit({ longitude: lng, latitude: lat });
  }

  public handleZoomChange(zoom: number): void {
    this.zoomChange.emit(zoom);
  }

  public onMarkerSelect(event: any, infoWindow: any, marker: Marker): void {
    this.previousIW = this.currentIW;
    this.currentIW = infoWindow;

    console.log('onMarkerSelect,', event);
    

    if (this.previousIW) {
      this.previousIW.close();
    }

    this.selectMarker.emit(marker);
  }

  public trackById(_index: any, item: Marker): number | undefined {
    return item.id;
  }
}

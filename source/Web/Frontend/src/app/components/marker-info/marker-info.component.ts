import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-marker-info',
  templateUrl: './marker-info.component.html',
  styleUrls: ['./marker-info.component.scss']
})
export class MarkerInfoComponent implements OnInit {

  @Input()
  marker!: Marker;

  constructor() { }

  ngOnInit() {
  }

}

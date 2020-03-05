import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomMapComponent } from './custom-map.component';
import { AgmCoreModule } from '@agm/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MarkerInfoModule } from '../marker-info/marker-info.module';

@NgModule({
  declarations: [CustomMapComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MarkerInfoModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAsc-CRI5KjV2xe1H7rhM6Cp68I69n18rA',//environment.keys.gmap,
      libraries: ["places", "geometry"] //, "geocoding"
    })
  ],
  exports: [CustomMapComponent]
})
export class CustomMapModule { }

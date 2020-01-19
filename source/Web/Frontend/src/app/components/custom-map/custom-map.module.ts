import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomMapComponent } from './custom-map.component';
import { AgmCoreModule } from '@agm/core';


@NgModule({
  declarations: [CustomMapComponent],
  imports: [
    CommonModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAsc-CRI5KjV2xe1H7rhM6Cp68I69n18rA',//environment.keys.gmap,
      libraries: ["places", "geometry"] //, "geocoding"
    })
  ],
  exports: [CustomMapComponent]
})
export class CustomMapModule { }

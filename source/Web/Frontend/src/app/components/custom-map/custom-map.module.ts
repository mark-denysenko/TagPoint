import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomMapComponent } from './custom-map.component';
import { AgmCoreModule } from '@agm/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MarkerInfoModule } from '../marker-info/marker-info.module';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [CustomMapComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MarkerInfoModule,
    AgmCoreModule.forRoot({
      apiKey: environment.keys.gmap,
      // from documentation - uk (Ukrainian)
      language: 'uk',
      region: 'ua',
      libraries: ["places", "geometry"]
    })
  ],
  exports: [CustomMapComponent]
})
export class CustomMapModule { }

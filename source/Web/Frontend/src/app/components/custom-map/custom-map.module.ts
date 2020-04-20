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
    AgmCoreModule
  ],
  exports: [CustomMapComponent]
})
export class CustomMapModule { }

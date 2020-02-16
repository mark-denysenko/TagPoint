import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarkerInfoComponent } from './marker-info.component';



@NgModule({
  declarations: [MarkerInfoComponent],
  exports: [MarkerInfoComponent],
  imports: [
    CommonModule
  ]
})
export class MarkerInfoModule { }

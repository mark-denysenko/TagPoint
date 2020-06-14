import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomMapComponent } from './custom-map.component';
import { AgmCoreModule } from '@agm/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MarkerInfoModule } from '../marker-info/marker-info.module';
import { AppDropdownModule } from '../dropdown/dropdown.module';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [CustomMapComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MarkerInfoModule,
    AgmCoreModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    AppDropdownModule
  ],
  exports: [CustomMapComponent]
})
export class CustomMapModule { }

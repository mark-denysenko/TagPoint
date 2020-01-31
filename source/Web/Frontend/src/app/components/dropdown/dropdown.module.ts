import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppDropdownComponent } from './dropdown.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';



@NgModule({
  declarations: [AppDropdownComponent],
  exports: [AppDropdownComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AppDropdownModule { }

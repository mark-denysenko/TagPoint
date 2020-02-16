import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileValueAccessorDirective } from './file-value-accessor.directive';

@NgModule({
  declarations: [FileValueAccessorDirective],
  exports: [FileValueAccessorDirective],
  imports: [
    CommonModule
  ]
})
export class DirectivesModule { }

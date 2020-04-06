import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostSmallViewComponent } from './post-small-view.component';
import { FlexLayoutModule } from '@angular/flex-layout';



@NgModule({
  declarations: [PostSmallViewComponent],
  exports : [PostSmallViewComponent],
  imports: [
    CommonModule,
    FlexLayoutModule
  ]
})
export class PostSmallViewModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostCreatorComponent } from './post-creator.component';



@NgModule({
  declarations: [PostCreatorComponent],
  exports: [PostCreatorComponent],
  imports: [
    CommonModule
  ]
})
export class PostCreatorModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostCreatorComponent } from './post-creator.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [PostCreatorComponent],
  exports: [PostCreatorComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class PostCreatorModule { }

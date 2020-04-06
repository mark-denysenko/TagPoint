import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostCreatorComponent } from './post-creator.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppInputTextModule } from '../input/text/text.module';



@NgModule({
  declarations: [PostCreatorComponent],
  exports: [PostCreatorComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    AppInputTextModule
  ]
})
export class PostCreatorModule { }

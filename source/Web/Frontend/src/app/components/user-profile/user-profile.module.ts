import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserProfileComponent } from './user-profile.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppLabelModule } from '../label/label.module';
import { AppInputPasswordModule } from '../input/password/password.module';
import { AppInputTextModule } from '../input/text/text.module';
import { AppDropdownModule } from '../dropdown/dropdown.module';



@NgModule({
  declarations: [UserProfileComponent],
  exports: [UserProfileComponent],
  imports: [
    CommonModule,
    AppInputTextModule,
    AppInputPasswordModule,
    AppLabelModule,
    ReactiveFormsModule,
    AppDropdownModule
  ]
})
export class UserProfileModule { }

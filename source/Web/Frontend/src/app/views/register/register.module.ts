import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AppRegisterComponent } from './register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppButtonModule } from 'src/app/components/button/button.module';
import { AppInputPasswordModule } from 'src/app/components/input/password/password.module';
import { AppInputTextModule } from 'src/app/components/input/text/text.module';
import { AppLabelModule } from 'src/app/components/label/label.module';

const routes: Routes = [
  { path: "", component: AppRegisterComponent }
];

@NgModule({
  declarations: [AppRegisterComponent],
  imports: [
      CommonModule,
      ReactiveFormsModule,
      RouterModule.forChild(routes),
      AppButtonModule,
      AppInputPasswordModule,
      AppInputTextModule,
      AppLabelModule
  ],
  exports: [RouterModule]
})
export class AppRegisterModule { }

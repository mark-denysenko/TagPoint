import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile.component';
import { RouterModule, Routes } from '@angular/router';
import { UserProfileModule } from 'src/app/components/user-profile/user-profile.module';

const routes: Routes = [
  { path: "", component: ProfileComponent }
];

@NgModule({
  declarations: [ProfileComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    UserProfileModule
  ],
  exports: [RouterModule]
})
export class ProfileModule { }

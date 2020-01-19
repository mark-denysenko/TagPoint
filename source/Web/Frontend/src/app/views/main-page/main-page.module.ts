import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MapViewModule } from './map-view/map-view.module';
import { MapViewComponent } from './map-view/map-view.component';

const routes: Routes = [
  { path: "", component: MapViewComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MapViewModule
  ],
  exports: [RouterModule]
})
export class MainPageModule { }

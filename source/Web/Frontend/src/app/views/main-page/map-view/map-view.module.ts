import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapViewComponent } from './map-view.component';
import { CustomMapModule } from 'src/app/components/custom-map/custom-map.module';
import { PostCreatorModule } from 'src/app/components/post-creator/post-creator.module';
//import { Routes, RouterModule } from '@angular/router';

// const routes: Routes = [
//   { path: "", component: MapViewComponent }
// ];

@NgModule({
  declarations: [MapViewComponent],
  imports: [
    CommonModule,
    CustomMapModule,
    PostCreatorModule
    //RouterModule.forChild(routes)
  ],
  //exports: [RouterModule]
})
export class MapViewModule { }

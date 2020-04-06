import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapViewComponent } from './map-view.component';
import { CustomMapModule } from 'src/app/components/custom-map/custom-map.module';
import { PostCreatorModule } from 'src/app/components/post-creator/post-creator.module';
import { MarkerInfoModule } from 'src/app/components/marker-info/marker-info.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PostSmallViewModule } from 'src/app/components/post-small-view/post-small-view.module';

@NgModule({
  declarations: [MapViewComponent],
  imports: [
    CommonModule,
    CustomMapModule,
    PostCreatorModule,
    MarkerInfoModule,
    FlexLayoutModule,
    PostSmallViewModule
    //RouterModule.forChild(routes)
  ],
  //exports: [RouterModule]
})
export class MapViewModule { }

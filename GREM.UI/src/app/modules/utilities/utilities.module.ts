import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TimelineComponent } from './timeline/timeline.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [TimelineComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    TimelineComponent
  ]
})

export class UtilitiesModule { }

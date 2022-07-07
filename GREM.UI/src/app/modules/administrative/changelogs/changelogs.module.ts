import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangelogsRoutingModule } from './changelogs-routing.module';
import { ChangelogmasterComponent } from './master/changelogmaster/changelogmaster.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { Routes, RouterModule } from '@angular/router';

@NgModule({
  declarations: [ChangelogmasterComponent],
  imports: [
    CommonModule,
    ChangelogsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    RouterModule
  ]
})
export class ChangelogsModule { }

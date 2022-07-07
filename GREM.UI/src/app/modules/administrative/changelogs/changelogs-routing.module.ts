import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChangelogmasterComponent } from './master/changelogmaster/changelogmaster.component';


const routes: Routes = [
  { path: '', component: ChangelogmasterComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChangelogsRoutingModule { }

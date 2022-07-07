
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParameterComponent } from './parameter/parameter.component';


const routes: Routes = [
  { path: '', component: ParameterComponent }
];

@NgModule({
  declarations: [

  ],
  imports: 
  [RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ParametersRoutingModule { }

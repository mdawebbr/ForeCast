import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { StatusComponent } from './../../components/agendamento/actions/status/status.component';
import { ButtonsComponent } from './../../components/agendamento/actions/buttons/buttons.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MasterComponent } from './master/master.component';
import { DriversRoutingModule } from './drivers-routing.module';
import { DriversComponent } from './drivers/drivers.component';


import { AgGridModule } from 'ag-grid-angular';
import { NgxMaskModule } from 'ngx-mask';
//import { NgxMaskModule } from 'ngx-mask-2';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgSelectModule } from '@ng-select/ng-select';
import { DriversEditComponent } from './drivers-edit/drivers-edit.component';


@NgModule({
  declarations: [MasterComponent, DriversComponent, DriversEditComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DriversRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    MatSortModule,
    NgxMaskModule.forRoot(),
    AgGridModule.withComponents({
      ButtonsComponent,
      StatusComponent
    }),
    MatAutocompleteModule,
    NgSelectModule
  ]
})
export class DriversModule { }

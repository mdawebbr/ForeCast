import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { DriversRoutingModule } from './drivers-routing.module';
import { DriversComponent } from './drivers/drivers.component';

import { NgxMaskModule } from 'ngx-mask';
//import { NgxMaskModule } from 'ngx-mask-2';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatFormFieldModule } from '@angular/material';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatTooltipModule} from '@angular/material/tooltip';
import { Routes, RouterModule } from '@angular/router';

@NgModule({
  declarations: [DriversComponent],
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
    MatAutocompleteModule,
    NgSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonToggleModule,
    MatCheckboxModule,
    MatTooltipModule,
    RouterModule
  ],
  schemas: [ 
    CUSTOM_ELEMENTS_SCHEMA 
  ],
})
export class DriversModule { }

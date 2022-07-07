import { NgxMaskModule } from 'ngx-mask';
//import { NgxMaskModule } from 'ngx-mask-2';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule} from '@angular/material/select';
import { MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgSelectModule } from '@ng-select/ng-select';
import { ParametersRoutingModule } from './parameters-routing.module';
import { ParameterComponent } from './parameter/parameter.component';
import { FormsModule, ReactiveFormsModule, NgSelectOption } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';


@NgModule({
  declarations: [ParameterComponent],
  imports: [
    CommonModule,
    ParametersRoutingModule,
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
    RouterModule
  ]
})
export class ParametersModule { }

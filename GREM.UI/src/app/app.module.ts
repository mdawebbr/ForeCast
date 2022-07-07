import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeModule } from './modules/home/home.module';
import { HttpClientModule } from '@angular/common/http';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthenticationModule } from './_authentication/authentication.module';
import { AcessonegadoComponent } from './components/acessonegado/acessonegado.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { SharedModule } from './modules/shared/shared.module';
import { PaginatorComponent } from './modules/shared/paginator/paginator.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { HasProfileDirective } from './directives/security/has-profile.directive';
import { ValidatorsService } from './modules/shared/validators/validators.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { BnNgIdleService } from 'bn-ng-idle';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgSelectModule } from '@ng-select/ng-select';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import  localePt  from '@angular/common/locales/pt';
import { RouterModule } from '@angular/router';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatChipsModule } from '@angular/material/chips';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material';
import { ClienteComponent } from './components/cliente/cliente.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { LinhacapComponent } from 'src/app/components/linhacap/linhacap.component';
import { MercadovfComponent } from 'src/app/components/mercadovf/mercadovf.component';
import { MercadocapComponent } from 'src/app/components/mercadocap/mercadocap.component';
import { PronosticoComponent } from './components/pronostico/pronostico.component';
import { NgMonthPickerModule } from 'ng-month-picker';
import { NgxMonthPickerModule } from 'ngx-month-picker-range';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgmultselectComponent } from './components/ngmultselect/ngmultselect.component';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from 'src/app/modules/material/material.module';
import { ExcelimportComponent } from './components/excelimport/excelimport.component';
import { UploadComponent } from './components/upload/upload.component';
import { CadastrousuarioComponent } from './components/cadastrousuario/cadastrousuario.component';

export let options: Partial<IConfig> | (() => Partial<IConfig>);
registerLocaleData(localePt, 'pt-BR');

@NgModule({
  declarations: [
    AppComponent,
    AcessonegadoComponent,
    SidebarComponent,
    PaginatorComponent,
    HasProfileDirective,
    ClienteComponent,
    LinhacapComponent,
    MercadocapComponent,
    MercadovfComponent,
    PronosticoComponent,
    NgmultselectComponent,
    ExcelimportComponent,
    UploadComponent,
    CadastrousuarioComponent

  ],
  imports: [
    AppRoutingModule,
    MatButtonModule,
    RouterModule,
    CommonModule,
    BrowserModule,
    MaterialModule,
    FontAwesomeModule,
    HomeModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AuthenticationModule,
    SharedModule,
    NgxSpinnerModule,
    NgxMaskModule,
    NgxPaginationModule,
    NgxMaskModule.forRoot(),
    NgSelectModule,
    BrowserAnimationsModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatTableModule,
    MatPaginatorModule,
    MatChipsModule,
    MatInputModule,
    MatSortModule,
    MatSnackBarModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    MatExpansionModule,
    MatSnackBarModule,
    NgMonthPickerModule,
    NgxMonthPickerModule,
    NgMultiSelectDropDownModule.forRoot()
   ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    ValidatorsService,
    BnNgIdleService,
    MatDatepickerModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeModule } from './modules/home/home.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AutenticacaoComponent } from './login/autenticacao/autenticacao.component'
import { NgxSpinnerModule } from 'ngx-spinner';
import { PerfilComponent } from './perfil/perfil.component';
import { AuthenticationModule } from './_authentication/authentication.module';
import { AcessonegadoComponent } from './components/acessonegado/acessonegado.component';
import { AgendamentoComponent } from './components/agendamento/agendamento.component';
import { AgendamentodetailComponent } from './components/agendamento/agendamentodetail/agendamentodetail.component';
import { AgendamentoformComponent } from './components/agendamento/agendamentoform/agendamentoform.component';
import { CadastroUsuarioComponent } from './components/cadastro-usuario/cadastro-usuario.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TrocasenhaComponent } from './components/trocasenha/trocasenha.component';
import { UsuarioComponent } from './components/usuario/usuario.component';
import { SharedModule } from './modules/shared/shared.module';
import { PaginatorComponent } from './modules/shared/paginator/paginator.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { HasProfileDirective } from './directives/security/has-profile.directive';
import { ValidatorsService } from './modules/shared/validators/validators.service';
import { AgGridModule } from 'ag-grid-angular';
import { ButtonsComponent } from './components/agendamento/actions/buttons/buttons.component';
import { StatusComponent } from './components/agendamento/actions/status/status.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SchedulingComponent } from './components/scheduling/scheduling.component';
import { MonitoradoComponent } from './components/agendamento/monitorado/monitorado.component';
import { AgendamentocondutorComponent } from './components/agendamento/agendamentocondutor/agendamentocondutor.component';
import { ReagendamentoComponent } from './components/reagendamento/reagendamento.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatTableModule } from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatInputModule} from '@angular/material/input';
import {MatSortModule} from '@angular/material/sort';
import InvoiceService from './_services/invoice/InvoiceService';
import { BnNgIdleService } from 'bn-ng-idle';
import { NgxMaskModule, IConfig } from 'ngx-mask'
//import { NgxMaskModule, IConfig } from 'ngx-mask-2'
import { MatDatepickerModule,  MatNativeDateModule } from '@angular/material'
import {MatSelectModule} from '@angular/material/select';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgSelectModule } from '@ng-select/ng-select';

import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import {MatExpansionModule} from '@angular/material/expansion';
import { AgendamentoviewComponent } from './components/agendamento/agendamentoview/agendamentoview/agendamentoview.component';

export let options: Partial<IConfig> | (() => Partial<IConfig>);

registerLocaleData(localePt, 'pt-BR');

@NgModule({
  declarations: [
    AppComponent,
    AutenticacaoComponent,
    PerfilComponent,
    AcessonegadoComponent,
    AgendamentoComponent,
    AgendamentodetailComponent,
    AgendamentoformComponent,
    CadastroUsuarioComponent,
    SidebarComponent,
    TrocasenhaComponent,
    UsuarioComponent,
    PaginatorComponent,
    HasProfileDirective,
    ButtonsComponent,
    StatusComponent,
    SchedulingComponent,
    MonitoradoComponent,
    AgendamentocondutorComponent,
    ReagendamentoComponent,
    AgendamentoviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    HomeModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSpinnerModule,
    NgxMaskModule,
    AuthenticationModule,
    SharedModule,
    NgxPaginationModule,
    NgxDatatableModule,
    MatNativeDateModule,
    AgGridModule.withComponents([
      ButtonsComponent,
      StatusComponent
    ]),
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    MatSortModule,
    MatSelectModule,
    NgxMaskModule.forRoot(),
    MatAutocompleteModule,
    NgSelectModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    ValidatorsService,
    InvoiceService,
    BnNgIdleService,
    MatDatepickerModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

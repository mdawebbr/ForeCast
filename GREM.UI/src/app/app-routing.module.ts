import { ParameterAllSetupComponent } from './modules/parameters/parameter/parameter-all-setup/parameter-all-setup.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AcessonegadoComponent } from './components/acessonegado/acessonegado.component';
import { DriversComponent } from './modules/drivers/drivers/drivers.component';
import { ClienteComponent } from './components/cliente/cliente.component';
import { LinhacapComponent } from 'src/app/components/linhacap/linhacap.component';
import { CadastrousuarioComponent } from 'src/app/components/cadastrousuario/cadastrousuario.component';
import { MercadocapComponent } from 'src/app/components/mercadocap/mercadocap.component';
import { MercadovfComponent } from 'src/app/components/mercadovf/mercadovf.component';
import { PronosticoComponent } from './components/pronostico/pronostico.component';
import { NgmultselectComponent } from './components/ngmultselect/ngmultselect.component';
import { ExcelimportComponent } from './components/excelimport/excelimport.component';

import { UploadComponent } from './components/upload/upload.component';

const routes: Routes = [
  { path: '', pathMatch: 'full',  component: DriversComponent, loadChildren: () => import('./modules/drivers/drivers.module').then(x=>x.DriversModule)},
  { path: 'acessonegado', component: AcessonegadoComponent },
  { path: 'parameters/configuracoesGerais', component: ParameterAllSetupComponent, loadChildren: () => import ('./modules/parameters/parameters.module').then(d=>d.ParametersModule) },
  { path: 'cargaForecast', component: DriversComponent, loadChildren: () => import('./modules/drivers/drivers.module').then(x=>x.DriversModule)},

  { path: 'uploadexcell', component: ExcelimportComponent},

  { path: 'uploadexcell2', component: UploadComponent},

  { path: 'cliente', component: ClienteComponent},

  { path: 'linhacap', component: LinhacapComponent},

  { path: 'cadastrousuario', component: CadastrousuarioComponent},

  { path: 'mercadocap', component: MercadocapComponent},

  { path: 'mercadovf', component: MercadovfComponent},

  { path: 'pronostico', component: PronosticoComponent},

  { path: 'ngmultselect', component: NgmultselectComponent},

  { path: '**', component: AcessonegadoComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { useHash: true }),
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

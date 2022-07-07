import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { linhacapbr } from './../models/estado-br.model';
import { Pais } from './../models/pais';
import { Mercadocap } from './../models/mercadocap';
import { Mercadovf } from './../models/mercadovf';
import { Linhacap } from './../models/linhacap';
import { Modal } from './../models/modal';
import { Cidade } from '../models/cidade';
import { map } from '../../../../node_modules/rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})


export class DropdownService {
  constructor(private http: HttpClient) {}

  GetAll_LCAP()
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/LinhaCAP/GetAll`);
  }
  // GetAll_LCAP() {
  //   return this.http.get<Linhacap[]>('assets/dados/linhacap.json');
  // }


  GetAll_MCAP()
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/MercadoCAP/GetAll`);
  }
  // GetAll_MCAP() {
  //   return this.http.get<Mercadocap[]>('assets/dados/mercadocap.json');
  // }

  GetAll_MVF()
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/MercadoVf/GetAll`);
  }
  // GetAll_MVF() {
  //   return this.http.get<Mercadovf[]>('assets/dados/mercadovf.json');
  // }


  getPais() {
    return this.http.get<Pais[]>('assets/dados/pais.json');
  }

  getModal() {
    return this.http.get<Modal[]>('assets/dados/modal.json');
  }

  getCidades(idEstado: number) {
    return this.http.get<Cidade[]>('assets/dados/cidades.json')
    .pipe(
      // tslint:disable-next-line:triple-equals
      map((cidades: Cidade[]) => cidades.filter(c => c.estado == idEstado))
    );
  }

  getCargos() {
    return [
      { nome: 'Dev', nivel: 'Junior', desc: 'Dev Jr' },
      { nome: 'Dev', nivel: 'Pleno', desc: 'Dev Pl' },
      { nome: 'Dev', nivel: 'Senior', desc: 'Dev Sr' }
    ];
  }

  getTecnologias() {

    return [
      { nome: 'java', desc: 'Java' },
      { nome: 'javascript', desc: 'JavaScript' },
      { nome: 'php', desc: 'PHP' },
      { nome: 'ruby', desc: 'Ruby' }
    ];
  }

  getNewsletter() {
    return [
      { valor: 's', desc: 'Sim' },
      { valor: 'n', desc: 'Não' }
    ];
  }
}

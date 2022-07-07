import { Injectable } from '@angular/core';
import { HttpClient, HttpParams }  from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { linhacapbr } from './../../shared/models/estado-br.model';
import { Pais } from './../../shared/models/pais';
import { Mercadocap } from './../../shared/models/mercadocap';
import { Linhacap } from './../../shared/models/linhacap';
import { Modal } from './../../shared//models/modal';
import { Cidade } from './../../shared/models/cidade';
import { map } from '../../../../node_modules/rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MercadovfService {

  infosNfs: any[] = [];

  constructor(private http: HttpClient) { }

  GetAll()
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/MercadoVf/GetAll`);
  }

  GetById(id: number) {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/MercadoVF/GetById?id=${id}`);
  }

  getLinhacap() {
    return this.http.get(`${environment.apiUrl}/api/MercadoVF/GetLinhaCAP`);
  }
  //GetMyDetails(filtro?: string)
  //{
  //    var url = filtro == null ? `${environment.apiUrl}/ReceiveProcessDashboard/GetMyDetails` : `${environment.apiUrl}/ReceiveProcessDashboard/GetMyDetails?filtro=${filtro}`;
  //    return this.cli.get(url)
  //}

  GetAllMeioTransporte() {
    return this.http.get(`${environment.apiUrl}/api/MercadoVF/GetAllMeioTransporte`);
  }

  PostCliente(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/MercadoVF/`, obj);
  }

  UpdateMVF(obj)
  {
    console.log(obj)
    return this.http.post(`${environment.apiUrl}/api/MercadoVF/Alterar`, obj);
  }

  RemoverCliente(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/MercadoVF/Remover`, obj);
  }

  GetAllPlanoEmbarque(mes: number) {
    return this.http.get(`${environment.apiUrl}/api/PlanoEmbarque/GetAll?mes=${mes}&ano=2019`);
  }

  GetFilter(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    return this.http.get(`${environment.apiUrl}/api/PlanoEmbarque/GetFilter?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`);
  }

  GetTodosMesesFilter(ano: number, cliente_id: number, transporte_id : number){
    return this.http.get(`${environment.apiUrl}/api/PlanoEmbarque/GetTodosMesesFilter?ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`);
  }

  GetDiaMesFilter(dia: number, mes:number, ano: number, cliente_id: number, transporte_id : number){
    return this.http.get(`${environment.apiUrl}/api/PlanoEmbarque/GetDiaMesFilter?dia=${dia}&mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`);
  }

  Post(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/PlanoEmbarque/`, obj);
  }

  Alterar(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/PlanoEmbarque/Alterar`, obj);
  }

  Remover(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/PlanoEmbarque/Remover`, obj);
  }

  DownloadCSV(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    window.open(`${environment.apiUrl}/api/PlanoEmbarque/GetCSV?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }

  DownloadIR(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    window.open(`${environment.apiUrl}/api/PlanoEmbarque/GetIR?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }

  DownloadQ1(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    window.open(`${environment.apiUrl}/api/PlanoEmbarque/GetIRQ1?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }


}

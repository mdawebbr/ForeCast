import { Injectable } from '@angular/core';
import { HttpClient, HttpParams }  from '@angular/common/http';
import { linhacapbr } from './../../shared/models/estado-br.model';
import { Pais } from './../../shared/models/pais';
import { Mercadocap } from './../../shared/models/mercadocap';
import { Linhacap } from './../../shared/models/linhacap';
import { Modal } from './../../shared//models/modal';
import { Cidade } from './../../shared/models/cidade';
import { map } from '../../../../node_modules/rxjs/operators';
import { environment } from 'src/environments/environment';
//src\app\shared\models

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  infosNfs: any[] = [];

  constructor(private http: HttpClient) { }
  //constructor(private cli: HttpClient,private apiConfig: ApiConfig, private http: HttpClient) { }
  // Acesso Json
  // getEstadosBr() {
  //   return this.http.get<linhacapbr[]>('assets/dados/estadosbr.json');
  // }
  // getLinhacap() {
  //   return this.http.get<Linhacap[]>('assets/dados/linhacap.json');
  // }
  // getPais() {
  //   return this.http.get<Pais[]>('assets/dados/pais.json');
  // }
  // getMercadocap() {
  //   return this.http.get<Mercadocap[]>('assets/dados/mercadocap.json');
  // }
  // getModal() {
  //   return this.http.get<Modal[]>('assets/dados/modal.json');
  // }
  // getCidades(idEstado: number) {
  //   return this.http.get<Cidade[]>('assets/dados/cidades.json')
  //   .pipe(
  //     // tslint:disable-next-line:triple-equals
  //     map((cidades: Cidade[]) => cidades.filter(c => c.estado == idEstado))
  //   );
  // }
  // Acesso Json

  getEstadosBr() {
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/GetAll`);
  }
  getLinhacap() {
    return this.http.get(`${environment.apiUrl}/api/LinhaCAP/GetAll`);
  }
  getPais() {
    return this.http.get<Pais[]>('assets/dados/pais.json');
  }
  getMercadocap() {
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/Mercadocap`);
  }
  getModal() {
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/Modal`);
  }
  getCidades(idEstado: number) {
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/GetAll`)
    .pipe(
      // tslint:disable-next-line:triple-equals
      map((cidades: Cidade[]) => cidades.filter(c => c.estado == idEstado))
    );
  }

  GetAll()
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/GetAll`);
  }

  GetById(id: number)
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/GetById?id=${id}`);
  }
  PostCliente(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/ClienteDapper/`, obj);
  }

  UpdateCliente(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/ClienteDapper/Alterar`, obj);
  }

  RemoverCliente(obj)
  {
    //debugger
    console.log(obj)
    return this.http.post(`${environment.apiUrl}/api/ClienteDapper/Remover`, obj);
  }
  //GetMyDetails(filtro?: string)
  //{
  //    var url = filtro == null ? `${environment.apiUrl}/ReceiveProcessDashboard/GetMyDetails` : `${environment.apiUrl}/ReceiveProcessDashboard/GetMyDetails?filtro=${filtro}`;
  //    return this.cli.get(url)
  //}

  GetAllMeioTransporte() {
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/GetAllMeioTransporte`);
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

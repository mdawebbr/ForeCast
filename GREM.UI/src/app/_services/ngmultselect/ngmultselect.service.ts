import { Injectable } from '@angular/core';
import { HttpClient, HttpParams }  from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Cidade } from './../../shared/models/cidade';
import { map } from '../../../../node_modules/rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NgmultselectService {

  infosNfs: any[] = [];

  constructor(private http: HttpClient) { }


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

  GetAllCliente()
  {
    //debugger
    return this.http.get(`${environment.apiUrl}/api/ClienteDapper/GetAll`);
  }

  GetAllMesAno(){
    return this.http.get(`${environment.apiUrl}/api/Ngmultselect/GetAll`);
  }

  GetById(id: number)
  {
    debugger
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
    return this.http.post(`${environment.apiUrl}/api/ClienteDapper/Remover`, obj);
  }

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
    return this.http.post(`${environment.apiUrl}/api/Ngmultselect/`, obj);
  }

  Alterar(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/Ngmultselect/Alterar`, obj);
  }

  Remover(obj)
  {
    return this.http.post(`${environment.apiUrl}/api/Ngmultselect/Remover`, obj);
  }

  DownloadCSV(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    window.open(`${environment.apiUrl}/api/Ngmultselect/GetCSV?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }

  DownloadIR(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    window.open(`${environment.apiUrl}/api/Ngmultselect/GetIR?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }

  DownloadQ1(mes: number, ano: number, cliente_id: number, transporte_id : number) {
    window.open(`${environment.apiUrl}/api/Ngmultselect/GetIRQ1?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }

}

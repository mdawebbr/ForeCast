import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteFC, MercadoCAP, MercadoVF,LinhaCAP } from '../../model/cliente';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  //url = 'https://localhost:44376/Api/Cliente';
  url = 'https://localhost:51600/api/Cliente';

  constructor(private http: HttpClient) { }

  getAllCliente(): Observable<ClienteFC[]>{
    //debugger;
    //return this.http.get<ClienteFC[]>(this.url + `/AllClienteDetails`);
    return this.http.get<ClienteFC[]>(`${environment.apiUrl}/api/Cliente/AllClienteDetails`);
  }

  GetAll() {
    return this.http.get(`${this.url}/api/ClienteDapper/GetAll`);
  }

  getClienteById(clienteId: string): Observable<ClienteFC>{
    return this.http.get<ClienteFC>(`${environment.apiUrl}/api/Cliente/GetClienteDetailsById/` + clienteId);
  }

  createCliente(cliente: ClienteFC): Observable<ClienteFC>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<ClienteFC>(`${environment.apiUrl}/api/Cliente/InsertClienteDetails/`, cliente, httpOptions);
  }
  updateCliente(cliente: ClienteFC): Observable<ClienteFC>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<ClienteFC>(`${environment.apiUrl}/api/Cliente/UpdateClienteDetails/`, cliente, httpOptions);
  }
  deleteClienteById(cliente: string): Observable<number>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(`${environment.apiUrl}/api/Cliente/DeleteClienteDetails?id=` + cliente, httpOptions);
  }

  getMercadoCAP(): Observable<MercadoCAP[]>{
    return this.http.get<MercadoCAP[]>(`${environment.apiUrl}/api/Cliente/MercadoCAP`);
    //return this.http.get(`${this.url}/api/Cliente/GetAllMeioTransporte`);
  }

  getMercadoVF(MercadoCAPId: string): Observable<MercadoVF[]>{
    return this.http.get<MercadoVF[]>(`${environment.apiUrl}/api/Cliente/MercadoCAP/` + MercadoCAPId + `/MercadoVF`);
  }

  getCity(MercadoVFId: string): Observable<LinhaCAP[]>{
    return this.http.get<LinhaCAP[]>(`${environment.apiUrl}/api/Cliente/MercadoVF/` + MercadoVFId + `/LinhaCAP`);
  }

  deleteData(user: ClienteFC[]): Observable<string>
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<string>(`${environment.apiUrl}/api/Cliente/DeleteRecord/`, user, httpOptions);
  }
}

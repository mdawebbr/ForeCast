import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cadastrousuario, MercadoCAP, MercadoVF, City } from '../../model/cadastrousuario';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CadastrousuarioService {
  url = 'https://localhost:51600/api/Cadastrousuario';
  constructor(private http: HttpClient) { }

  getAllCadastrousuario(): Observable<Cadastrousuario[]> {
    //debugger;
    return this.http.get<Cadastrousuario[]>(`${environment.apiUrl}/api/Cadastrousuario/AllCadastrousuarioDetails`);
  }

  getCadastrousuarioById(cadastrousuarioId: string): Observable<Cadastrousuario> {
    return this.http.get<Cadastrousuario>(`${environment.apiUrl}/api/Linhacap/GetLinhacapDetailsById/`+cadastrousuarioId);
  }

  createCadastrousuario(cadastrousuario: Cadastrousuario): Observable<Cadastrousuario> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Cadastrousuario>(`${environment.apiUrl}/api/Linhacap/InsertLinhacapDetails/`, cadastrousuario, httpOptions);
  }

  updateCadastrousuario(cadastrousuario: Cadastrousuario): Observable<Cadastrousuario> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Cadastrousuario>(`${environment.apiUrl}/api/Cadastrousuario/UpdateCadastrousuarioDetails/`, Cadastrousuario, httpOptions);
  }

  deleteCadastrousuarioById(Cadastrousuarioid: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(`${environment.apiUrl}/api/Cadastrousuario/DeleteCadastrousuarioDetails?id=` + Cadastrousuarioid, httpOptions);
  }

  getMercadoCAP(): Observable<MercadoCAP[]> {
    return this.http.get<MercadoCAP[]>(`${environment.apiUrl}/api/Cadastrousuario/MercadoCAP`);
  }

  getMercadoVF(MercadoCAPId: string): Observable<MercadoVF[]>{
    return this.http.get<MercadoVF[]>(`${environment.apiUrl}/api/Cadastrousuario/MercadoCAP/` + MercadoCAPId +`/MercadoVF`);
  }

  getCity(MercadoVFId: string): Observable<Cadastrousuario[]> {
    return this.http.get<Cadastrousuario[]>(`${environment.apiUrl}/api/Cadastrousuario/MercadoVF/`+MercadoVFId +`/LinhaCAP`);
  }

  deleteData(user: Cadastrousuario[]): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<string>(`${environment.apiUrl}/DeleteRecord/`, user, httpOptions);
  }
}

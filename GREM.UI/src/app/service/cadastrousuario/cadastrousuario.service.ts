import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Linhacap, MercadoCAP, MercadoVF, City } from '../../model/linhacap';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CadastrousuarioService {
  url = 'https://localhost:51600/api/Linhacap';
  constructor(private http: HttpClient) { }

  getAllLinhacap(): Observable<Linhacap[]> {
    //debugger;
    //return this.http.get<Linhacap[]>(this.url + '/AllLinhacapDetails');
    return this.http.get<Linhacap[]>(`${environment.apiUrl}/api/Linhacap/AllLinhacapDetails`);
  }

  getLinhacapById(linhacapId: string): Observable<Linhacap> {
    //return this.http.get<Linhacap>(this.url + '/GetLinhacapDetailsById/' + linhacapId);
    return this.http.get<Linhacap>(`${environment.apiUrl}/api/Linhacap/GetLinhacapDetailsById/`+ linhacapId);
  }

  createLinhacap(linhacap: Linhacap): Observable<Linhacap> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Linhacap>(`${environment.apiUrl}/api/Linhacap/InsertLinhacapDetails/`, linhacap, httpOptions);
  }

  updateLinhacap(linhacap: Linhacap): Observable<Linhacap> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Linhacap>(`${environment.apiUrl}/api/Linhacap/UpdateLinhacapDetails/`, linhacap, httpOptions);
  }

  deleteLinhacapById(linhacapid: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    //return this.http.delete<number>(this.url + '/DeleteLinhacapDetails?id=' + linhacapid, httpOptions);
    return this.http.delete<number>(`${environment.apiUrl}/api/Linhacap/DeleteLinhacapDetails?id=` + linhacapid, httpOptions);
  }

  getMercadoCAP(): Observable<MercadoCAP[]> {
    //return this.http.get<MercadoCAP[]>(this.url + '/MercadoCAP');
    return this.http.get<MercadoCAP[]>(`${environment.apiUrl}/api/Linhacap/MercadoCAP`);
  }

  getMercadoVF(MercadoCAPId: string): Observable<MercadoVF[]>{
    //return this.http.get<MercadoVF[]>(this.url + '/MercadoCAP/' + MercadoCAPId + '/MercadoVF');
    return this.http.get<MercadoVF[]>(`${environment.apiUrl}/api/Linhacap/MercadoCAP/` + MercadoCAPId +`/MercadoVF`);
  }

  getCity(MercadoVFId: string): Observable<Linhacap[]> {
    //return this.http.get<Linhacap[]>(this.url + '/MercadoVF/' + MercadoVFId + '/LinhaCAP');
    return this.http.get<Linhacap[]>(`${environment.apiUrl}/api/Linhacap/MercadoVF/`+MercadoVFId +`/LinhaCAP`);
  }

  deleteData(user: Linhacap[]): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    //return this.http.post<string>(this.url + '/DeleteRecord/', user, httpOptions);
    return this.http.post<string>(`${environment.apiUrl}/DeleteRecord/`, user, httpOptions);
  }
}

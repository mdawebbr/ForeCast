import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MercadocapFC, MercadovfFC, CityFC } from '../../model/mercadocap';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MercadocapService {
  url = 'https://localhost:51600/api/Mercadocap';
  constructor(private http: HttpClient) { }

  getAllMercadocap(): Observable<MercadocapFC[]> {
    //debugger;
    //return this.http.get<Linhacap[]>(this.url + '/AllLinhacapDetails');
    return this.http.get<MercadocapFC[]>(`${environment.apiUrl}/api/Mercadocap/AllMercadocapDetails`);
  }

  getMercadocapById(mercadocapId: string): Observable<MercadocapFC> {
    //return this.http.get<Linhacap>(this.url + '/GetLinhacapDetailsById/' + linhacapId);
    return this.http.get<MercadocapFC>(`${environment.apiUrl}/api/Mercadocap/GetMercadocapDetailsById/`+ mercadocapId);
  }

  createMercadocap(mercadocap: MercadocapFC): Observable<MercadocapFC> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    console.log(mercadocap)
    debugger
    return this.http.post<MercadocapFC>(`${environment.apiUrl}/api/Mercadocap/InsertMercadocapDetails/`, mercadocap, httpOptions);
  }

  updateMercadocap(mercadocap: MercadocapFC): Observable<MercadocapFC> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<MercadocapFC>(`${environment.apiUrl}/api/Mercadocap/UpdateMercadocapDetails/`, mercadocap, httpOptions);
  }

  deleteMercadocapById(mercadocapid: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    //return this.http.delete<number>(this.url + '/DeleteLinhacapDetails?id=' + linhacapid, httpOptions);
    return this.http.delete<number>(`${environment.apiUrl}/api/Mercadocap/DeleteMercadocapDetails?id=` + mercadocapid, httpOptions);
  }

  getMercadoCAP(): Observable<MercadocapFC[]> {
    //return this.http.get<MercadoCAP[]>(this.url + '/MercadoCAP');
    return this.http.get<MercadocapFC[]>(`${environment.apiUrl}/api/Mercadocap/MercadoCAP`);
  }

  getMercadoVF(MercadoCAPId: string): Observable<MercadovfFC[]>{
    //return this.http.get<MercadoVF[]>(this.url + '/MercadoCAP/' + MercadoCAPId + '/MercadoVF');
    return this.http.get<MercadovfFC[]>(`${environment.apiUrl}/api/Mercadocap/MercadoCAP/` + MercadoCAPId +`/MercadoVF`);
  }

  getCity(MercadoVFId: string): Observable<MercadocapFC[]> {
    //return this.http.get<Linhacap[]>(this.url + '/MercadoVF/' + MercadoVFId + '/LinhaCAP');
    return this.http.get<MercadocapFC[]>(`${environment.apiUrl}/api/Mercadocap/MercadoVF/`+MercadoVFId +`/LinhaCAP`);
  }

  deleteData(user: MercadocapFC[]): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    //return this.http.post<string>(this.url + '/DeleteRecord/', user, httpOptions);
    return this.http.post<string>(`${environment.apiUrl}/DeleteRecord/`, user, httpOptions);
  }
}

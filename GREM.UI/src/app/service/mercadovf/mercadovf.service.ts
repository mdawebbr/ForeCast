import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MercadovfFC, MercadoCAP, LinhaCAP } from '../../model/mercadovf';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MercadovfService {
  //url = 'https://localhost:44376/Api/Mercadovf';
  url = 'https://localhost:51600/api/Mercadovf';

  constructor(private http: HttpClient) { }

  getAllMercadovf(): Observable<MercadovfFC[]>{
    //debugger;
    //return this.http.get<MercadovfFC[]>(this.url + `/AllMercadovfDetails`);
    return this.http.get<MercadovfFC[]>(`${environment.apiUrl}/api/Mercadovf/AllMercadovfDetails`);
  }

  GetAll() {
    return this.http.get(`${this.url}/api/MercadovfDapper/GetAll`);
  }

  getMercadovfById(mercadovfId: string): Observable<MercadovfFC>{
    return this.http.get<MercadovfFC>(`${environment.apiUrl}/api/Mercadovf/GetMercadovfDetailsById/` + mercadovfId);
  }

  createMercadovf(mercadovf: MercadovfFC): Observable<MercadovfFC>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<MercadovfFC>(`${environment.apiUrl}/api/Mercadovf/InsertMercadovfDetails/`, mercadovf, httpOptions);
  }
  updateMercadovf(mercadovf: MercadovfFC): Observable<MercadovfFC>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<MercadovfFC>(`${environment.apiUrl}/api/Mercadovf/UpdateMercadovfDetails/`, mercadovf, httpOptions);
  }
  deleteMercadovfById(mercadovf: string): Observable<number>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(`${environment.apiUrl}/api/Mercadovf/DeleteMercadovfDetails?id=` + mercadovf, httpOptions);
  }

  getMercadoCAP(): Observable<MercadoCAP[]>{
    return this.http.get<MercadoCAP[]>(`${environment.apiUrl}/api/Mercadovf/MercadoCAP`);
    //return this.http.get(`${this.url}/api/Mercadovf/GetAllMeioTransporte`);
  }

  getMercadoVF(MercadoCAPId: string): Observable<MercadovfFC[]>{
    return this.http.get<MercadovfFC[]>(`${environment.apiUrl}/api/Mercadovf/MercadoCAP/` + MercadoCAPId + `/MercadoVF`);
  }

  getCity(MercadoVFId: string): Observable<LinhaCAP[]>{
    return this.http.get<LinhaCAP[]>(`${environment.apiUrl}/api/Mercadovf/MercadoVF/` + MercadoVFId + `/LinhaCAP`);
  }

  deleteData(user: MercadovfFC[]): Observable<string>
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<string>(`${environment.apiUrl}/api/Mercadovf/DeleteRecord/`, user, httpOptions);
  }
}

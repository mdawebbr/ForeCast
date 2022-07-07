import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  usuarioNome: string;
  usuarioEmail: string;
  usuarioLogin: string;

  GetInfoUsuario() {
    var item = localStorage.getItem('currentUser');
    var pam = new HttpParams().set('hash', item);

    return this.http.get(`${environment.apiUrl}/api/Usuario/GetInfoUsuario`, { params: pam });
  }
}

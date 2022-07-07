import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ParametersService {

  constructor(private http: HttpClient) { }


  Get(id: number) : Observable<any> {
    return this.http.get(`${environment.apiUrl}/api/Parametros/${id}`);
  }

  UpdateLimiteCaminhao(e) {
    return this.http.post(`${environment.apiUrl}/api/Parametros/UpdateLimiteCaminhao?valor=${e}`, JSON.stringify(e.toString()))
  }

  UpdateLimiteNavio(e) {
    return this.http.post(`${environment.apiUrl}/api/Parametros/UpdateLimiteNavio?valor=${e}`, JSON.stringify(e.toString()))
  }

  UpdateLimiteTrem(e) {
    return this.http.post(`${environment.apiUrl}/api/Parametros/UpdateLimiteTrem?valor=${e}`, JSON.stringify(e.toString()))
  }
}

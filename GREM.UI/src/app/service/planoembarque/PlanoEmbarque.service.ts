import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http'
import { PlanoEmbarque } from '../../model/PlanoEmbarque';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PlanoEmbarqueService {

  constructor(private http: HttpClient) { }

  //url = 'http://localhost:44376/Api/Excel';
  url = 'http://localhost:51600/api/Excel';

  UploadExcel(formData: FormData) {
    const headers = new HttpHeaders();

    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');
    headers.append('Access-Control-Allow-Origin', '*');
    const httpOptions = { headers: headers };

    // const headers= new HttpHeaders()
    // .set('content-type', 'application/json')
    // .set('Access-Control-Allow-Origin', '*');

    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    console.log(formData);
    console.log(httpOptions);
    return this.http.post<any>(`${environment.apiUrl}/api/Excel/UploadExcel`, formData, httpOptions);
  }

  UploadExcel2(formData: FormData) {
    const headers = new HttpHeaders();

    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');
    headers.append('Access-Control-Allow-Origin', '*');
    const httpOptions = { headers: headers };

    // const headers= new HttpHeaders()
    // .set('content-type', 'application/json')
    // .set('Access-Control-Allow-Origin', '*');

    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    console.log(formData);
    console.log(httpOptions);
    return this.http.post<any>(`${environment.apiUrl}/api/Excel/UploadExcel`, formData, httpOptions);
  }

  BindPlanoEmbarque(): Observable<PlanoEmbarque[]> {
    return this.http.get<PlanoEmbarque[]>(this.url + '/PlanoEmbarqueDetails');
  }


}

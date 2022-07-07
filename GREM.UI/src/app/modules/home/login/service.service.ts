import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { NotifyService } from '../../utilities/notify.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ServiceService {
  constructor(private http: HttpClient, private service: NotifyService) { }

  GetAll() {
    this.http.get(`${environment.apiUrl}/api/Usuario`)
    .subscribe(d=> {
    })
  }

  GetEmpresa(obj: string) {
    var params = new HttpParams().set('cnpj', obj);
    
    return this.http.get(`${environment.apiUrl}/api/Usuario/VerifyCnpj`, {
      params: params
    })
  }

  Post(obj) {
    this.http.post(`${environment.apiUrl}/api/Usuario`, obj)
    .subscribe(d=> {
      this.service.Alert(d["Tipo"], d["Titulo"], d["Mensagem"]);
    }, x=> {
      this.service.Alert('orange', "Encontramos um problema!", "Encontramos um problema ao processar o seu cadastro! Tente novamente...");
    })
  }
}

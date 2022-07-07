import { Injectable } from '@angular/core';
import { HttpClient, HttpParams }  from '@angular/common/http';
import { linhacapbr } from '../../shared/models/estado-br.model';
import { Pais } from '../../shared/models/pais';
import { Mercadocap } from '../../shared/models/mercadocap';
import { Linhacap } from '../../shared/models/linhacap';
import { Modal } from '../../shared/models/modal';
import { Cidade } from '../../shared/models/cidade';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
//src\app\shared\models

@Injectable({
  providedIn: 'root'
})
export class PronosticoService {

  infosNfs: any[] = [];

  constructor(private http: HttpClient) { }

  GetAll() {
    return this.http.get(`${environment.apiUrl}/api/Pronostico/GetAll`);
  }

  RodaSP(ano: any, mes: any, qtd: number) {
    window.open(`${environment.apiUrl}/api/Pronostico/SP?ano=${ano}&mes=${mes}&qtd=${qtd}`, "_blank")
    //window.open(`${environment.apiUrl}/api/PlanoEmbarque/GetIR?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  }

  // DownloadCSV(mes: number, ano: number, cliente_id: number, transporte_id : number) {
  //   window.open(`${environment.apiUrl}/api/Ngmultselect/GetCSV?mes=${mes}&ano=${ano}&cliente_id=${cliente_id}&transporte_id=${transporte_id}`, "_blank")
  // }
  DownloadCSV() {
    window.open(`${environment.apiUrl}/api/Pronostico/GetCSV`)
  }
}

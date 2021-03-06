
import DriverService from 'src/app/_services/driver/DriverService';
import { Component, OnInit, ViewChild } from '@angular/core';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { HomeService } from '../../../_services/home/home.service';
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { ValidatorsService } from 'src/app/modules/shared/validators/validators.service';
import { GridApi } from "ag-grid-community";
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator, MatPaginatorIntl} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';

@Component({
  selector: 'app-drivers',
  templateUrl: './drivers.component.html',
  styleUrls: ['./drivers.component.css']
})
export class DriversComponent implements OnInit {

  registros: any;
  minhasInfos: any;
  itensPag: 10;

  gridApi: GridApi;
  gridColumnApi: any;
  columns: any[];
  rows: MatTableDataSource<any>;

  paginatorConfig: MatPaginatorIntl;

  maxEdit: number;

  roles: string[];

  gridLoaded: boolean = false;

  filtro: any = {};
  public tempoExclusaoDt: any;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  filtroStatus: Array<any> = [];

  constructor(private http: HomeService, private validators: ValidatorsService, private service: DriverService, private notify: NotifyService) { 
    this.roles = [];
    this.columns = [ 'documento', 'nome', 'telefone', 'vencimento', 'status', 'actions' ]
    this.paginatorConfig = new MatPaginatorIntl();
    this.paginatorConfig.itemsPerPageLabel = "Itens por Página";

    this.paginatorConfig.getRangeLabel = (page, pageSize, length) => {
      if (length == 0 || pageSize == 0) { return `0 de ${length}`; } 
      length = Math.max(length, 0); 
      const startIndex = page * pageSize; 
      const endIndex = startIndex < length ? 
      Math.min(startIndex + pageSize, length) : startIndex + pageSize; 
      return `${startIndex + 1} – ${endIndex} de ${length}`;
    }
  }


  ngOnInit() {
    this.registros = [];
    this.minhasInfos = {};
	
	  this.GetAll();

  }

  // ChangeFilter(e) {
  //   this.agService.GetMySchedules(e.target.value)
  //   .toPromise()
  //   .then((data: any[]) => {
  //     this.registros = data;
  //   })
  //   .then(() => this.setRowData())
  // }

  // Filter(idFiltro: HTMLInputElement,codSapFiltro: HTMLInputElement, dataInicioFiltro: HTMLInputElement, dataFimFiltro: HTMLInputElement, statusIdFiltro: HTMLInputElement, dtFiltro: HTMLInputElement)
  // {
  //     console.log("novo filtro");
  //     console.log("id");
  //     console.log(idFiltro.value.trim().toLowerCase());
  //     console.log("codSap");
  //     console.log(codSapFiltro.value.trim().toLowerCase());
  //     console.log("dataInicio");
  //     console.log(dataInicioFiltro.value.trim().toLowerCase());
  //     console.log("dataFim");
  //     console.log(dataFimFiltro.value.trim().toLowerCase());
  //     console.log("status");
  //     console.log(statusIdFiltro.value);

  //     this.filtro.Id = idFiltro.value.trim().toLowerCase();
  //     this.filtro.De = dataInicioFiltro.value.trim().toLowerCase();
  //     this.filtro.Ate = dataFimFiltro.value.trim().toLowerCase();
  //     this.filtro.Status_Id = statusIdFiltro.value;
  //     this.filtro.FornecedorTransportador = codSapFiltro.value.trim().toLowerCase();
  //     this.filtro.DT = dtFiltro.value.trim();

  //     console.log(this.filtro);
  //     this.agService.Filter(this.filtro)
  //       .toPromise()
  //       .then((data) => 
  //       {
  //         this.registros = data;
  //       })
  //       .then((d) => {
  //         this.setRowData()
  //       })

  // }

  // Filter() {
  //   console.log("filtro");
  //   console.log(this.filtro);
  //   this.agService.Filter(this.filtro)
  //     .toPromise()
  //     .then((data) => {
  //       this.registros = data;
  //     })
  //     .then((d) => {
  //       this.setRowData();
  //     })
  // }

  GetAll()
  {
    var resultados: any[];
    this.service.GetAll()
      .toPromise()
      .then((data: any) => {
        this.registros = data;
      })
      .then(() => this.setRowData())
      .then(() => {
        this.registros.map((e) => {
          // let index = this.filtroStatus.findIndex(a=> a.Id == e.Status.Id);

          // if(index == -1)
          //   this.filtroStatus.push({
          //     Id: e.Status.Id,
          //     Name: e.Status.Name
          //   })
        })
      })
	  .then((d) => {
		  this.setRowData()
	  })
  }

 
  setRowData() {
    var tmp = [];
    var dataAtual = new Date();
    this.registros.map((data) => {
      tmp.push({
        documento: data.Document,
        nome : data.Name,
        material: data.Material_Id,
        telefone: data.PhoneNumber,
        vencimento: `${this.CastDate(data.DueDate)}`,
        status: data.Inative ? "Inativo" : this.CastDateTime(data.DueDate) < dataAtual ? "Carteira vencida" : "Ativo",
        statusColor: data.Inative ? "red" : this.CastDateTime(data.DueDate) < dataAtual ? "red" : "green",
        id: data.Id
        
      });
      
        
      this.roles = data.Roles;
      console.log("roles");
      console.log(data);
    })

    this.gridLoaded = true;
    this.rows = new MatTableDataSource(tmp);
    this.rows.paginator = this.paginator;
    this.rows.paginator._intl = this.paginatorConfig;
    this.rows.sort = this.sort;

    console.log(tmp)
  }

  Inativar(id:number) {
    this.service.Block(id)
      .subscribe(d=> {
        this.notify.AutoAlert(d);
        this.ngOnInit();
      });

  }

  Ativar(id:number) {
    this.service.Unblock(id)
      .subscribe(d=> {
        this.notify.AutoAlert(d);
        this.ngOnInit();
      });
  }

  applyFilter(e: HTMLInputElement) {
    this.rows.filter = e.value.trim().toLowerCase();
  }

  CastDate(obj: string) {
    return new Date(obj).toLocaleDateString()
  }

  CastDateTime(obj: string) {
    return new Date(obj);
  }

  // ConfigDtTime() {
  //   this.notify.Prompt("Tempo de permanência do DT", `Configure quanto tempo o DT ficará disponível após a data do agendamento (padrão: ${this.tempoExclusaoDt.Value} dias).`, (e) => {
  //     this.params.UpdateDtTime(e)
  //       .subscribe(d=> {
  //         this.ngOnInit();
  //       })
  //   })
  // }

  // Cancel(id: number) : void {
  //   new Promise((resolve, reject) => {
  //     this.notify.PromptConfirm("Você confirma o cancelamento?", "Você estará cancelando este agendamento. Tem certeza?", () => {
  //       this.agService.Cancel(id)
  //         .subscribe((data) => {
  //           if(data["Status"] == "OK") {
  //             this.notify.Alert('green', data["Titulo"], data["Mensagem"]);
  //           }
  //           else
  //           {
  //             this.notify.Alert('orange', data["Titulo"], data["Mensagem"]);
  //           }
  //           resolve();
  //         });
  //     })
  //   }).then(() => {
  //     this.ngOnInit();
  //   })
  // }
  
  // get Login() {
	//   return this.http.usuarioLogin;
  // }
  
  // get Email() {
	//   return this.http.usuarioEmail;
  // }
}


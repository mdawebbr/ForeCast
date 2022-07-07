
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { ValidatorsService } from 'src/app/modules/shared/validators/validators.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ClienteService } from 'src/app/_services/cliente/cliente.service';
import { isUndefined } from 'util';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
declare var jQuery:any;

@Component({
  selector: 'app-drivers',
  templateUrl: './drivers.component.html',
  styleUrls: ['./drivers.component.css']
})
export class DriversComponent implements OnInit {

  registros: any;
  minhasInfos: any;
  itensPag: 10;

  gridColumnApi: any;
  columns: any[];
  rows: MatTableDataSource<any>;

  paginatorConfig: MatPaginatorIntl;

  maxEdit: number;

  roles: string[];

  mesAtivo : number;

  gridLoaded: boolean = false;

  idAlterar: any;
  valorAlterar: any;
  pacoteAlterar: string = "";
  meioTransporte_Id: number;
  clienteAlterar: any;
  diaAlterar: any;

  filtro: any = {};
  public tempoExclusaoDt: any;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  filtroCliente: Array<any> = [];

  filtroMeioTransporte: Array<any> = [];

  tmp: Array<any> = [];
  tmpTodosMeses: Array<any> = [];
  tmpDiaMes: Array<any> = [];
  listaCompleta: Array<any> = [];

  filtroCliente_Id : number = 0;
  filtroTransporte_Id : number = 0;
  filtroAnoPea : number;

  listaAnos : Array<any>;
  listaDias : Array<any>;
  listaTotalMeses : Array<any>;

  total: any;
  totalMes: any;

  todosMeses : boolean = false;
  mesSelecionado: string = "";

  constructor(private clienteservice: ClienteService, private validators: ValidatorsService, private notify: NotifyService) {
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
    this.listaDias = [];

    this.GetAllClientes();
    this.GetAllMeioTransporte();
    this.setAno();
    this.setDias();

    this.mesAtivo = 7;

    //this.GetPlanoEmbarqueByMes(7);

    this.GetPlanoEmbarqueFilter();
    this.GetPlanoEmbarqueTodosMesesFilter();
    this.load();
  }

  GetAllClientes()
  {
    var resultados: any[];
    this.clienteservice.GetAll()
      .toPromise()
      .then((data: any) => {
        this.filtroCliente = data;
      })
  }

  load(){
    (sessionStorage.refresh == 'true ' || !sessionStorage.refresh ) && location.reload();
    sessionStorage.refresh = false;
  }

  setAno()
  {

    var date = new Date();
    var anoAtual = date.getFullYear();

    this.listaAnos = [anoAtual -1 , anoAtual];
    this.filtroAnoPea = anoAtual -1;
  }

  mudaFlagTodosMeses()
  {
    this.todosMeses = !this.todosMeses;

    this.GetPlanoEmbarqueTodosMesesFilter();
  }

  applyMonth(mes:number)
  {
    this.mesAtivo = mes;

    //this.GetPlanoEmbarqueByMes(mes);
    this.GetPlanoEmbarqueFilter();
  }


  GetPlanoEmbarqueTodosMesesFilter()
  {
    this.clienteservice.GetTodosMesesFilter(this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
    .toPromise()
    .then((data: any) => {
      console.log(data);
      this.tmpTodosMeses = data;
      this.listaTotalMeses = data[0].ListaMes;
      this.total = 0;
      this.listaTotalMeses.forEach(element => {
        this.total += element.Valor;
      });
    })

  }

  GetPlanoEmbarqueFilter()
  {
    this.clienteservice.GetFilter(this.mesAtivo, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
    .toPromise()
    .then((data: any) => {
      this.tmp = data;
      this.totalMes = 0;
      this.tmp.forEach(element => {
        this.totalMes += element.ValorTotalDia;
      });
    })

  }

  Adicionar(clienteIdAdd, transporteIdAdd, diasAdd, mesesAdd, peaAnoAdd, valorAdd: HTMLInputElement)
  {

    var obj =
    {
      cliente_id: clienteIdAdd.value,
      transporte_id: transporteIdAdd.value,
      dias: diasAdd.value,
      meses: mesesAdd.value,
      peaAno: peaAnoAdd.value,
      valor: valorAdd
    }

    console.log(obj);
    this.clienteservice.Post(obj)
    .subscribe((d) => {
      if(d["titulo"] == "Sucesso!")
      {
        this.notify.Alert('green', d["titulo"], d["mensagem"]);
        jQuery('#modalAdicionar').modal('hide');
        this.ngOnInit();
      }
      else if(d["titulo"] == "Atenção!")
      {
        this.notify.Alert('orange',  "<i class=\"fa fa-exclamation-triangle\" style=\"color: #FFD700;\" aria-hidden=\"true\"></i> " +  d["titulo"], d["mensagem"]);
        jQuery('#modalAdicionar').modal('hide');
        this.ngOnInit();
      }

      else
        this.notify.Alert('red', d["titulo"], d["mensagem"]);


    });

    this.clearInputsAdd();
  }

  clearInputsAdd()
  {
    // console.log($('#clienteIdAdd'))
    // $('#clienteIdAdd').val('');
  }

  downloadCSV() {
    if(this.todosMeses)
      this.clienteservice.DownloadCSV(0, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
    else
      this.clienteservice.DownloadCSV(this.mesAtivo, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
  }

  GetDiaMesFilter(dia: number, mes:number)
  {
    this.clienteservice.GetDiaMesFilter(dia, mes, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
    .toPromise()
    .then((data: any) => {
      this.tmpDiaMes = data;
    })

  }


  onPEAChange(event)
  {
    console.log(event);
    this.filtroAnoPea = event.value;
    this.GetPlanoEmbarqueFilter();
    this.GetPlanoEmbarqueTodosMesesFilter();
  }

  abrirModalAdicionar()
  {
    jQuery('#modalAdicionar').modal('show');
  }

  setDias()
  {
    var i:number;
    for(i = 1; i<=31; i++)
    {
      this.listaDias.push(i);
    }
  }

  abrirModalMesDia(dia: number, mes: number)
  {
    console.log("modalmesDia");
    console.log(dia,mes);

    this.setMes(mes);

    this.GetDiaMesFilter(dia, mes);

    jQuery('#modalMesDia').modal('show');

  }

  setMes(mes)
  {
    if(mes == 1)
      this.mesSelecionado = "Janeiro";
    else if(mes == 2)
      this.mesSelecionado = "Fevereiro";
    else if(mes == 3)
      this.mesSelecionado = "Março";
    else if(mes == 4)
      this.mesSelecionado = "Abril";
    else if(mes == 5)
      this.mesSelecionado = "Maio";
    else if(mes == 6)
      this.mesSelecionado = "Junho";
    else if(mes == 7)
      this.mesSelecionado = "Julho";
    else if(mes == 8)
      this.mesSelecionado = "Agosto";
    else if(mes == 9)
      this.mesSelecionado = "Setembro";
      else if(mes == 10)
        this.mesSelecionado = "Outubro";
      else if(mes == 11)
        this.mesSelecionado = "Novembro";
      else if(mes == 12)
        this.mesSelecionado = "Dezembro";
  }

  onClienteAddChange(event) {

    console.log(event);
  }

  onClienteChange(event) {

    if(isUndefined(event.value))
    {
      this.filtroCliente_Id = 0;
    }
    if(event.value > 0)
    {
      this.filtroCliente_Id = event.value;
    }

    this.GetPlanoEmbarqueFilter();
    this.GetPlanoEmbarqueTodosMesesFilter();
  }

  onTransporteChange(event) {
    if(isUndefined(event.value))
    {
      this.filtroTransporte_Id = 0;
    }
    if(event.value > 0)
    {
      this.filtroTransporte_Id = event.value;
    }

    this.GetPlanoEmbarqueFilter();
    this.GetPlanoEmbarqueTodosMesesFilter();
  }

  abrirModalAlterar(id, nome, dia, valor, meioTransporte_Id, pacote)
  {
    console.log(id);
    console.log(valor);
    console.log(meioTransporte_Id);
    this.meioTransporte_Id = meioTransporte_Id;
    this.idAlterar = id;
    this.valorAlterar = valor;
    this.pacoteAlterar = pacote;
    this.clienteAlterar = nome;
    this.diaAlterar = dia;
    jQuery('#modalAlterar').modal('show');
  }

  Alterar(idAlterar: HTMLInputElement, valor: HTMLInputElement, transporteId: HTMLInputElement, pacote: HTMLInputElement)
  {
    var t = this.meioTransporte_Id.toString();
    if(!isUndefined(transporteId.value))
      t = transporteId.value;

    var obj =
    {
      id: idAlterar,
      valor: valor.value,
      transporte_Id: t,
      pacote: pacote.value
    }

    console.log(obj);
    this.clienteservice.Alterar(obj)
    .subscribe((d) => {
      if(d["titulo"] == "Sucesso!")
      {
        this.notify.Alert('green', d["titulo"], d["mensagem"]);
        jQuery('#modalAlterar').modal('hide');
        this.ngOnInit();
      }
      else if(d["titulo"] == "Atenção!")
        this.notify.Alert('orange', "<i class=\"fa fa-exclamation-triangle\" style=\"color: #228B22;\" aria-hidden=\"true\"></i> " +  d["titulo"], d["mensagem"]);
      else
        this.notify.Alert('red', d["titulo"], d["mensagem"]);


    });
  }

  Remover(id)
  {
    var obj =
    {
      id: id
    }


    new Promise((resolve, reject) => {
      this.notify.PromptConfirm("Confirmação", "Você Confirma a exclusão do registro?", () => {
        this.clienteservice.Remover(obj)
        .subscribe((d) => {
          if(d["titulo"] == "Sucesso!")
          {
            this.notify.Alert('green', d["titulo"], d["mensagem"]);
            this.ngOnInit();
          }
          else if(d["titulo"] == "Atenção!")
            this.notify.Alert('orange', "<i class=\"fa fa-exclamation-triangle\" style=\"color: #228B22;\" aria-hidden=\"true\"></i> " + d["titulo"], d["mensagem"]);
          else
            this.notify.Alert('red', d["titulo"], d["mensagem"]);

          //resolve();
        });
      })
    }).then(() => {
      this.ngOnInit();
    })

  }


  GetPlanoEmbarqueByMes(mes: number)
  {
    var temporaria = [];
    this.clienteservice.GetAllPlanoEmbarque(this.mesAtivo)
      .toPromise()
      .then((data: any) => {
        data.forEach(element => {
          if(element.ListaCliente == '')
          {
            temporaria.push(element);
          }
          else
          {
            if(this.filtroCliente_Id > 0)
            {
              var clienteFilter = element.ListaCliente.filter(x => x.Cliente.Id == this.filtroCliente_Id);
              element.ListaCliente = clienteFilter;

              if(this.filtroTransporte_Id > 0)
              {
                element.ListaCliente = clienteFilter.filter(x => x.MeioTransporte.Id == this.filtroTransporte_Id);
              }
            }
            else
            {
              if(this.filtroTransporte_Id > 0)
              {
                var clienteFilter = element.ListaCliente.filter(x => x.MeioTransporte.Id == this.filtroTransporte_Id);
                element.ListaCliente = clienteFilter;
              }
            }

            temporaria.push(element);
          }
        });

        this.tmp = temporaria;
    })
  }

  GetAllMeioTransporte()
  {
    var resultados: any[];
    this.clienteservice.GetAllMeioTransporte()
      .toPromise()
      .then((data: any) => {
        this.filtroMeioTransporte = data;
      })
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


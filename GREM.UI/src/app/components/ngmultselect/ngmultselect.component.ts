import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { ValidatorsService } from 'src/app/modules/shared/validators/validators.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { NgmultselectService } from 'src/app/_services/ngmultselect/ngmultselect.service';
import { ClienteService } from 'src/app/_services/cliente/cliente.service';
import { isUndefined } from 'util';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
declare var jQuery:any;

@Component({
  selector: 'app-ngmultselect',
  templateUrl: './ngmultselect.component.html'
})
export class NgmultselectComponent implements OnInit {

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

  constructor
  (
    private Ngmultselec: NgmultselectService,
    private clienteservice: ClienteService,
    private validators: ValidatorsService,
    private notify: NotifyService
  )
  {
    this.roles = [];
    this.columns = [ 'clienteid', 'nome', 'mes', 'ano', 'actions' ]
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
    //this.GetAllMeioTransporte();
    //this.setAno();
    this.setAnos();
    this.setDias();

    this.mesAtivo = 7;

    //this.GetPlanoEmbarqueByMes(7);

    //this.GetPlanoEmbarqueFilter();
    //this.GetPlanoEmbarqueTodosMesesFilter();

    this.GetAll(); //ClienteMesAno
  }

  GetAll()
  {
    var resultados: any[];
    this.Ngmultselec.GetAllMesAno()
      .toPromise()
      .then((data: any) => {
        this.registros = data;
      })
      .then(() => this.setRowData())
      .then(() => {
        this.registros.map((e) => {
        })
      })
	  .then((d) => {
		  this.setRowData()
	  })
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

  //c.LinhaCAPId,c.Linha_CAP,mc.Mercado_CAP,mvf.Mercado_VF
  setRowData() {
    var tmp = [];
    this.registros.map((data) => {
      tmp.push({
        clienteid: data.Cliente_Id,
        nome: data.Nome_Cliente,
        mes: data.Meses,
        ano: data.Ano
      });
    })


    this.gridLoaded = true;
    this.rows = new MatTableDataSource(tmp);
    this.rows.paginator = this.paginator;
    this.rows.paginator._intl = this.paginatorConfig;
    this.rows.sort = this.sort;

    console.log(tmp)
  }

  setAno()
  {
    var date = new Date();
    var anoAtual = date.getFullYear();

    this.listaAnos = [anoAtual -1 , anoAtual];
    this.filtroAnoPea = anoAtual -1;
  }

  setAnos()
  {
    var date = new Date();
    var anoAtual = date.getFullYear();

    this.listaAnos = [anoAtual -2 , anoAtual-1, anoAtual ];
    this.filtroAnoPea = anoAtual -1;
  }

  setDias()
  {
    var i:number;
    //for(i = 1; i<=31; i++)
    for(i = 1; i<=1; i++)
    {
      this.listaDias.push(i);
    }
  }

  // toggleAllSelection() {
  //   if (this.allSelected.selected) {
  //     this.searchUserForm.controls.userType
  //       .patchValue([...this.userTypeFilters.map(item => item.key), 0]);
  //   } else {
  //     this.searchUserForm.controls.userType.patchValue([]);
  //   }
  // }

  Adicionar(clienteIdAdd, mesesAdd, AnoAdd: HTMLInputElement)
  {
    var obj =
    {
      cliente_id: clienteIdAdd.value,
      //nome: nomeAdd.value,
      //dias: diasAdd.value,
      meses: mesesAdd.value,
      Ano: AnoAdd.value
      //valor: valorAdd
    }

    console.log(obj);
    this.Ngmultselec.Post(obj)
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
    this.Ngmultselec.GetTodosMesesFilter(this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
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
    this.Ngmultselec.GetFilter(this.mesAtivo, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
    .toPromise()
    .then((data: any) => {
      this.tmp = data;
      this.totalMes = 0;
      this.tmp.forEach(element => {
        this.totalMes += element.ValorTotalDia;
      });
    })

  }



  clearInputsAdd()
  {
    // console.log($('#clienteIdAdd'))
    // $('#clienteIdAdd').val('');
  }

  downloadCSV() {
    if(this.todosMeses)
      this.Ngmultselec.DownloadCSV(0, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
    else
      this.Ngmultselec.DownloadCSV(this.mesAtivo, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
  }

  GetDiaMesFilter(dia: number, mes:number)
  {
    this.Ngmultselec.GetDiaMesFilter(dia, mes, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
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
    this.Ngmultselec.Alterar(obj)
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

emdesenvolvimento()
{
  new Promise((resolve, reject) => {
    this.notify.PromptConfirm("Confirmação", "Você confirma a exclusão do registro?", () =>{})
  }).then(() => {
    this.ngOnInit();
  })

}

  Remover(id,mes,ano)
  {
    var obj =
    {
      Cliente_Id: id,
      Meses: mes,
      Ano: ano
    }

    console.log(obj);

    new Promise((resolve, reject) => {
      this.notify.PromptConfirm("Confirmação", "Você confirma a exclusão do registro?", () => {
        this.Ngmultselec.Remover(obj)
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
    this.ngOnInit();
  }


  GetPlanoEmbarqueByMes(mes: number)
  {
    var temporaria = [];
    this.Ngmultselec.GetAllPlanoEmbarque(this.mesAtivo)
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
    this.Ngmultselec.GetAllMeioTransporte()
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

}

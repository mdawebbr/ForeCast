import { MercadovfService } from 'src/app/_services/mercadovf/mercadovf.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { ValidatorsService } from 'src/app/modules/shared/validators/validators.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-mercadovf',
  templateUrl: './mercadovf.component.html'
})

export class MercadovfComponent implements OnInit {

  registros: any;
  minhasInfos: any;
  itensPag: 10;

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

  constructor(private validators: ValidatorsService, private service: MercadovfService, private notify: NotifyService) {
    this.roles = [];
    //this.columns = [ 'id','nome','linha_cap','mercado_cap', 'actions' ]
    this.columns = [ 'mercadovfid', 'mercadovf', 'mercadocapid', 'mercadocap', 'actions' ]
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
        })
      })
	  .then((d) => {
		  this.setRowData()
	  })
  }
  //LinhaCAPId
  //Linha_CAP
  //MercadoCAPId
  //Mercado_CAP
  //MercadoVFId
  //Mercado_VF

  setRowData() {
    var tmp = [];
    this.registros.map((data) => {
      tmp.push({
        //linhacapid: data.LinhaCAPId,
        //linhacap : data.Linha_CAP,
        mercadocapid: data.MercadoCAPId,
        mercadocap : data.Mercado_CAP,
        mercadovfid: data.MercadoVFId,
        mercadovf : data.Mercado_VF
      });
    })

    this.gridLoaded = true;
    this.rows = new MatTableDataSource(tmp);
    this.rows.paginator = this.paginator;
    this.rows.paginator._intl = this.paginatorConfig;
    this.rows.sort = this.sort;

    console.log(tmp)
  }

  Excluir(id)
  {
    var obj =
    {
      MercadoVFId: id
    }

    new Promise((resolve, reject) => {
      this.notify.PromptConfirm("Confirmação", "Você confirma a exclusão do registro?", () => {
        this.service.RemoverCliente(obj)
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
        });
      })
    }).then(() => {
      this.ngOnInit();
    })
  }

  applyFilter(e: HTMLInputElement) {
    this.rows.filter = e.value.trim().toLowerCase();
  }
}

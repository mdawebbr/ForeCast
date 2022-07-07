import { PronosticoService } from 'src/app/_services/pronostico/pronostico.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
//import { HomeService } from 'src/app/_services/home/home.service'
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { ValidatorsService } from 'src/app/modules/shared/validators/validators.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
//import { UserService } from 'src/app/_services/user/user.service';
declare var jQuery:any;

@Component({
  selector: 'app-pronostico',
  templateUrl: './pronostico.component.html',
  styleUrls: ['./pronostico.component.css']
})

export class PronosticoComponent implements OnInit {

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

  public ano: number;
  public mes: number;
  public qtd: number;

  //param1 : number = 2022;
  //param2 : number = 4;
 // param3 : number = 3;

    constructor(private validators: ValidatorsService, private service: PronosticoService, private notify: NotifyService)
  {
    this.roles = [];
    //this.columns = [ 'customername','customerorder','customerorderid','thickness','width','comprimento','weight','customergrade','trialnumber','trialnumberint','slabcontrolkey','rio','rio2','stocknumber','sapcustomer','packageno','modal','quantity','customerduedatestart','subcode','contrmargin','prodreference','finalapplication','price','segmento','csagrade']
    this.columns = [ 'customer_order','customer_grade','rio','mes_cod','customer_name','pacote','modal','po_amount','prod_amount','plan_amount','open_amount','due_date']
    this.paginatorConfig = new MatPaginatorIntl();
    this.paginatorConfig.itemsPerPageLabel = "Itens por Página";
    this.paginatorConfig.getRangeLabel = (page, pageSize, length) =>
    {
      if (length == 0 || pageSize == 0)
      { return `0 de ${length}`; }
      length = Math.max(length, 0);
      const startIndex = page * pageSize;
      const endIndex = startIndex < length ?
      Math.min(startIndex + pageSize, length) : startIndex + pageSize;
      return `${startIndex + 1} – ${endIndex} de ${length}`;
    }
  }

  ngOnInit()
  {
    this.registros = [];
    this.minhasInfos = {};
    this.GetAll();

  }

  // downloadCSV() {
  //   if(this.todosMeses)
  //     this.service.DownloadCSV(0, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
  //   else
  //     this.service.DownloadCSV(this.mesAtivo, this.filtroAnoPea, this.filtroCliente_Id, this.filtroTransporte_Id)
  // }

  downloadCSV() {

      this.service.DownloadCSV()

  }

  abrirModalAdicionar()
  {
    jQuery('#modalAdicionar').modal('show');
  }

  CloseModal()
  {
    jQuery('#modalAdicionar').modal('hide');
  }

  GetAll()
  {
    var resultados: any[];
    this.service.GetAll().toPromise().then((data: any) =>
    {
        this.registros = data;
    }).then(() => this.setRowData()).then(() =>
    {
      this.registros.map((e) =>
      {
      })
    }).then((d) =>
    {
		  this.setRowData()
	  })
  }

  setRowData() {
    var tmp = [];
    var dataAtual = new Date();
    this.registros.map((data) => {
      tmp.push({
        customer_order: data.Customer_Order,
        customer_grade: data.Customer_Grade,
        rio: data.RIO,
        mes_cod: data.MES_Cod,
        customer_name: data.Customer_Name,
        pacote: data.Pacote,
        modal: data.Modal,
        po_amount: data.Po_Amount,
        prod_amount: data.Prod_Amount,
        plan_amount: data.Plan_Amount,
        open_amount: data.Open_Amount,
        due_date: data.Due_Date
        // customername: data.Customer_Name,
        // customerorder: data.Customer_Order,
        // customerorderid: data.Customer_Order_Id,
        // thickness: data.Thickness,
        // width: data.Width,
        // comprimento: data.Comprimento,
        // weight: data.Weight,
        // customergrade: data.Customer_Grade,
        // trialnumber: data.Trial_Number,
        // trialnumberint: data.Trial_Number_Int,
        // slabcontrolkey: data.Slab_Control_Key,
        // rio: data.RIO,
        // rio2: data.RIO2,
        // stocknumber: data.Stock_Number,
        // sapcustomer: data.SAP_Customer,
        // packageno: data.Package_No,
        // modal: data.Modal,
        // quantity: data.Quantity,
        // customerduedatestart: `${this.CastDate(data.Customer_Due_Date_Start)}`,
        // subcode: data.Subcode,
        // contrmargin: data.ContrMargin,
        // prodreference: data.Prod_Reference,
        // finalapplication: data.Final_Application,
        // price: data.Price,
        // segmento: data.Segmento,
        // csagrade: data.CSAGRADE
      });
    })
    this.gridLoaded = true;
    this.rows = new MatTableDataSource(tmp);
    this.rows.paginator = this.paginator;
    this.rows.paginator._intl = this.paginatorConfig;
    this.rows.sort = this.sort;
    console.log(tmp)
  }

  //CalcularForecast(Percentual: HTMLInputElement) {
  CalcularForecast() {
      this.service.RodaSP(this.ano, this.mes, this.qtd)
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


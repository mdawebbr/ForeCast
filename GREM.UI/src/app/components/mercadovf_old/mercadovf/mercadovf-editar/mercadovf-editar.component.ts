import { MercadovfService } from 'src/app/_services/mercadovf/mercadovf.service';
import { DropdownService } from '../../../../shared/services/dropdown.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { linhacapbr } from '../../../../shared/models/estado-br.model';
import { Cidade } from '../../../../shared/models/cidade';
import { Pais } from '../../../../shared/models/pais';
import { Modal } from '../../../../shared/models/modal';
import { Linhacap } from '../../../../shared/models/linhacap';
import { Mercadocap } from '../../../../shared/models/mercadocap';
import { Mercadovf } from '../../../../shared/models/mercadovf';
import { FormGroup, FormControl, Validators, FormBuilder }  from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ChangeDetectorRef } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable } from 'rxjs';
import { LinhacapService } from 'src/app/service/linhacap/linhacap.service';

interface MercadoCAP {
  MercadoCAPId: string;
  Mercado_CAP: string;
}

interface MercadoVF {
  MercadoVFId: string;
  Mercado_VF: string;
  MercadoCAPId: string;
}

interface City {
  LinhaCAPId: string;
  Linha_CAPName: string;
  MercadoVFId: string;
  MercadoCAPId: string;
}

@Component({
  selector: 'app-mercadovf-editar',
  templateUrl: './mercadovf-editar.component.html'
})
export class MercadovfEditarComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  //public linhacap: Array<any>;
  public mercadovf: Array<any>;
  public mercadovfSelecionado: any;
  public isEdit: boolean;
  // formulario: FormGroup;

  //linhacapbrs: linhacapbr[];

  //linhacaps: Linhacap[];
  //linhacaps: any;

  //mercadocaps: Mercadocap[];
  mercadocaps: any;

  //mercadocaps: Mercadocap[];
  mercadovfs: any;

  //paiss: Pais[];
  //paiss: any;

  //modals: Modal[];
  modals: any;

  //cidades: Cidade[];
  //cidades: any;
  //MercadoCAPId = null;
  //MercadoVFId = null;
  allMercadoCAP: Observable<MercadoCAP[]>;
  allMercadoVF: Observable<MercadoVF[]>;
  MercadoCAPId = null;
  MercadoVFId = null;
  selectedFilter: string;
  MercadoVFForm: FormGroup;
  registros: any;
  gridLoaded: boolean = false;
  rows: MatTableDataSource<any>;

// LinhaCAPId	Linha_CAP	  MercadoCAPId	MercadoVFId
// 1	          UsiminasCUB	1	            1
// 2	          CSN	        1	            1
// 3	          OutrosMI	  1	            1
// 4	          TerniumTX	  2		          2
// 5	          USA	        2	            3
// 6	          Calvert	    2	            3
// 7	          OutrosME	  2	            3
// 8	          Ovc	        3	            4

		//@ViewChild('linhacapid', { static: false }) LinhaCAPId: ElementRef;
		//@ViewChild('Linha_CAP', { static: false }) Linha_CAP: ElementRef;
		// @ViewChild('MercadoCAPId', { static: false }) MercadoCAPId: ElementRef;
		// @ViewChild('MercadoVFId', { static: false }) MercadoVFId: ElementRef;
		// @ViewChild('Mercado_CAP', { static: false }) Mercado_CAP: ElementRef;
		// @ViewChild('Mercado_VF', { static: false }) Mercado_VF: ElementRef;


  constructor
    (
    private MercadovfService: MercadovfService,
    private dropdownService: DropdownService,
    private LinhacapService: LinhacapService,
    private notify: NotifyService,
    private formbulider: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private cdr: ChangeDetectorRef
    )

    {

    this.MercadovfService.GetAll()
    .subscribe((d: Array<any>)=> {
      //this.linhacap = d;
      this.mercadovf = d;
    })
    // this.MercadoVFForm = this.formbulider.group({
	  // MercadoCAPId: [''],
		// MercadoVFId: [''],
		// Mercado_CAP: [''],
		// Mercado_VF: ['']
    // })
  }

  ngOnInit() {
    this.MercadoVFForm = this.formbulider.group({
      Linha_CAP: ['', [Validators.required]],
      //LastName: ['', [Validators.required]],
      //DateofBirth: ['', [Validators.required]],
      //EmailId: ['', [Validators.required]],
      //Gender: ['', [Validators.required]],
      //Address: ['', [Validators.required]],
      MercadoCAP: ['', [Validators.required]],
      MercadoVF: ['', [Validators.required]],
      //City: ['', [Validators.required]],
      //Pincode: ['', Validators.compose([Validators.required, Validators.pattern('[0-9]{6}')])]
    });

    this.registros = [];

    this.dropdownService.GetAll_MCAP()
    .subscribe(dados => this.mercadocaps = dados);

    //this.dropdownService.GetAll_MVF()
    //.subscribe(dados => this.mercadovfs = dados);
    //debugger;
    console.log(this.mercadovfSelecionado);

    if(this.route.snapshot.params.id > 0)
      this.Load(this.route.snapshot.params.id);
  }

  Load(id: number) : void
  {
    this.MercadovfService.GetById(id).subscribe((d) => {
      this.mercadovfSelecionado = d;
      this.LoadItems();
      debugger;
      console.log(this.mercadovfSelecionado);
    });
    this.FillMercadoCAPDDL();
  }

  LoadItems()
  {
    this.MercadoVFForm.patchValue({
  		MercadoCAPId: this.mercadovfSelecionado.MercadoCAPId,
  		MercadoVFId:  this.mercadovfSelecionado.MercadoVFId,
  		Mercado_CAP:  this.mercadovfSelecionado.Mercado_CAP,
  		Mercado_VF:   this.mercadovfSelecionado.Mercado_VF
    })
  }

  FillMercadoCAPDDL() {
    this.allMercadoCAP = this.LinhacapService.getMercadoCAP();
    this.allMercadoVF = this.MercadoVFId ;//= this.allCity = this.CityId = null;

    //console.log(this.allMercadoCAP);
    //console.log(this.allMercadoVF);
  }
  FillMercadoVFDDL(SelMercadoCAPId) {
    this.allMercadoVF = this.LinhacapService.getMercadoVF(SelMercadoCAPId.value);
    this.MercadoCAPId = SelMercadoCAPId.value;
    console.log(this.allMercadoVF);
    console.log(this.MercadoCAPId);
    //this.allCity = this.CityId = null;
  }
  FillLinhaCAPDDL(SelMercadoVFId) {
    //this.allCity = this.LinhacapService.getCity(SelMercadoVFId.value);
    this.MercadoVFId = SelMercadoVFId.value
  }
  saveNew() {
    this.MercadovfService.PostCliente(this.MercadoVFForm.value)
      .subscribe((d) => {
        this.notify.AutoAlert(d)
        this.ngOnInit();

        //this.notify.Alert(d["Status"] == "OK" ? "green" : "orange", d["Titulo"], d["Mensagem"]);

        if(d["titulo"] == "Sucesso!")
        {
          this.router.navigate(["mercadovf"]);
        }
      });
  }

  update() {
    //debugger
    this.MercadovfService.UpdateMVF(this.MercadoVFForm.value)
      .subscribe((d) => {
        this.notify.AutoAlert(d);
        this.ngOnInit();
        if(d["titulo"] == "Sucesso!")
        {
          this.router.navigate(["mercadovf"]);
        }
      });
  }

  verificaValidTouched(campo) {
   return !this.MercadoVFForm.get(campo).valid && this.MercadoVFForm.get(campo).touched;
    //return !campo.valid && campo.touched;
  }

  aplicaCssErro(campo) {
    return {
      'has-error': this.verificaValidTouched(campo),
      'has-feedback': this.verificaValidTouched(campo)
    };
  }
}

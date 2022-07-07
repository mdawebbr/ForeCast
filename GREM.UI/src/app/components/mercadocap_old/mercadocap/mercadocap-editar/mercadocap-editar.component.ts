import { MercadocapService } from 'src/app/_services/mercadocap/mercadocap.service';
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

@Component({
  selector: 'app-mercadocap-editar',
  templateUrl: './mercadocap-editar.component.html'
})
export class MercadocapEditarComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  public mercadocap: Array<any>;
  public mercadocapSelecionado: any;
  public isEdit: boolean;

  mercadocaps: any;

  paiss: any;

  //modals: Modal[];
  modals: any;

  //cidades: Cidade[];
  cidades: any;

  selectedFilter: string;
  formGroup: FormGroup;
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

		@ViewChild('MercadoCAPId', { static: false }) MercadoCAPId: ElementRef;
		@ViewChild('Mercado_CAP', { static: false }) Mercado_CAP: ElementRef;

  constructor
    (
    private MercadocapService: MercadocapService,
    private dropdownService: DropdownService,
    private notify: NotifyService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private cdr: ChangeDetectorRef
    )

    {

    this.MercadocapService.GetAll()
    .subscribe((d: Array<any>)=> {
      this.mercadocap = d;
    })
    this.formGroup = this.fb.group({
    MercadoCAPId: [''],
		Mercado_CAP: [''],
    })
  }

  ngOnInit() {

    this.registros = [];

    // this.estados = this.dropdownService.getEstadosBr();

    // this.ClienteService.getEstadosBr()
    // .subscribe(dados => this.linhacaps = dados);

    //this.dropdownService.getLinhacap()
    //.subscribe(dados => this.mercadocaps = dados);

    this.dropdownService.GetAll_MCAP()
    .subscribe(dados => this.mercadocaps = dados);

    if(this.route.snapshot.params.id > 0)
      this.Load(this.route.snapshot.params.id);
  }

  Load(id: number) : void
  {
    this.MercadocapService.GetById(id).subscribe((d) => {
      this.mercadocapSelecionado = d;
      this.LoadItems();
      console.log(this.mercadocapSelecionado);
    })
  }

  LoadItems()
  {
    this.formGroup.patchValue({
      //formControlName: This.coluna da tabela do sql
      MercadoCAPId: this.mercadocapSelecionado.MercadoCAPId,
   		Mercado_CAP: this.mercadocapSelecionado.Mercado_CAP
    })
  }

  saveNew() {
    this.MercadocapService.PostCliente(this.formGroup.value)
      .subscribe((d) => {
        this.notify.AutoAlert(d)
        this.ngOnInit();
        if(d["titulo"] == "Sucesso!")
        {
          this.router.navigate(["mercadocap"]);
        }
      });
  }

  update() {
    this.MercadocapService.UpdateCliente(this.formGroup.value)
      .subscribe((d) => {
        this.notify.AutoAlert(d);
        this.ngOnInit();
        if(d["titulo"] == "Sucesso!")
        {
          this.router.navigate(["mercadocap"]);
        }
      });
  }

  verificaValidTouched(campo) {
   return !this.formGroup.get(campo).valid && this.formGroup.get(campo).touched;
    //return !campo.valid && campo.touched;
  }

  aplicaCssErro(campo) {
    return {
      'has-error': this.verificaValidTouched(campo),
      'has-feedback': this.verificaValidTouched(campo)
    };
  }
}

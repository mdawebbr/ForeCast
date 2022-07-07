import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { MercadovfService } from '../../service/mercadovf/mercadovf.service';
import { MercadovfFC } from '../../model/mercadovf';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
//import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';
import { FormsModule,FormBuilder, Validators, FormGroup, FormArray,  FormControl, ReactiveFormsModule  } from '@angular/forms';

interface MercadoCAP {
  MercadoCAPId: string;
  Mercado_CAP: string;
}

interface MercadoVF {
  MercadoVFId: string;
  Mercado_VF: string;
  MercadoCAPId: string;
}

interface LinhaCAP {
  LinhaCAPId: string;
  Linha_CAP: string;
  MercadoVFId: string;
  MercadoCAPId: string;
}

@Component({
  selector: 'app-mercadovf',
  templateUrl: './mercadovf.component.html',
  styleUrls: ['./mercadovf.component.css']
})

export class MercadovfComponent implements OnInit {
  myForm: FormGroup;
  dataSaved = false;
  mercadovfForm: FormGroup;
  allMercadovfs: Observable<MercadovfFC[]>;              //model
  dataSource: MatTableDataSource<MercadovfFC>;           //model
  selection = new SelectionModel<MercadovfFC>(true, []); //model
  mercadovfIdUpdate = null;
  massage = null;
  allMercadoCAP: Observable<MercadoCAP[]>; //interface
  allMercadoVF: Observable<MercadoVF[]>;   //interface
  allLinhaCAP: Observable<LinhaCAP[]>;     //interface
  MercadoCAPId = null;
  MercadoVFId = null;
  LinhaCAPId = null;
  SelectedDate = null;
  //isMale = true;
  //isFeMale = false;
  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  //displayedColumns: string[] = ['select', 'Linha_CAP', 'LastName', 'DateofBirth', 'EmailId', 'Gender', 'MercadoCAP', 'MercadoVF', 'City', 'Address', 'Pincode', 'Edit', 'Delete'];
  //displayedColumns: string[] = ['select', 'Linha_CAP', 'MercadoCAP', 'MercadoVF', 'City', 'Edit', 'Delete'];
  //displayedColumns: string[] = ['select', 'Id','Nome', 'MercadoCAP', 'MercadoVF', 'LinhaCAP', 'Percentual', 'Edit', 'Delete'];
  //displayedColumns: string[] = ['select', 'Mercado_VF', 'Mercado_CAP', 'Edit', 'Delete'];
  displayedColumns: string[] = ['select', 'Mercado_VF', 'Mercado_CAP', 'Delete'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  //constructor(private formbulider: FormBuilder, private MercadovfService: MercadovfService, private _snackBar: MatSnackBar, public dialog: MatDialog) {
  constructor(
    private formbulider: FormBuilder,
    private MercadovfService: MercadovfService,
    private _snackBar: MatSnackBar)
  {
    this.MercadovfService.getAllMercadovf().subscribe(data => {
    this.dataSource = new MatTableDataSource(data);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    });
  }

  ngOnInit() {
    //debugger;

    this.mercadovfForm = this.formbulider.group({
      //Id: ['', [Validators.required]],
      //Nome: ['', [Validators.required]],
      //Mercadovf_id: ['', [Validators.required]],
      //DateofBirth: ['', [Validators.required]],
      //EmailId: ['', [Validators.required]],
      //Gender: ['', [Validators.required]],
      //Address: ['', [Validators.required]],
      Mercado_CAP: ['', [Validators.required]],
      Mercado_VF: ['', [Validators.required]],

      //Pincode: ['', Validators.compose([Validators.required, Validators.pattern('[0-9]{6}')])]
    });
    this.FillMercadoCAPDDL();

    this.MercadovfService.getAllMercadovf().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });

    //this.dataSource.paginator = this.paginator;
    //this.dataSource.sort = this.sort;
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = !!this.dataSource && this.dataSource.data.length;
    return numSelected === numRows;
  }

 /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ? this.selection.clear() : this.dataSource.data.forEach(r => this.selection.select(r));
  }
  /** The label for the checkbox on the passed row */
  checkboxLabel(row: MercadovfFC): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.MercadoVFId + 1}`;
  }

  DeleteData() {
    debugger;
    const numSelected = this.selection.selected;
    if (numSelected.length > 0) {
      if (confirm("Are you sure to delete items ")) {
        this.MercadovfService.deleteData(numSelected).subscribe(result => {
          this.SavedSuccessful(2);
          this.loadAllMercadovfs();
        })
      }
    } else {
      alert("Select at least one row");
    }
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadAllMercadovfs() {
    this.MercadovfService.getAllMercadovf().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  onFormSubmit() {
    this.dataSaved = false;
    const mercadovf = this.mercadovfForm.value;
    console.log(mercadovf);
    this.CreateMercadovf(mercadovf);
    this.mercadovfForm.reset();
  }

  loadMercadovfToEdit(mercadovfId: string) {
    this.MercadovfService.getMercadovfById(mercadovfId).subscribe(mercadovf => {
      this.massage = null;
      this.dataSaved = false;
      this.mercadovfIdUpdate = mercadovf.MercadoVFId;
      //this.mercadovfIdUpdate = mercadovf.Id;
      //this.mercadovfForm.controls['Id'].setValue(mercadovf.Id);
      //this.mercadovfForm.controls['Nome'].setValue(mercadovf.Nome);
      //this.mercadovfForm.controls['Mercadovf_id'].setValue(mercadovf.Mercadovf_id);
      this.mercadovfForm.controls['MercadoCAP'].setValue(mercadovf.MercadoCAPId);
      this.allMercadoVF = this.MercadovfService.getMercadoVF(mercadovf.MercadoCAPId);
      this.MercadoCAPId = mercadovf.MercadoCAPId;
      this.mercadovfForm.controls['Mercado_VF'].setValue(mercadovf.Mercado_VF);
      this.allLinhaCAP = this.MercadovfService.getCity(mercadovf.MercadoVFId);
      this.MercadoVFId = mercadovf.MercadoVFId;
      //this.mercadovfForm.controls['LinhaCAP'].setValue(mercadovf.LinhaCAPId);
      //this.LinhaCAPId = mercadovf.LinhaCAPId;
      //this.mercadovfForm.controls['Percentual'].setValue(mercadovf.percentual);
    });

  }
  deleteMercadovf(mercadovfId: string) {
    if (confirm("Quer realmente excluir esse registro ?")) {
      this.MercadovfService.deleteMercadovfById(mercadovfId).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(2);
        this.loadAllMercadovfs();
        this.mercadovfIdUpdate = null;
        this.mercadovfForm.reset();

      });
    }

  }
  CreateMercadovf(mercadovf: MercadovfFC) {
    //console.log(mercadovf.DateofBirth);
    if (this.mercadovfIdUpdate == null) {
      //mercadovf.Mercadovf_id = this.CodMercadovf;
      mercadovf.MercadoCAPId = this.MercadoCAPId;
      mercadovf.MercadoVFId = this.MercadoVFId;
      //mercadovf.LinhaCAPId = this.LinhaCAPId;

      this.MercadovfService.createMercadovf(mercadovf).subscribe(
        () => {
          this.dataSaved = true;
          this.SavedSuccessful(1);
          this.loadAllMercadovfs();
          this.mercadovfIdUpdate = null;
          this.mercadovfForm.reset();
        }
      );
    } else {
      //mercadovf.Mercadovf_id = this.CodMercadovf;
      mercadovf.MercadoCAPId = this.MercadoCAPId;
      mercadovf.MercadoVFId = this.MercadoVFId;
      //mercadovf.LinhaCAPId = this.LinhaCAPId;
      this.MercadovfService.updateMercadovf(mercadovf).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(0);
        this.loadAllMercadovfs();
        this.mercadovfIdUpdate = null;
        this.mercadovfForm.reset();
      });
    }
  }

  FillMercadoCAPDDL() {
    this.allMercadoCAP = this.MercadovfService.getMercadoCAP();
    this.allMercadoVF = this.MercadoVFId = this.allLinhaCAP = this.LinhaCAPId = null;
  }

  FillMercadoVFDDL(SelMercadoCAPId) {
    this.allMercadoVF = this.MercadovfService.getMercadoVF(SelMercadoCAPId.value);
    this.MercadoCAPId = SelMercadoCAPId.value;
    this.allLinhaCAP = this.LinhaCAPId = null;
  }

  FillCityDDL(SelMercadoVFId) {
    this.allLinhaCAP = this.MercadovfService.getCity(SelMercadoVFId.value);
    this.MercadoVFId = SelMercadoVFId.value
  }

  GetSelectedCity(LinhaCAP) {
    this.LinhaCAPId = LinhaCAP.value;
  }

  resetForm() {
    this.mercadovfForm.reset();
    this.massage = null;
    this.dataSaved = false;
    //this.isMale = true;
    //this.isFeMale = false;
    this.loadAllMercadovfs();
  }

  SavedSuccessful(isUpdate) {
    if (isUpdate == 0) {
      this._snackBar.open('Registro atualizado com sucesso!', 'Close', {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    }
    else if (isUpdate == 1) {
      this._snackBar.open('Registro salvo com sucesso!', 'Close', {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    }
    else if (isUpdate == 2) {
      this._snackBar.open('Registro excluido com sucesso!', 'Close', {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    }
  }
}

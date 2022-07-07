import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { MercadocapService } from '../../service/mercadocap/mercadocap.service';
import { MercadocapFC, MercadovfFC } from '../../model/mercadocap';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';


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
  selector: 'app-mercadocap',
  templateUrl: './mercadocap.component.html',
  styleUrls: ['./mercadocap.component.css']
})

export class MercadocapComponent implements OnInit {
  dataSaved = false;
  mercadocapForm: any;
  allMercadocaps: Observable<MercadocapFC[]>;
  dataSource: MatTableDataSource<MercadocapFC>;
  selection = new SelectionModel<MercadocapFC>(true, []);
  mercadocapIdUpdate = null;
  massage = null;
  allMercadoCAP: Observable<MercadoCAP[]>;
  allMercadoVF: Observable<MercadoVF[]>;
  //allCity: Observable<City[]>;
  MercadoCAPId = null;
  MercadoVFId = null;
  //CityId = null;
  SelectedDate = null;
  //isMale = true;
  //isFeMale = false;
  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';

  //displayedColumns: string[] = ['select', 'Linha_CAP', 'LastName', 'DateofBirth', 'EmailId', 'Gender', 'MercadoCAP', 'MercadoVF', 'City', 'Address', 'Pincode', 'Edit', 'Delete'];
  //displayedColumns: string[] = ['select', 'Linha_CAP', 'MercadoCAP', 'MercadoVF', 'City', 'Edit', 'Delete'];
  //displayedColumns: string[] = ['select', 'Linha_CAP', 'MercadoCAP', 'MercadoVF', 'Edit', 'Delete'];

  //                      matColumnDef    "MercadoCAPId"  "MercadoCAP" do HTML
  //displayedColumns: string[] = ['select', 'MercadoCAPId', 'Mercado_CAP', 'Edit', 'Delete'];
  displayedColumns: string[] = ['select', 'MercadoCAPId', 'Mercado_CAP', 'Delete'];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private formbulider: FormBuilder,
    private MercadocapService: MercadocapService,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog)
  {

    // displayedColumns: string[] = ['select', 'Linha_CAP', 'MercadoCAP', 'MercadoVF', 'Edit', 'Delete'];
    // @ViewChild(MatPaginator) paginator: MatPaginator;
    // @ViewChild(MatSort) sort: MatSort;

    this.MercadocapService.getAllMercadocap().subscribe(data =>
    {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });

  }

  ngOnInit() {
    this.mercadocapForm = this.formbulider.group({
      //Linha_CAP: ['', [Validators.required]],
      //LastName: ['', [Validators.required]],
      //DateofBirth: ['', [Validators.required]],
      //EmailId: ['', [Validators.required]],
      //Gender: ['', [Validators.required]],
      //Address: ['', [Validators.required]],
      Mercado_CAP: ['', [Validators.required]],
      //MercadoVF: ['', [Validators.required]],
      //City: ['', [Validators.required]],
      //Pincode: ['', Validators.compose([Validators.required, Validators.pattern('[0-9]{6}')])]
    });
    this.FillMercadoCAPDDL();
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
  checkboxLabel(row: MercadocapFC): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.MercadoCAPId + 1}`;
  }

  DeleteData() {
    //debugger;
    const numSelected = this.selection.selected;
    if (numSelected.length > 0) {
      if (confirm("Are you sure to delete items ")) {
        this.MercadocapService.deleteData(numSelected).subscribe(result => {
          this.SavedSuccessful(2);
          this.loadAllMercadocaps();
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

  loadAllMercadocaps() {
    this.MercadocapService.getAllMercadocap().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  onFormSubmit() {
    this.dataSaved = false;
    const mercadocap = this.mercadocapForm.value;
    this.CreateMercadocap(mercadocap);
    this.mercadocapForm.reset();
  }

  loadMercadocapToEdit(mercadocapId: string) {
    this.MercadocapService.getMercadocapById(mercadocapId).subscribe(mercadocap => {
      this.massage = null;
      this.dataSaved = false;
      this.mercadocapIdUpdate = mercadocap.MercadoCAPId;
      // this.mercadocapForm.controls['Linha_CAP'].setValue(mercadocap.Linha_CAP);
      //this.mercadocapForm.controls['LastName'].setValue(mercadocap.LastName);
      //this.mercadocapForm.controls['DateofBirth'].setValue(mercadocap.DateofBirth);
      //this.mercadocapForm.controls['EmailId'].setValue(mercadocap.EmailId);
      //this.mercadocapForm.controls['Gender'].setValue(mercadocap.Gender);
      //this.mercadocapForm.controls['Address'].setValue(mercadocap.Address);
      //this.mercadocapForm.controls['Pincode'].setValue(mercadocap.Pincode);
      this.mercadocapForm.controls['Mercado_CAP'].setValue(mercadocap.MercadoCAPId);
      //this.allMercadoVF = this.MercadocapService.getMercadoVF(mercadocap.MercadoCAPId);
      this.MercadoCAPId = mercadocap.MercadoCAPId;
      // this.mercadocapForm.controls['MercadoVF'].setValue(mercadocap.MercadoVFId);
      //this.allCity = this.MercadocapService.getCity(mercadocap.MercadoVFId);
      // this.MercadoVFId = mercadocap.MercadoVFId;
      //this.mercadocapForm.controls['City'].setValue(linmercadocaphacap.Cityid);
      //this.CityId = mercadocap.Cityid;
      //this.isMale = mercadocap.Gender.trim() == "0" ? true : false;
      //this.isFeMale = mercadocap.Gender.trim() == "1" ? true : false;
    });

  }
  deleteMercadocap(mercadocapId: string) {
    if (confirm("Quer realmente excluir esse registro ?")) {
      this.MercadocapService.deleteMercadocapById(mercadocapId).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(2);
        this.loadAllMercadocaps();
        this.mercadocapIdUpdate = null;
        this.mercadocapForm.reset();

      });
    }

  }
  CreateMercadocap(mercadocap: MercadocapFC) {

    if (this.mercadocapIdUpdate == null) {
      mercadocap.MercadoCAPId = this.MercadoCAPId;
      // mercadocap.MercadoVFId = this.MercadoVFId;
      //mercadocap.Cityid = this.CityId;

      this.MercadocapService.createMercadocap(mercadocap).subscribe(
        () => {
          this.dataSaved = true;
          this.SavedSuccessful(1);
          this.loadAllMercadocaps();
          this.mercadocapIdUpdate = null;
          this.mercadocapForm.reset();
        }
      );
    } else {
      mercadocap.MercadoCAPId = this.mercadocapIdUpdate;
      mercadocap.MercadoCAPId = this.MercadoCAPId;
      // mercadocap.MercadoVFId = this.MercadoVFId;
      //mercadocap.Cityid = this.CityId;
      this.MercadocapService.updateMercadocap(mercadocap).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(0);
        this.loadAllMercadocaps();
        this.mercadocapIdUpdate = null;
        this.mercadocapForm.reset();
      });
    }
  }


  FillMercadoCAPDDL() {
    this.allMercadoCAP = this.MercadocapService.getMercadoCAP();
    this.allMercadoCAP = this.MercadoCAPId ;//= this.allCity = this.CityId = null;
    console.log(this.allMercadoCAP);
    console.log(this.allMercadoVF);
  }

  FillMercadoVFDDL(SelMercadoCAPId) {
    this.allMercadoVF = this.MercadocapService.getMercadoVF(SelMercadoCAPId.value);
    this.MercadoCAPId = SelMercadoCAPId.value;
    console.log(this.allMercadoVF);
    console.log(this.MercadoCAPId);
    //this.allCity = this.CityId = null;
  }

  FillLinhaCAPDDL(SelMercadoVFId) {
    //this.allCity = this.MercadocapService.getCity(SelMercadoVFId.value);
    this.MercadoVFId = SelMercadoVFId.value
  }

  GetSelectedCity(City) {
    //this.CityId = City.value;
  }

  resetForm() {
    this.mercadocapForm.reset();
    this.massage = null;
    this.dataSaved = false;
    //this.isMale = true;
    //this.isFeMale = false;
    this.loadAllMercadocaps();
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

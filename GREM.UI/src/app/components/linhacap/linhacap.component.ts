import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { LinhacapService } from '../../service/linhacap/linhacap.service';
import { Linhacap } from '../../model/linhacap';
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
  selector: 'app-linhacap',
  templateUrl: './linhacap.component.html',
  styleUrls: ['./linhacap.component.css']
})

export class LinhacapComponent implements OnInit {
  dataSaved = false;
  linhacapForm: any;
  allLinhacaps: Observable<Linhacap[]>;
  dataSource: MatTableDataSource<Linhacap>;
  selection = new SelectionModel<Linhacap>(true, []);
  linhacapIdUpdate = null;
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

  displayedColumns: string[] = ['select', 'Linha_CAP', 'MercadoCAP', 'MercadoVF', 'Edit', 'Delete'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private formbulider: FormBuilder,
    private LinhacapService: LinhacapService,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog)
  {

    // displayedColumns: string[] = ['select', 'Linha_CAP', 'MercadoCAP', 'MercadoVF', 'Edit', 'Delete'];
    // @ViewChild(MatPaginator) paginator: MatPaginator;
    // @ViewChild(MatSort) sort: MatSort;

    this.LinhacapService.getAllLinhacap().subscribe(data =>
    {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });

  }

  ngOnInit() {
    this.linhacapForm = this.formbulider.group({
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
  checkboxLabel(row: Linhacap): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.LinhaCAPId + 1}`;
  }

  DeleteData() {
    //debugger;
    const numSelected = this.selection.selected;
    if (numSelected.length > 0) {
      if (confirm("Are you sure to delete items ")) {
        this.LinhacapService.deleteData(numSelected).subscribe(result => {
          this.SavedSuccessful(2);
          this.loadAllLinhacaps();
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

  loadAllLinhacaps() {
    this.LinhacapService.getAllLinhacap().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  onFormSubmit() {
    this.dataSaved = false;
    const linhacap = this.linhacapForm.value;
    this.CreateLinhacap(linhacap);
    this.linhacapForm.reset();
  }

  loadLinhacapToEdit(linhacapId: string) {
    this.LinhacapService.getLinhacapById(linhacapId).subscribe(linhacap => {
      this.massage = null;
      this.dataSaved = false;
      this.linhacapIdUpdate = linhacap.LinhaCAPId;
      this.linhacapForm.controls['Linha_CAP'].setValue(linhacap.Linha_CAP);
      //this.linhacapForm.controls['LastName'].setValue(linhacap.LastName);
      //this.linhacapForm.controls['DateofBirth'].setValue(linhacap.DateofBirth);
      //this.linhacapForm.controls['EmailId'].setValue(linhacap.EmailId);
      //this.linhacapForm.controls['Gender'].setValue(linhacap.Gender);
      //this.linhacapForm.controls['Address'].setValue(linhacap.Address);
      //this.linhacapForm.controls['Pincode'].setValue(linhacap.Pincode);
      this.linhacapForm.controls['MercadoCAP'].setValue(linhacap.MercadoCAPId);
      this.allMercadoVF = this.LinhacapService.getMercadoVF(linhacap.MercadoCAPId);
      this.MercadoCAPId = linhacap.MercadoCAPId;
      this.linhacapForm.controls['MercadoVF'].setValue(linhacap.MercadoVFId);
      //this.allCity = this.LinhacapService.getCity(linhacap.MercadoVFId);
      this.MercadoVFId = linhacap.MercadoVFId;
      //this.linhacapForm.controls['City'].setValue(linhacap.Cityid);
      //this.CityId = linhacap.Cityid;
      //this.isMale = linhacap.Gender.trim() == "0" ? true : false;
      //this.isFeMale = linhacap.Gender.trim() == "1" ? true : false;
    });

  }
  deleteLinhacap(linhacapId: string) {
    if (confirm("Quer realmente excluir esse registro ?")) {
      this.LinhacapService.deleteLinhacapById(linhacapId).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(2);
        this.loadAllLinhacaps();
        this.linhacapIdUpdate = null;
        this.linhacapForm.reset();

      });
    }

  }
  CreateLinhacap(linhacap: Linhacap) {
    //console.log(linhacap.DateofBirth);
    if (this.linhacapIdUpdate == null) {
      linhacap.MercadoCAPId = this.MercadoCAPId;
      linhacap.MercadoVFId = this.MercadoVFId;
      //linhacap.Cityid = this.CityId;

      this.LinhacapService.createLinhacap(linhacap).subscribe(
        () => {
          this.dataSaved = true;
          this.SavedSuccessful(1);
          this.loadAllLinhacaps();
          this.linhacapIdUpdate = null;
          this.linhacapForm.reset();
        }
      );
    } else {
      linhacap.LinhaCAPId = this.linhacapIdUpdate;
      linhacap.MercadoCAPId = this.MercadoCAPId;
      linhacap.MercadoVFId = this.MercadoVFId;
      //linhacap.Cityid = this.CityId;
      this.LinhacapService.updateLinhacap(linhacap).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(0);
        this.loadAllLinhacaps();
        this.linhacapIdUpdate = null;
        this.linhacapForm.reset();
      });
    }
  }


  FillMercadoCAPDDL() {
    this.allMercadoCAP = this.LinhacapService.getMercadoCAP();
    this.allMercadoVF = this.MercadoVFId ;//= this.allCity = this.CityId = null;
    console.log(this.allMercadoCAP);
    console.log(this.allMercadoVF);
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

  GetSelectedCity(City) {
    //this.CityId = City.value;
  }

  resetForm() {
    this.linhacapForm.reset();
    this.massage = null;
    this.dataSaved = false;
    //this.isMale = true;
    //this.isFeMale = false;
    this.loadAllLinhacaps();
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

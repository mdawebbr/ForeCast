import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CadastrousuarioService } from  '../../service/cadastrousuario/cadastrousuario.service';
import { Cadastrousuario } from '../../model/Cadastrousuario';
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

interface Usuario {
  Id: string;
  Usuario: string;
  Email: string;
  Password: string;
  IsAdmin: string;
}

@Component({
  selector: 'app-cadastrousuario',
  templateUrl: './cadastrousuario.component.html',
  styleUrls: ['./cadastrousuario.component.css']
})
export class CadastrousuarioComponent implements OnInit {
  dataSaved = false;
  cadastrouserForm: any;
  allCadastrousuarios: Observable<Cadastrousuario[]>;
  dataSource: MatTableDataSource<Cadastrousuario>;
  selection = new SelectionModel<Cadastrousuario>(true, []);
  cadastrousuarioIdUpdate = null;
  massage = null;

  allMercadoCAP: Observable<MercadoCAP[]>;
  allMercadoVF: Observable<MercadoVF[]>;
  
  
  Email = null;
  Password = null;
  IsAdmin = null;
  
  SelectedDate = null;
  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  displayedColumns: string[] = ['select', 'Usuario', 'Email', 'Password', 'IsAdmin', 'Edit', 'Delete'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private formbulider: FormBuilder,
    private CadastrousuarioService: CadastrousuarioService,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog)
  {

    this.CadastrousuarioService.getAllCadastrousuario().subscribe(data =>
    {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });

  }

  ngOnInit() {
    this.cadastrouserForm = this.formbulider.group({
      Usuario: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
      IsAdmin: ['', [Validators.required]]
    });

    //this.FillMercadoCAPDDL();
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
  checkboxLabel(row: Cadastrousuario): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.Id + 1}`;
  }

  DeleteData() {
    //debugger;
    const numSelected = this.selection.selected;
    if (numSelected.length > 0) {
      if (confirm("Are you sure to delete items ")) {
        this.CadastrousuarioService.deleteData(numSelected).subscribe(result => {
          this.SavedSuccessful(2);
          this.loadAllCadastrousuario();
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

  loadAllCadastrousuario() {
    this.CadastrousuarioService.getAllCadastrousuario().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  onFormSubmit() {
    this.dataSaved = false;
    const cadastrousuario = this.cadastrouserForm.value;
    this.CreateCadastrousuario(cadastrousuario);
    this.cadastrouserForm.reset();
  }

  loadcadastroUsuarioToEdit(linhacapId: string) {
    this.CadastrousuarioService.getCadastrousuarioById(linhacapId).subscribe(cadastrousuario => {
      this.massage = null;
      this.dataSaved = false;
      this.cadastrousuarioIdUpdate = cadastrousuario.Id;
      this.cadastrouserForm.controls['Usuario'].setValue(cadastrousuario.Usuario);
      this.cadastrouserForm.controls['Email'].setValue(cadastrousuario.Email);
      this.cadastrouserForm.controls['Password'].setValue(cadastrousuario.Password);

    });

  }
  deletecadastroUsuario(linhacapId: string) {
    if (confirm("Quer realmente excluir esse registro ?")) {
      this.CadastrousuarioService.deleteCadastrousuarioById(linhacapId).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(2);
        this.loadAllCadastrousuario();
        this.cadastrousuarioIdUpdate = null;
        this.cadastrouserForm.reset();

      });
    }

  }
  CreateCadastrousuario(cadastrousuario: Cadastrousuario) {
    //console.log(linhacap.DateofBirth);
    if (this.cadastrousuarioIdUpdate == null) {
      cadastrousuario.Email = this.Email;
      cadastrousuario.Password = this.Password;

      this.CadastrousuarioService.createCadastrousuario(cadastrousuario).subscribe(
        () => {
          this.dataSaved = true;
          this.SavedSuccessful(1);
          this.loadAllCadastrousuario();
          this.cadastrousuarioIdUpdate = null;
          this.cadastrouserForm.reset();
        }
      );
    } else {
      cadastrousuario.Id = this.cadastrousuarioIdUpdate;
      cadastrousuario.Email = this.Email;
      cadastrousuario.Password = this.Password;
      //linhacap.Cityid = this.CityId;
      this.CadastrousuarioService.updateCadastrousuario(cadastrousuario).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(0);
        this.loadAllCadastrousuario();
        this.cadastrousuarioIdUpdate = null;
        this.cadastrouserForm.reset();
      });
    }
  }


  // FillMercadoCAPDDL() {
  //   this.allMercadoCAP = this.CadastrousuarioService.getMercadoCAP();
  //   this.allMercadoVF = this.MercadoVFId ;//= this.allCity = this.CityId = null;
  //   console.log(this.allMercadoCAP);
  //   console.log(this.allMercadoVF);
  // }

  // FillMercadoVFDDL(SelMercadoCAPId) {
  //   this.allMercadoVF = this.CadastrousuarioService.getMercadoVF(SelMercadoCAPId.value);
  //   this.MercadoCAPId = SelMercadoCAPId.value;
  //   console.log(this.allMercadoVF);
  //   console.log(this.MercadoCAPId);
  //   //this.allCity = this.CityId = null;
  // }

  // FillLinhaCAPDDL(SelMercadoVFId) {
  //   //this.allCity = this.LinhacapService.getCity(SelMercadoVFId.value);
  //   this.MercadoVFId = SelMercadoVFId.value
  // }

  GetSelectedCity(City) {
    //this.CityId = City.value;
  }

  resetForm() {
    this.cadastrouserForm.reset();
    this.massage = null;
    this.dataSaved = false;
    //this.isMale = true;
    //this.isFeMale = false;
    this.loadAllCadastrousuario();
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

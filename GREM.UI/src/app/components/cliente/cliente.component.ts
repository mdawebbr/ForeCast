import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { ClienteService } from '../../service/cliente/cliente.service';
import { ClienteFC } from '../../model/cliente';
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
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})

export class ClienteComponent implements OnInit {
  myForm: FormGroup;
  dataSaved = false;
  clienteForm: FormGroup;
  allClientes: Observable<ClienteFC[]>;
  dataSource: MatTableDataSource<ClienteFC>;
  selection = new SelectionModel<ClienteFC>(true, []);
  clienteIdUpdate = null;
  massage = null;
  allMercadoCAP: Observable<MercadoCAP[]>;
  allMercadoVF: Observable<MercadoVF[]>;
  allLinhaCAP: Observable<LinhaCAP[]>;
  Cliente_id = null;
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
  
  displayedColumns: string[] = ['select', 'Nome', 'MercadoCAP', 'MercadoVF', 'LinhaCAP', 'Percentual', 'Porcentagem_Protocolo',  'Volume_Protocolo', 'Tonelada_Protocolo', 'Edit', 'Delete'];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  //constructor(private formbulider: FormBuilder, private ClienteService: ClienteService, private _snackBar: MatSnackBar, public dialog: MatDialog) {
  constructor(private formbulider: FormBuilder, private ClienteService: ClienteService, private _snackBar: MatSnackBar) {
    this.ClienteService.getAllCliente().subscribe(data => {
    this.dataSource = new MatTableDataSource(data);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    });
  }

  ngOnInit() {
    this.clienteForm = this.formbulider.group({
      Id: ['', [Validators.required]],
      Nome: ['', [Validators.required]],
      Cliente_id: ['', [Validators.required]],
      //DateofBirth: ['', [Validators.required]],
      //EmailId: ['', [Validators.required]],
      //Gender: ['', [Validators.required]],
      //Address: ['', [Validators.required]],
      MercadoCAP: ['', [Validators.required]],
      MercadoVF: ['', [Validators.required]],
      LinhaCAP: ['', [Validators.required]],
      Percentual: ['', [Validators.required]],
      Porcentagem_Protocolo: ['', [Validators.required]],
      Volume_Protocolo: ['', [Validators.required]],
      Tonelada_Protocolo: ['', [Validators.required]],
      //Pincode: ['', Validators.compose([Validators.required, Validators.pattern('[0-9]{6}')])]
    });
    this.FillMercadoCAPDDL();
    this.ClienteService.getAllCliente().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  loadClienteToEdit(clienteId: string) {
    this.ClienteService.getClienteById(clienteId).subscribe(cliente => {
      this.massage = null;
      this.dataSaved = false;
      //this.clienteIdUpdate = cliente.Cliente_id;
      this.clienteIdUpdate = cliente.Id;
      //this.clienteForm.controls['Id'].setValue(cliente.Id);
      this.clienteForm.controls['Nome'].setValue(cliente.Nome);
      this.clienteForm.controls['Cliente_id'].setValue(cliente.Cliente_id);
      this.clienteForm.controls['MercadoCAP'].setValue(cliente.MercadoCAPId);
      this.allMercadoVF = this.ClienteService.getMercadoVF(cliente.MercadoCAPId);
      this.MercadoCAPId = cliente.MercadoCAPId;
      this.clienteForm.controls['MercadoVF'].setValue(cliente.MercadoVFId);
      this.allLinhaCAP = this.ClienteService.getCity(cliente.MercadoVFId);
      this.MercadoVFId = cliente.MercadoVFId;
      this.clienteForm.controls['LinhaCAP'].setValue(cliente.LinhaCAPId);
      this.LinhaCAPId = cliente.LinhaCAPId;
      this.clienteForm.controls['Percentual'].setValue(cliente.percentual);
      this.clienteForm.controls['Porcentagem_Protocolo'].setValue(cliente.porcentagem_protocolo);
      this.clienteForm.controls['Volume_Protocolo'].setValue(cliente.volume_protocolo);
      this.clienteForm.controls['Tonelada_Protocolo'].setValue(cliente.tonelada_protocolo);
    });
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
  checkboxLabel(row: ClienteFC): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.Cliente_id + 1}`;
  }

  DeleteData() {
    debugger;
    const numSelected = this.selection.selected;
    if (numSelected.length > 0) {
      if (confirm("Are you sure to delete items ")) {
        this.ClienteService.deleteData(numSelected).subscribe(result => {
          this.SavedSuccessful(2);
          this.loadAllClientes();
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

  loadAllClientes() {
    this.ClienteService.getAllCliente().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  onFormSubmit() {
    this.dataSaved = false;
    const cliente = this.clienteForm.value;
    console.log(cliente);
    this.CreateCliente(cliente);
    this.clienteForm.reset();
  }

  deleteCliente(clienteId: string) {
    if (confirm("Quer realmente excluir esse registro ?")) {
      this.ClienteService.deleteClienteById(clienteId).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(2);
        this.loadAllClientes();
        this.clienteIdUpdate = null;
        this.clienteForm.reset();

      });
    }

  }
  CreateCliente(cliente: ClienteFC) {
    //console.log(cliente.DateofBirth);
    if (this.clienteIdUpdate == null) {
      //cliente.Cliente_id = this.CodCliente;
      cliente.MercadoCAPId = this.MercadoCAPId;
      cliente.MercadoVFId = this.MercadoVFId;
      cliente.LinhaCAPId = this.LinhaCAPId;

      this.ClienteService.createCliente(cliente).subscribe(
        () => {
          this.dataSaved = true;
          this.SavedSuccessful(1);
          this.loadAllClientes();
          this.clienteIdUpdate = null;
          this.clienteForm.reset();
        }
      );
    } else {
      //cliente.Cliente_id = this.CodCliente;
      cliente.MercadoCAPId = this.MercadoCAPId;
      cliente.MercadoVFId = this.MercadoVFId;
      cliente.LinhaCAPId = this.LinhaCAPId;
      this.ClienteService.updateCliente(cliente).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(0);
        this.loadAllClientes();
        this.clienteIdUpdate = null;
        this.clienteForm.reset();
      });
    }
  }

  FillMercadoCAPDDL() {
    this.allMercadoCAP = this.ClienteService.getMercadoCAP();
    this.allMercadoVF = this.MercadoVFId = this.allLinhaCAP = this.LinhaCAPId = null;
  }

  FillMercadoVFDDL(SelMercadoCAPId) {
    this.allMercadoVF = this.ClienteService.getMercadoVF(SelMercadoCAPId.value);
    this.MercadoCAPId = SelMercadoCAPId.value;
    this.allLinhaCAP = this.LinhaCAPId = null;
  }

  FillCityDDL(SelMercadoVFId) {
    this.allLinhaCAP = this.ClienteService.getCity(SelMercadoVFId.value);
    this.MercadoVFId = SelMercadoVFId.value
  }

  GetSelectedCity(LinhaCAP) {
    this.LinhaCAPId = LinhaCAP.value;
  }

  resetForm() {
    this.clienteForm.reset();
    this.massage = null;
    this.dataSaved = false;
    //this.isMale = true;
    //this.isFeMale = false;
    this.loadAllClientes();
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

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DropdownSettings } from 'angular2-multiselect-dropdown/lib/multiselect.interface';

@Component({
  selector: 'app-multiselect',
  templateUrl: './multiselect.component.html',
  styleUrls: ['./multiselect.component.css']
})
export class MultiselectComponent implements OnInit {

  @Input('itensCombo') itensCombo: Array<any>;
  @Input('dataModel') dataModel: Array<any>;

  @Output('retorno') retorno = new EventEmitter<Object>();

  constructor() { }

  selectedItems = [];
  dropdownSettings: DropdownSettings = {
    singleSelection: false,
    text: "Selecione...",
    selectAllText: 'Selecionar Todos',
    unSelectAllText: 'Desfazer',
    enableSearchFilter: true,
    classes: "form-control p-0 font-combo",
    filterSelectAllText: "Selecionar pelo filtro.",
    filterUnSelectAllText: "Desfazer.",
    searchPlaceholderText: "Buscar",
    badgeShowLimit: 3,
    enableCheckAll: true,
    enableFilterSelectAll: false,
    searchBy: [],
    noDataLabel: "Não há valores disponíveis.",
    maxHeight: 300,
    position: "bottom",
    primaryKey: "id"
  };

  ngOnInit() {
  }

  emitter() {
    this.retorno.emit(this.dataModel);
  }

  onItemSelect(item: any) {
  }
  OnItemDeSelect(item: any) {
  }
  onSelectAll(items: any) {
  }
  onDeSelectAll(items: any) {
  }

}

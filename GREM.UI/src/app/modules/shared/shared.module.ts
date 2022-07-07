import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { RichtexteditorComponent } from './richtexteditor/richtexteditor.component';
import { DragndropComponent } from './dragndrop/dragndrop.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MultiselectComponent } from './multiselect/multiselect.component';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { ModalComponent } from './modal/modal.component';
import { TimescheduleComponent } from './timeschedule/timeschedule.component';
import { DropdownService } from '../../shared/services/dropdown.service';
import { RouterModule } from '@angular/router';
@NgModule({
  imports: [
    NgxPaginationModule,
    FormsModule,
    CommonModule,
    DragDropModule,
    AngularMultiSelectModule,
    RouterModule
    
  ],
  declarations: [
    RichtexteditorComponent, 
    DragndropComponent, 
    MultiselectComponent, 
    ModalComponent, 
    TimescheduleComponent

  ],
  exports: [
    MultiselectComponent,
    ModalComponent,
    TimescheduleComponent

  ],
  providers:[DropdownService]
})
export class SharedModule { }

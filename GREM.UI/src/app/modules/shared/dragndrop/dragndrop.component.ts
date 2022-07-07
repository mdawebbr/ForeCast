import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-dragndrop',
  templateUrl: './dragndrop.component.html',
  styleUrls: ['./dragndrop.component.css']
})
export class DragndropComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  list1 = [
    'Pedra', 'Cimento', 'Sucata', 'Piche', 'Metal'
  ]
  list2 = [
  ]

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer !== event.container) {
      transferArrayItem(event.previousContainer.data, event.container.data, event.previousIndex, event.currentIndex)
    }
  }

}

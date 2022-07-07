import { Component, OnInit, Input } from '@angular/core';

declare var $: any;

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

  @Input('ControlPoints') ControlPoints: Array<any>;
  imgUrl: string = "";

  ar = [
    "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTEuNDKDPut35-xQhBt6qPbLFE3UpUOpyICZFJngkrwyInCfh0U",
    "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQH_pZwM39MgKCEueThNEhsPp229yJQJeOnGYYJexqjLG8bMjGH"
  ]

  tmpArGroupControlPoints: Array<number> = [];
  constructor() {
  }
  
  ngOnInit() {
  }

  getImage() {
    this.imgUrl = this.ar[Math.floor(Math.random() * 2)];
    $("#modalExemplo").modal();
  }
}

import { Component, OnInit, Input } from '@angular/core';
import { NotifyService } from '../../utilities/notify.service';
import { ParametersService } from 'src/app/_services/parameters/parameters.service';

@Component({
  selector: 'app-parameter',
  templateUrl: './parameter.component.html',
  styleUrls: ['./parameter.component.css']
})
export class ParameterComponent implements OnInit {

  constructor(private notify: NotifyService, private params: ParametersService) { }

  telaAtual: string;

  ngOnInit() {
  }

  setTelaAtual(mensagem: string) : void {
    this.telaAtual = mensagem;
    console.log(this.telaAtual);
  }


  
}

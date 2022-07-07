import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserUtil } from '../../userUtil/userUtil';
import { NotifyService } from '../../modules/utilities/notify.service';
import { environment } from 'src/environments/environment';

declare var $: any;
var obj: any;

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  constructor(private route: ActivatedRoute, private user: UserUtil, private notify: NotifyService, private redirect: Router) {
     
  }

  currentUser: any;
  ambiente: String;

  usuarioNome: string;
  usuarioEmail: string;
  urlAtual = '';
  
  alterarUsuarioLink: string;

  operations: string[] = [];
  profiles:string[] = [];

  resultado: Promise<any>;

  getInfoUsuario() {
    if(this.resultado == null) {

      
    }
  }

  ngOnInit() {
    //this.getInfoUsuario();
    this.ambiente = environment.ambiente;
    this.urlAtual = window.location.pathname;

    $(document).ready(() => {
      $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
      });
    })

    $(function () {
      $('[data-toggle="tooltip"]').tooltip()
    })
  }

  Logout() {
    this.notify.PromptConfirm('Deseja sair?', 'Você confirma o logout?', () => {
      setTimeout(() => {
        this.user.Logout();
        // this.redirect.navigate(['/acessonegado'])
      })
    })
  }

  get Username() {
    var usuario = "Carregando..."
    if(this.usuarioNome != null)
      usuario = `${this.usuarioNome.split(' ')[0]} ${this.usuarioNome.split(' ')[this.usuarioNome.split(' ').length - 1]}`;
      var index = usuario.indexOf(" ");
      usuario = usuario.substr(0,index);
    return usuario;
  }
}

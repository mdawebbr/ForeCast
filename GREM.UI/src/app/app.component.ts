import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserUtil } from './userUtil/userUtil';
import { NotifyService } from './modules/utilities/notify.service';
import { BnNgIdleService } from 'bn-ng-idle';
import { ParametersService } from './_services/parameters/parameters.service';
import { NgxSpinnerModule } from 'ngx-spinner';
import { environment } from 'src/environments/environment';

declare var $: any;
var obj: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'ForeCast Upload';
  //title = 'upload-arquivos';
  constructor(private params: ParametersService, private route: ActivatedRoute, private user: UserUtil, private notify: NotifyService, private nav: Router, private bnIdle: BnNgIdleService) {
    obj = route;

    // this.params.GetTimeout()
    //   .subscribe((d) => {
    //     this.bnIdle.startWatching(parseInt(d))
    //       .subscribe((res) => {
    //         if(res)
    //           this.user.Logout();
    //           this.notify.Confirm("orange", "Desconectado!", "Você foi desconectado por inatividade.", () => {
    //             window.location.href = this.apicfg.urlLoginRedirect;
    //           })
    //       })
    //   })
  }

  urlAtual = '';
  isDisconnected: boolean = false;

  doLogin: boolean = false;
  teste: boolean = false;
  trocaSenha: boolean = false;

  ngOnInit() {

    this.trocaSenha = false;
    this.urlAtual = window.location.pathname;

    if(window.location.href.includes("TrocarSenha"))
    {
      this.trocaSenha = true;
    }

    this.isDisconnected = false;
    this.user.unsetRegister();
  }

  TesteBabi() {
    window.location.href = environment.rootUrl;
  }

  GoLogin() {
    // window.location.href = '/login';
    this.nav.navigate(['/login']);
  }

  SessionTimeout() {
    //new Promise((resolve, reject) => {
     // setTimeout(() => {
     //   this.user.DestroySession();
    //    resolve();
    //  }, this.apicfg.timeSession)
   // })
   // .then(() => {
     // this.isDisconnected = true;
  //  })
  }
}

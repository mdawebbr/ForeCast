import { NgModule, Injectable } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpResponse, HttpEvent, HTTP_INTERCEPTORS, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { UserUtil } from '../userUtil/userUtil';
import { retry, catchError, map, tap, finalize } from 'rxjs/operators';
import { Router,RouterModule } from '@angular/router';
import { NotifyService } from '../modules/utilities/notify.service';
import { NgxSpinnerService, NgxSpinnerModule } from 'ngx-spinner';


declare var $: any;

@Injectable()
@NgModule({
  declarations: [],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthenticationModule,
    multi: true,
  }],
  imports: [
    CommonModule,
    NgxSpinnerModule,
    RouterModule
  ]
})
export class AuthenticationModule implements HttpInterceptor {

  constructor(private usu: UserUtil, private route: Router, private notify: NotifyService, private spinner: NgxSpinnerService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const dupReq = req.clone({
      setHeaders: {
        Authorization: `Basic ${this.usu.getUsuario()}`,
        'Content-Type': "application/json",
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Credentials': 'true',
        'Access-Control-Allow-Headers': 'Content-Type',
        'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE',
        'key': 'x-api-key'
      }
    });

    this.spinner.show();

    return next.handle(dupReq).pipe(
      // retry(2),
      catchError((error) => {
        if(error instanceof HttpErrorResponse) {
          if(error.status === 401) {
            this.route.navigate(['acessonegado']);
          } else 
            this.notify.Alert('orange', 'Erro!', 'Não foi possível conectar o recurso solicitado... Tente novamente mais tarde!');
        }
        return throwError(error)
      }),
      finalize(() => this.spinner.hide())
    );
  }
}
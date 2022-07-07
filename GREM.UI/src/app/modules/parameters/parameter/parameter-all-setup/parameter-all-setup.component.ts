import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { NotifyService } from 'src/app/modules/utilities/notify.service';
import { ParametersService } from './../../../../_services/parameters/parameters.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-parameter-all-setup',
  templateUrl: './parameter-all-setup.component.html',
  styleUrls: ['./parameter-all-setup.component.css']
})
export class ParameterAllSetupComponent implements OnInit {

  constructor(private fb: FormBuilder, private params: ParametersService, private notify: NotifyService) { }
 

  caminhaoParam: any;
  navioParam: any;
  tremParam: any;
  
  ngOnInit() {


    this.params.Get(3)
    .subscribe(d=> {
      this.navioParam = d;
    });
    this.params.Get(2)
    .subscribe(d=> {
      this.caminhaoParam = d;
    })
    this.params.Get(1)
    .subscribe(d=> {
      this.tremParam = d;
    })
  }


  updateCaminhao(el: string) {
    this.params.UpdateLimiteCaminhao(el)
      .subscribe(d=> {
        this.ngOnInit();
        this.notify.Alert("green", d["titulo"], d["mensagem"])
      });
  }

  updateNavio(el: string) {
    this.params.UpdateLimiteNavio(el)
      .subscribe(d=> {
        this.ngOnInit();
        this.notify.Alert("green", d["titulo"], d["mensagem"])
      });
  }

  updateTrem(el: string) {
    this.params.UpdateLimiteTrem(el)
      .subscribe(d=> {
        this.ngOnInit();
        this.notify.Alert("green", d["titulo"], d["mensagem"])
      });
  }



}

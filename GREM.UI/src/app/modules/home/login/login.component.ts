import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from './service.service';
import { NotifyService } from '../../utilities/notify.service';

declare var $: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  registerForm: FormGroup;
  submitted = false;

  tituloEmpresa: string;

  constructor(private formBuilder: FormBuilder, private service: ServiceService, private notify: NotifyService) { }

  ngOnInit() {
    this.tituloEmpresa = '';
    this.registerForm = this.formBuilder.group({
      CnpjEmpresa: ['', Validators.required],
      Nome: ['', Validators.required],
      Email: ['', Validators.required],
      Telefone: ['', Validators.required],
      CPF: ['', Validators.required]
    });

    $("#transportador").click(() => {
      $("#fornecedor").removeClass("border border-success");
      $("#transportador").addClass("border border-success");
      $("#tipoCadastro").text("Transportador");
    })

    $("#fornecedor").click(() => {
      $("#transportador").removeClass("border border-success");
      $("#fornecedor").addClass("border border-success");
      $("#tipoCadastro").text("Fornecedor");
    })
  }

  ConsultaCnpj() {
    var cnpj = $(".txtcnpj")[0].value;
    this.service.GetEmpresa(cnpj)
      .subscribe(d=> {
        if(d != null)
          this.tituloEmpresa = d.toString();
        else
          this.notify.Alert('orange', 'Não encontrado!', 'A empresa referente a este CNPJ não possui vinculos de transporte com a Ternium.')
      })
  }

  SubmitTest() {
    var tipoCadastro = $("#fornecedor").hasClass("border-success") == true ? 'Fornecedor' : 'Transportador';

    $.confirm({
      title: `Olá, ${tipoCadastro}`,
      content: 'Você confirma a criação deste usuário?',
      type: 'green',
      buttons: {
        confirmar: {
          title: "Confirmar",
          action: () => {
            this.service.Post(this.registerForm.value);
          }
        },
        cancelar: {
          title: "Cancelar",
          action: () => {
          }
        } 
      }
    })
  }

}

import { Injectable } from '@angular/core';

declare var $: any;

@Injectable({
  providedIn: 'root'
})

export class NotifyService {

  constructor() { }

  Confirm(tipo, titulo, mensagem, confirm) {
    $.confirm({
      title: titulo,
      type: tipo,
      content: mensagem,
      buttons: {
          confirmar: {
            text: "Confirmar",
            action: confirm
          }
        }
    });
  }

  Prompt(titulo, mensagem, func) {
    $.confirm({
      title: titulo,
      content: '' +
      '<form action="" class="formName">' +
      '<div class="form-group">' +
      `<label>${mensagem}</label>` +
      '<input type="text" class="result form-control" required />' +
      '</div>' +
      '</form>',
      buttons: {
          formSubmit: {
              text: 'Salvar',
              btnClass: 'btn-blue',
              action: function () {
                func(this.$content.find('.result').val());
              }
          },
          cancel: {
            text: 'Cancelar'
          }
      },
      onContentReady: function () {
          // bind to events
          var jc = this;
          this.$content.find('form').on('submit', function (e) {
              // if the user submits the form by pressing enter in the field.
              e.preventDefault();
              jc.$$formSubmit.trigger('click'); // reference the button and click it
          });
      }
  });
  }

  PromptConfirm(titulo, mensagem, func) {
    $.confirm({
      title: titulo,
      content: '' +
      '<form action="" class="formName">' +
      '<div class="form-group">' +
      `<label>${mensagem}</label>` +
      '</div>' +
      '</form>',
      buttons: {
          formSubmit: {
              text: 'Confirmar',
              btnClass: 'btn-blue',
              action: function () {
                func(this.$content.find('.result').val());
              }
          },
          cancel: {
            text: 'Cancelar'
          }
      },
      onContentReady: function () {
          // bind to events
          var jc = this;
          this.$content.find('form').on('submit', function (e) {
              // if the user submits the form by pressing enter in the field.
              e.preventDefault();
              jc.$$formSubmit.trigger('click'); // reference the button and click it
          });
      }
  });
  }

  PromptConfirmOk(titulo, mensagem, func) {
    $.confirm({
      title: titulo,
      content: '' +
      '<form action="" class="formName">' +
      '<div class="form-group">' +
      `<label>${mensagem}</label>` +
      '</div>' +
      '</form>',
      buttons: {
          formSubmit: {
              text: 'Ok',
              btnClass: 'btn-green',
              action: function () {
                func(this.$content.find('.result').val());
              }
          }
      },
      onContentReady: function () {
          // bind to events
          var jc = this;
          this.$content.find('form').on('submit', function (e) {
              // if the user submits the form by pressing enter in the field.
              e.preventDefault();
              jc.$$formSubmit.trigger('click'); // reference the button and click it
          });
      }
  });
  }

  PromptGeneric(titulo, mensagem, func, savelbl, cancelbl) {
    $.confirm({
      title: titulo,
      content: '' +
      '<form action="" class="formName">' +
      '<div class="form-group">' +
      `<label>${mensagem}</label>` +
      '<input type="text" class="result form-control" required />' +
      '</div>' +
      '</form>',
      buttons: {
          formSubmit: {
              text: savelbl,
              btnClass: 'btn-blue',
              action: function () {
                func(this.$content.find('.result').val());
              }
          },
          cancel: {
            text: cancelbl
          }
      },
      onContentReady: function () {
          // bind to events
          var jc = this;
          this.$content.find('form').on('submit', function (e) {
              // if the user submits the form by pressing enter in the field.
              e.preventDefault();
              jc.$$formSubmit.trigger('click'); // reference the button and click it
          });
      }
  });
  }

  Alert(tipo, titulo, mensagem) {
    $.alert({
      title: titulo,
      content: mensagem,
      type: tipo
    });
  }

  AutoAlert(obj: any) {
    this.Alert(obj.type, obj.titulo, obj.mensagem);
  }
}

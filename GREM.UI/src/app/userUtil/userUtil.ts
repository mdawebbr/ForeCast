import { Injectable } from '@angular/core';
import { User } from '../../model/User';
import { NotifyService } from '../modules/utilities/notify.service';
import { environment } from 'src/environments/environment';

declare var $: any;

@Injectable({
    providedIn: 'root'
})

export class UserUtil {

    constructor(private notify: NotifyService) {
    }

    setUsuario(obj) {

        var usuario: User = {
            Senha: obj["Password"],
            Login: obj["UserIdentity"]
        }

        var item = `${usuario.Login}:${usuario.Senha}:${environment.rootUrl}`
        
        item.replace('/', '')
        item.replace('-', '')
        item.replace('.', '')


        localStorage.setItem('currentUser', btoa(item));

        this.unsetRegister();
    }

    setRegister()
    {
        localStorage.setItem('teste', 'true');
    }

    unsetRegister()
    {
        localStorage.removeItem('teste');
    }

    UpdatePassword(obj: string) {
        var atual = atob(localStorage.getItem('currentUser'));
        var pwd = atual.split(':');
        pwd[1] = obj;

        this.setUsuario({
            UserIdentity: pwd[0],
            Password: pwd[1]
        });
    }


    Logout() {
        localStorage.removeItem('currentUser');
    }

    DestroySession() {
        localStorage.removeItem('currentUser');
    }

    getUsuario() {
        if(localStorage.getItem('currentUser') != null)
            return localStorage.getItem('currentUser');
            
        return null;
    }
}
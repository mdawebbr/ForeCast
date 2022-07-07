import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserUtil } from '../userUtil/userUtil';


@Injectable({
  providedIn: 'root'
})
export class AuthguardService implements CanActivate {

  constructor(
    private router: Router,
    private authenticationService: UserUtil
) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
      return false;
    }


}

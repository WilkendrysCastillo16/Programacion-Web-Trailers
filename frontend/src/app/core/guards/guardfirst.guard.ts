import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuardfirstGuard implements CanActivate {
  //este constructor hara posible 
  constructor (private router:Router){
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let permiso = true;
    if(!permiso){
      this.router.navigate(['login'])
    }
    return permiso;
      //this.router.navigate(['login'])//si esta protegido y no tiene acceso lo mandara a login
      //return false;//si esta verdadero permitira la entrada si esta falso no
  }
  
}

import { Injectable } from '@angular/core';
import {CanActivate, Router} from '@angular/router';
import { AlertifyService } from '../_Services/alertify.service';
import { AuthService } from '../_Services/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private alertifyjs: AlertifyService) { }

  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertifyjs.error('You are not LoggedIn !!!');
    this.router.navigate(['/home']);
    return false;
  }
  
}

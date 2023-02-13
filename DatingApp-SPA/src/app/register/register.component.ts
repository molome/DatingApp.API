import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AlertifyService } from '../_Services/alertify.service';
import { AuthService } from '../_Services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  /*@Input() valuesFromHome: any;*/

  @Output() cancelRegister = new EventEmitter();

  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Registered user successfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
    //this.alertify.message('Cancelled');
  }
}

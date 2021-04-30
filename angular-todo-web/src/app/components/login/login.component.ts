import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from "@angular/forms";
import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router";
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authSrv: AuthService, private router: Router, private snackBar: SnackBarService) { }

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required, Validators.min(4)])

  getEmailErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Debes ingresar un email';
    }

    return this.email.hasError('email') ? 'Email no válido' : '';
  }
  getPasswordErrorMessage() {
    if (this.password.hasError('required')) {
      return "Debes ingresar una contraseña"
    }
  }

  login() {
    this.authSrv.login(this.email.value, this.password.value)
      .subscribe(
        //Success callback.
        (response) => {
          AuthService.setToken(response["token"]);
          this.router.navigate(["todo"]);
        },
        //Error callback.
        (error) => {
          this.snackBar.open("Usuaro o contraseña incorrecta!");
        },
        //Always callback.
        () => { console.log("the subscription is completed") })
  }



  ngOnInit(): void {
  }

}

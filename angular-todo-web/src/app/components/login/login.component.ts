import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from "@angular/forms";
import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router";
import { SnackBarService } from '../../services/snack-bar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authSrv: AuthService, private router: Router, private snackBar: SnackBarService, private fb: FormBuilder) { }

  //Simple example of FormGroup created with FromBuilder.
  loginForm = this.fb.group({
    email: ["", [Validators.required, Validators.email]],
    password: ["", [Validators.required, Validators.minLength(4)]]
  })

  errorByFromControlName(formControlName: string) {
    switch (formControlName) {
      case "email":
        if (this.loginForm.get("email").hasError('required')) {
          return 'El email es requerido';
        }
        if (this.loginForm.get("email").hasError('email')) {
          return "El email es inválido";
        }
        break;
      case "password":
        if (this.loginForm.get("password").hasError('required')) {
          return "La contraseña es obligatoria"
        }
        if (this.loginForm.get("password").hasError('minlength')) {
          return "La contraseña debe contener al menos 4 caracteres"
        }
        break;

      default:
        console.error("Unrecognized formControlName!");
        break;
    }
  }

  login() {
    this.authSrv.login(this.loginForm.get("email").value, this.loginForm.get("password").value)
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

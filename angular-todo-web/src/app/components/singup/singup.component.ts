import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { SnackBarService } from '../../services/snack-bar.service';

@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.css']
})
export class SingupComponent implements OnInit {

  constructor(private fb: FormBuilder, private authSrv: AuthService, private router: Router, private snackbarSrv: SnackBarService) { }

  signupForm = this.fb.group({
    email: ["", [Validators.required, Validators.email]],
    password: ["", [Validators.required, Validators.minLength(4)]]
  })

  errorByFromControlName(formControlName: string) {
    switch (formControlName) {
      case "email":
        if (this.signupForm.get("email").hasError('required')) {
          return 'El email es requerido';
        }
        if (this.signupForm.get("email").hasError('email')) {
          return "El email es inválido";
        }
        break;
      case "password":
        if (this.signupForm.get("password").hasError('required')) {
          return "La contraseña es obligatoria"
        }
        if (this.signupForm.get("password").hasError('minlength')) {
          return "La contraseña debe contener al menos 4 caracteres"
        }
        break;

      default:
        console.error("Unrecognized formControlName!");
        break;
    }
  }

  signup() {
    this.authSrv.signup(this.signupForm.get("email").value, this.signupForm.get("password").value)
      .subscribe(
        () => {
          this.snackbarSrv.open("Usuario creado correctamente!");
          setTimeout(() =>
            this.router.navigate(["login"]), 3000
          )
        },
        (err) => {
          this.snackbarSrv.open("Error al crear el usuario!")
        }
      )
  }

  ngOnInit(): void {
  }

}

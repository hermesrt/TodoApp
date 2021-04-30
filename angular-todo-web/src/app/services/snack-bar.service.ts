import { Injectable } from '@angular/core';
import { MatSnackBarModule, MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(private snackBar: MatSnackBar) { }

  open(msg: string) {
    const sb = this.snackBar.open(msg, "Cerrar", {
      duration: 5000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom'
    });

  }

}

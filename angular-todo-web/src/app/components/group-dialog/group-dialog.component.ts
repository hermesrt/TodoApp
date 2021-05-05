import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { TodoGroup } from '../../models/TodoGroup';
import { AuthService } from '../../services/auth.service';
import { SnackBarService } from '../../services/snack-bar.service';
import { TodoGroupService } from '../../services/todo-group.service';

@Component({
  selector: 'app-group-dialog',
  templateUrl: './group-dialog.component.html',
  styleUrls: ['./group-dialog.component.css']
})
export class GroupDialogComponent implements OnInit {

  groupForm: FormGroup;
  constructor(@Inject(MAT_DIALOG_DATA) public data: TodoGroup, private groupDialog: MatDialogRef<GroupDialogComponent>, private snackbarSrv: SnackBarService, private fb: FormBuilder, private todoSrv: TodoGroupService, private authSrv: AuthService) {
    this.groupForm = this.fb.group({
      name: [this.data ? this.data.name : "", [Validators.required]],
      priority: [this.data ? this.data.priority : "", [Validators.required, Validators.min(1), Validators.max(5)]]
    })
  }

  submitGroup() {
    const userData = this.authSrv.getJwtData();
    const todoGroup = <TodoGroup>{
      name: this.groupForm.get("name").value,
      priority: this.groupForm.get("priority").value,
      userId: userData.Id
    };
    if (this.data) {
      todoGroup.id = this.data.id;
    }
    const req = this.data ? this.todoSrv.putGroup(todoGroup) : this.todoSrv.postGroup(todoGroup);
    return req
      .subscribe(
        (res) => {
          this.groupDialog.close(res ? res : todoGroup);
          this.snackbarSrv.open("Grupo guardado con éxito!");
        },
        (error) => {
          this.snackbarSrv.open("Error al guardar el grupo!");
        }
      );
  }

  ngOnInit(): void {
  }

}

import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge, Observable, of as observableOf } from 'rxjs';
import { map, startWith, switchMap, catchError, tap } from "rxjs/operators";
import { TodoGroup } from '../../models/TodoGroup';
import { AuthService } from '../../services/auth.service';
import { SnackBarService } from '../../services/snack-bar.service';
import { TodoGroupService } from '../../services/todo-group.service';
import { } from "../../models/TodoGroup";
import { MatDialog } from '@angular/material/dialog';
import { ConfirmGroupDialogComponent } from '../confirm-dialog/confirm-dialog.component';
import { GroupDialogComponent } from '../group-dialog/group-dialog.component';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements AfterViewInit {

  constructor(private httpClient: HttpClient, private todoSrv: TodoGroupService, private authSrv: AuthService, private snackBarSrv: SnackBarService, private dialog: MatDialog) { }

  search = new FormControl("", [Validators.min(3)]);
  displayedColumns: string[] = ["name", "priority", "actions"];
  todoDataSource: MatTableDataSource<TodoGroup>;
  resultsLength = 0;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  ngAfterViewInit(): void {
    this.getGroups();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.todoDataSource.filter = filterValue.trim().toLowerCase();
  }

  resetPaging(): void {
    this.paginator.pageIndex = 0;
  }

  confirmDialog(): Observable<any> {
    const dialogRef = this.dialog.open(ConfirmGroupDialogComponent);
    return dialogRef.afterClosed();
  }

  editGroupDialog(todoGroup: TodoGroup) {
    const dialogRef = this.dialog.open(GroupDialogComponent, {
      data: todoGroup,
      width: "20%",
      minWidth: "20em"
    });
    dialogRef.afterClosed().subscribe(editedGroup => {
      if (editedGroup) {
        const data = this.todoDataSource.data.filter(e => e.id != editedGroup.id);
        data.push(<TodoGroup>editedGroup);
        this.todoDataSource.data = data;
      }
    });
  }

  getGroups() {
    const userData = this.authSrv.getJwtData();
    this.todoSrv.getGroups(userData.Id)
      .subscribe(
        (response) => {
          this.todoDataSource = new MatTableDataSource(response);
          this.paginator.pageSize = 25;
          this.todoDataSource.paginator = this.paginator;
          this.todoDataSource.sort = this.sort;
        },
        (err) => {
          this.snackBarSrv.open("Error al recuperar los datos!");
        }
      )
  }
  deleteGroup(group: TodoGroup) {
    this.confirmDialog().subscribe(result => {
      if (result) {
        const dataSource = this.todoDataSource;
        this.todoSrv.deleteGroup(group.id)
          .subscribe(
            (result) => {
              dataSource.data = dataSource.data.filter(e => e.id != group.id);
            },
            (error) => {
              this.snackBarSrv.open("Error al borrar el grupo!");
            }
          )
      }
    });
  }

  addGroup() {
    // if (this.search.invalid) {
    //   this.snackBarSrv.open("Ingrese un nombre valido!");
    //   return;
    // }
    // const dataSource = this.todoDataSource;
    // const userData = this.authSrv.getJwtData();
    // if (!userData) {
    //   this.snackBarSrv.open("Error al recuperar la información del usuario!");
    //   return;
    // }
    // this.todoSrv.postGroup(<TodoGroup>{
    //   name: this.search.value,
    //   userId: userData.Id
    // })
    //   .subscribe(
    //     (res) => {
    //       const newGroup = <TodoGroup>res;
    //       dataSource.data.push(newGroup);
    //       dataSource.filter = newGroup.name;
    //     },
    //     (err) => {
    //       this.snackBarSrv.open("Error al crear el grupo!");
    //     }
    //   );
    const dialogRef = this.dialog.open(GroupDialogComponent, {
      width: "20%",
      minWidth: "20em"
    });
    dialogRef.afterClosed().subscribe(editedGroup => {
      if (editedGroup) {
        const data = this.todoDataSource.data.filter(e => e.id != editedGroup.id);
        data.push(<TodoGroup>editedGroup);
        this.todoDataSource.data = data;
      }
    });

  }
}

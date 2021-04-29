import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from '../guards/authentication.guard';
import { LoggedGuard } from '../guards/logged.guard';
import { HomeComponent } from '../components/home/home.component';
import { LoginComponent } from '../components/login/login.component';
import { TodoComponent } from '../components/todo/todo.component';

const routes: Routes = [
  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "login", component: LoginComponent, canActivate: [LoggedGuard] },
  { path: "todo", component: TodoComponent, canActivate: [AuthenticationGuard] }
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
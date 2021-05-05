import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from '../components/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from '../components/toolbar/toolbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'


//Third party libs.
import { JwtModule } from "@auth0/angular-jwt";

// Angular material imports.
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatMenuModule } from "@angular/material/menu";
import { MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from "@angular/material/dialog";
import { MatSortModule } from "@angular/material/sort";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { OverlayModule } from '@angular/cdk/overlay';
import { MatGridListModule } from "@angular/material/grid-list";
// Custom component/services imports11
import { HomeComponent } from '../components/home/home.component';
import { LoginComponent } from '../components/login/login.component';
import { AuthService } from '../services/auth.service';
import { SpinnerOverlayComponent } from "../components/spinner-overlay/spinner-overlay.component";
import { SingupComponent } from '../components/singup/singup.component';
import { TodoComponent } from '../components/todo/todo.component';


// Interceptors
import { AuthInterceptor } from '../interceptors/auth.interceptor';
import { SpinnerInterceptor } from '../interceptors/spinner.interceptor';
import { ConfirmGroupDialogComponent } from '../components/confirm-dialog/confirm-dialog.component';
import { GroupDialogComponent } from '../components/group-dialog/group-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    HomeComponent,
    LoginComponent,
    TodoComponent,
    SpinnerOverlayComponent,
    SingupComponent,
    ConfirmGroupDialogComponent,
    GroupDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return AuthService.getToken();
        }
      }
    }),
    OverlayModule,
    MatSnackBarModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatMenuModule,
    MatDialogModule,
    MatGridListModule
  ],

  providers: [
    {
      //Used to pass data to GroupDialogComponent
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: { hasBackdrop: false }
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }, {
      provide: HTTP_INTERCEPTORS,
      useClass: SpinnerInterceptor,
      multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }

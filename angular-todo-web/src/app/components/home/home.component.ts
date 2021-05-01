import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private authSrv: AuthService, private router: Router) { }

  enterBtn() {
    if (this.authSrv.isAtuhenticated()) {
      this.router.navigate(["todo"]);
    } else {
      this.router.navigate(["login"]);
    }
  }
  ngOnInit(): void {
  }

}

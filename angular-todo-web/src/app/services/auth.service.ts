import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginUrl = "adsad";

  constructor(private httpClient: HttpClient) { }

  login() {

  }
}

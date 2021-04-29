import { Injectable } from '@angular/core';
import { HttpClient, } from "@angular/common/http";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from 'rxjs';

export const TOKEN_NAME: string = 'jwt_token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url: string = 'https://localhost:44368/auth/login';
  private headers = { 'content-type': 'application/json' }

  constructor(private httpClient: HttpClient, private jwtHelper: JwtHelperService) { }

  //Get the token from localStorage.
  public static getToken(): string {
    return localStorage.getItem(TOKEN_NAME);
  }

  //Set token in localStorage. 
  public static setToken(token: string): void {
    localStorage.setItem(TOKEN_NAME, token);
  }

  public isAtuhenticated(): boolean {
    const token = AuthService.getToken();
    if (!token) {
      return false;
    }
    // Check whether the token is expired and return
    // true or false
    return !this.jwtHelper.isTokenExpired(token);
  }

  //Check if the token is expired. By default search token with TOKEN_NAME const value.
  isTokenExpired(token?: string): boolean {
    if (!token) token = AuthService.getToken();
    if (!token) return true;
    return this.jwtHelper.isTokenExpired(token);
  }

  login(email: string, password: string): Observable<string> {
    return this.httpClient.post<string>(this.url, { email: email, Password: password }, { headers: this.headers });
  }

}


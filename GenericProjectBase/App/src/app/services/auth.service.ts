import { Observable, BehaviorSubject, throwError } from "rxjs";
import { Router } from "@angular/router";
import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { UserInfo } from "../models/user-info";
import { Login } from "../models/login";
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: "root"
})

export class AuthService {
  serverUrl: string = environment.urlServer;
  helper = new JwtHelperService();
  token: string;
  decodedToken: any;
  userInfoBehaviour = new BehaviorSubject<UserInfo>(null);
  userInfo: UserInfo;
  urlController: string = environment.urlServer;
  private ApiUrl = "me/auth";

  constructor(private _router: Router, private http: HttpClient) {
    const token = this.getToken();
    this.setUserInfo(token);
  }

  getRole() {
    return this.userInfo != null ? this.userInfo.Role : "";
  }

  getUser() {
    return this.userInfo != null ? this.userInfo.UserName : "";
  }

  setToken(authToken: string) {
    if (!authToken) {
      localStorage.removeItem("token");
    } else {
      localStorage.setItem("token", authToken);
    }

    this.setUserInfo(authToken);
  }

  getToken() {
    return localStorage.getItem("token");
  }

  getTokenExpirationDate(authToken: string): Date {
    this.decodedToken = this.helper.decodeToken(authToken);

    if (this.decodedToken.exp === undefined) return null;

    const date = new Date(0);
    date.setUTCSeconds(this.decodedToken.exp);
    return date;
  }

  isTokenExpired(authToken?: string): boolean {
    if (!authToken) authToken = this.getToken();
    if (!authToken) return true;

    const date = this.getTokenExpirationDate(authToken);
    if (date === undefined) return false; 

    return !(date.valueOf() > new Date().valueOf());
  }

  setUserInfo(authToken: string) {
    if (authToken) {
      this.decodedToken = this.helper.decodeToken(authToken);
      this.userInfo = new UserInfo();
      this.userInfo.Role = this.decodedToken.role;
      this.userInfo.UserName = this.decodedToken.unique_name;
    } else {
      this.userInfo = null;
    }

    this.userInfoBehaviour.next(this.userInfo);
  }

  isAuthenticated(): boolean {
    return this.userInfo != null;
  }

  login(loginRequest: Login) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      responseType: 'text' as 'json'
    };
    return this.http.post<string>(this.urlController + this.ApiUrl, loginRequest, httpOptions);

  }

  logout() {
    this.setToken(null);
    this._router.navigate(["/login"]);
  }

  forgotPassword(email: string): Observable<any> {
    const userLogin = { UserName: email, Password: "" };
    return this.http.post<void>(
      this.urlController + this.ApiUrl + "/ConfirmEmail",
      userLogin
    );
  }

  redirectToDefaultPage() {
    this._router.navigate(["/login"]);
  }
}

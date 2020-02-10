import { Observable, BehaviorSubject } from "rxjs";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { UserInfo } from "../models/user-info";
import { Login } from "../models/login";

@Injectable({
  providedIn: "root"
})
export class AuthService {
  serverUrl: string = environment.urlServer;
  // helper = new JwtHelperService();
  token: string;
  decodedToken: any;
  userInfoBehaviour = new BehaviorSubject<UserInfo>(null);
  userInfo: UserInfo;
  urlController: string = environment.urlServer;
  private ApiUrl = "login";

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

  setUserInfo(authToken: string) {
    if (authToken) {
      //   this.decodedToken = this.helper.decodeToken(authToken);
      this.userInfo = new UserInfo();
      this.userInfo.Role = this.decodedToken.role;
      this.userInfo.UserName = this.decodedToken.unique_name;
    } else {
      this.userInfo = null;
    }

    // this.userInfoBehaviour.next(this.userInfo);
  }

  isAuthenticated(): boolean {
    return this.userInfo != null;
  }

  login(pro: Login) {
    return this.http.post<Login>(this.urlController + this.ApiUrl, pro);
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

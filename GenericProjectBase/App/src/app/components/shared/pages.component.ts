import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserInfo } from '../../models/user-info';
// import { UserInfo } from '../models/user-info';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styles: []
})
export class PagesComponent implements OnInit {
  userName: string;

  constructor(private _authService: AuthService) { }

  ngOnInit() {
    this._authService.userInfoBehaviour.subscribe((userInfo: UserInfo) => {
      this.userName = null;

      if (userInfo) {
        this.userName = userInfo.UserName;
      }
    });

    if (!this._authService.isAuthenticated()) {
      this.logout();
    }
  }

  logout() {
    this._authService.logout();
  }
}

import { AuthService } from 'src/app/services/auth.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
    isAdmin = false;
    constructor(
        private authService: AuthService
    ) { }

    canActivate(route: ActivatedRouteSnapshot) {
        const roleUser = this.authService.getRole();
        const userName = this.authService.getUser();

        if (!userName) {
            this.authService.logout();
            return false;
        }

        var isExpired = this.authService.isTokenExpired();
        const roles = route.data.roles;
        if (roles !== undefined) {
            if (!this.authService.isTokenExpired()) {
                if (roles.indexOf(roleUser) !== -1) {
                    return true;
                } else {
                    this.authService.redirectToDefaultPage();
                    return false;
                }
            } else {
                this.authService.logout();
                return false
            }

        } else {
            this.authService.logout();
            return false
        }
    }
}

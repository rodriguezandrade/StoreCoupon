import { Component, OnInit } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { FormGroup, Validators, AbstractControl, FormControl } from '@angular/forms';
import { Login } from 'src/app/models/login';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginRequest: Login = new Login;
  loginForm: FormGroup;
  emptySpacePattern = /^[a-zA-Z0-9\_\-\ ]*$/;

  constructor(config: NgbCarouselConfig,
    private _router: Router,
    private _authService: AuthService,
    private _toastr: ToastrService) {
    config.interval = 10000;
    config.wrap = true;
    config.keyboard = false;
    config.pauseOnHover = false;
    config.showNavigationArrows = false;
    config.showNavigationIndicators = false;

    this.loginForm = new FormGroup({
      UserName: new FormControl('', [Validators.required, Validators.maxLength(50), Validators.pattern(this.emptySpacePattern),
      (control: AbstractControl) => this.emptySpace(control)]),
      Password: new FormControl('', [Validators.required, Validators.maxLength(50)])
    });
  }

  ngOnInit() {
    if (this._authService.getToken() !== null) {
      this._router.navigate(['/home']);
    }
  }

  emptySpace(control: AbstractControl) {
    const value: string = control.value || '';
    const firstChar = value[0];
    const lastChar = value[value.length - 1];

    if (firstChar === ' ' || lastChar === ' ') {
      return { noSpacesAround: true };
    }

    if (value.indexOf('  ') !== -1) {
      return { noMultipleSpaces: true };
    }

    return null;
  }

  login() {
    this._authService.login(this.loginRequest)
      .subscribe(data => {
        const authToken = data;
        if (authToken === null) {
          this._toastr.error('Invalid usuario or contraseña');
        } else {
          Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: '¡Login exitoso!',
            showConfirmButton: false,
            timer: 1000
          })
          this._authService.setToken(authToken.toString());
          this._router.navigate(['/home']);
        }
      }, (err) => console.log(err, "valio pinga")
      );
  }
}

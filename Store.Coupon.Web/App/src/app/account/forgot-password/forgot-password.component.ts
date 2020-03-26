import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {

  forgotForm: FormGroup;
  emailPattern = /^\s*[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\s*$/;
  disableButtonSend = false;

  constructor(private router: Router, private authService: AuthService) {
    this.forgotForm = new FormGroup({
      emailControl: new FormControl('', [Validators.required, Validators.pattern(this.emailPattern),
      (control: AbstractControl) => this.emptySpace(control)])
    });
  }

  emptySpace(control: AbstractControl) {
    const value: string = control.value || '';
    const firstChar = value[0];
    const doubleSpaceBlanck = (value.trim().split('  ').length - 1);

    if (firstChar === ' ') {
      return { noSpacesAround: true };
    }
    if (doubleSpaceBlanck > 0) {
      return { noSpacesAround: true };
    }

    return null;
  }

  forgotPassword() {
    this.disableButtonSend = true;
    const email = this.forgotForm.controls['emailControl'].value.trim();
    this.authService.forgotPassword(email).subscribe(
      result => {
        this.disableButtonSend = false;
        if (result) {
          setTimeout(() =>
            Swal.fire({
              text: 'Email Enviado Correctamente.',
              icon: 'success'
            })
          );
          this.onCancel();
        } else {
          setTimeout(() =>
            Swal.fire({
              text: 'Email no hace match con el administrador',
              icon: 'success'
            })
          );
        }
      },
      error => {
        this.disableButtonSend = false;
        this.errorMessage(error.name);
      }
    );
  }

  onCancel() {
    this.router.navigate(['/login']);
  }

  errorMessage(name: string) {
    setTimeout(() =>
      Swal.fire({
        text: 'Hello!' + name,
        icon: 'success'
      })
    );
  }
}

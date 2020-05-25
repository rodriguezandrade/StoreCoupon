import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component'; 
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_ROUTES } from './app.routes'; 
import { AuthService } from './services/auth.service';
import { AuthGuard } from './utils/guards/auth.guard';
import { PagesComponent } from './components/shared/pages.component'; 
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { PagesModule } from './components/shared/pages.module'; 
import { LoginComponent } from './components/account/login/login.component';
import { ForgotPasswordComponent } from './components/account/forgot-password/forgot-password.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { HandleErrorService } from './services/error-handler.service';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HelperService } from './services/helper/helper.service';
import { SignupComponent } from './components/account/signup/signup.component';

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    NavbarComponent,
    FooterComponent,
    ForgotPasswordComponent,
    LoginComponent,
    SignupComponent
  ],
  imports: [
    APP_ROUTES,
    BrowserModule,
    HttpClientModule,
    PagesModule,
    NgbModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FontAwesomeModule
  ],
  providers: [HelperService, AuthService , AuthGuard, HandleErrorService, {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }

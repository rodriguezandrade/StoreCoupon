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
import { LoginComponent } from './account/login/login.component';
import { ForgotPasswordComponent } from './account/forgot-password/forgot-password.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { HandleErrorService } from './services/error-handler.service';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    NavbarComponent,
    FooterComponent,
    ForgotPasswordComponent,
    LoginComponent
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
    BrowserAnimationsModule
  ],
  providers: [AuthService , AuthGuard, HandleErrorService, {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }

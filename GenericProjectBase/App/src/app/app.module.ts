import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component'; 
import { HttpClientModule } from '@angular/common/http';
import { APP_ROUTES } from './app.routes'; 
import { AuthService } from './services/auth.service';
import { AuthGuard } from './utils/guards/auth.guard';
import { PagesComponent } from './components/shared/pages.component'; 
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { PagesModule } from './components/shared/pages.module';
import { CategoryAddUpdateComponent } from './components/category/category-add-update/category-add-update.component';

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    NavbarComponent,
    FooterComponent,
    CategoryAddUpdateComponent
  ],
  imports: [
    APP_ROUTES,
    BrowserModule,
    HttpClientModule,
    PagesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

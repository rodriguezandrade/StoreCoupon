import { HomeComponent } from '../home/home.component';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PAGES_ROUTES } from './pages.routes'; 
import { CategoryComponent } from '../category/category.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';


@NgModule({
    declarations: [ 
         HomeComponent,
         CategoryComponent, 
    ],
    exports: [ 
        HomeComponent,
        CategoryComponent, 
    ],
    providers: [
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        ReactiveFormsModule,
        CommonModule,
        PAGES_ROUTES
    ],
    bootstrap: [HomeComponent]
})
export class PagesModule { }

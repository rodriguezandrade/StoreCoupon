
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PAGES_ROUTES } from './pages.routes'; 
import { CategoryComponent } from '../category/category.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { CategoryAddUpdateComponent } from '../category/category-add-update/category-add-update.component';
import { PagesComponent } from './pages.component';


@NgModule({
    declarations: [ 
         CategoryComponent, 
         CategoryAddUpdateComponent
    ],
    exports: [ 
        CategoryComponent, 
        CategoryAddUpdateComponent
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
    bootstrap: [PagesComponent]
})
export class PagesModule { }

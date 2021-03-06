
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PAGES_ROUTES } from './pages.routes'; 
import { ProductComponent } from '../product/product.component';
import { ProductSaveUpdateComponent } from '../product/product-save-update/product-save-update.component';
import { CategoryComponent } from '../category/category.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { CategoryAddUpdateComponent } from '../category/category-add-update/category-add-update.component';
import { PagesComponent } from './pages.component';
import { OwnerComponent } from '../owner/owner.component';
import { OwnerAddUpdateComponent } from '../owner/owner-add-update/owner-add-update.component';
import { SubCategoryComponent } from '../sub-category/sub-category.component';
import { SubCategoryAddUpdateComponent } from '../sub-category/sub-category-add-update/sub-category-add-update.component'; 
import { StoreComponent } from '../store/store.component';
import { StoreAddUpdateComponent } from '../store/store-add-update/store-add-update.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
    declarations: [ 
         ProductComponent,
         ProductSaveUpdateComponent,
         CategoryComponent, 
         CategoryAddUpdateComponent,
         OwnerComponent,
         OwnerAddUpdateComponent,
         SubCategoryComponent,
         SubCategoryAddUpdateComponent,
         StoreComponent,
         StoreAddUpdateComponent
    ],
    exports: [
        ProductComponent,
        ProductSaveUpdateComponent,
        CategoryComponent, 
        CategoryAddUpdateComponent,
        OwnerComponent,
        OwnerAddUpdateComponent,
        SubCategoryComponent,
        SubCategoryAddUpdateComponent,
        StoreComponent,
        StoreAddUpdateComponent
    ],
    providers: [
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        FontAwesomeModule,
        PAGES_ROUTES, 
    ],
    bootstrap: [PagesComponent]
})
export class PagesModule { }

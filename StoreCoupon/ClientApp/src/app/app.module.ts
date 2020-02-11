import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { OwnerComponent } from './components/owner/owner.component';
import { TableOwnerComponent } from './components/owner/table-owner/table-owner.component';
import { Rest } from './providers/rest';
import { FormOwnerComponent } from './components/owner/form-owner/form-owner.component';
import { CreateOwnerComponent } from './components/owner/create-owner/create-owner.component';
import { EditOwnerComponent } from './components/owner/edit-owner/edit-owner.component';
import { CategoryComponent } from './components/category/category.component';
import { CreateCategoryComponent } from './components/category/create-category/create-category.component';
import { EditCategoryComponent } from './components/category/edit-category/edit-category.component';
import { FormCategoryComponent } from './components/category/form-category/form-category.component';
import { TableCategoryComponent} from './components/category/table-category/table-category.component';
import { SubCategoryComponent } from './components/sub-category/sub-category.component';
import { CreateSubcategoryComponent } from './components/sub-category/create-subcategory/create-subcategory.component';
import { EditSubcategoryComponent } from './components/sub-category/edit-subcategory/edit-subcategory.component';
import { FormSubcategoryComponent } from './components/sub-category/form-subcategory/form-subcategory.component';
import { TableSubcategoryComponent } from './components/sub-category/table-subcategory/table-subcategory.component';
import { StoreComponent } from './components/store/store.component';
import { CreateStoreComponent } from './components/store/create-store/create-store.component';
import { EditStoreComponent } from './components/store/edit-store/edit-store.component';
import { FormStoreComponent } from './components/store/form-store/form-store.component';
import { TableStoreComponent } from './components/store/table-store/table-store.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    OwnerComponent,
    TableOwnerComponent,
    FormOwnerComponent,
    CreateOwnerComponent,
    EditOwnerComponent,
    CategoryComponent,
    CreateCategoryComponent,
    EditCategoryComponent,
    FormCategoryComponent,
    TableCategoryComponent,
    SubCategoryComponent,
    CreateSubcategoryComponent,
    EditSubcategoryComponent,
    FormSubcategoryComponent,
    TableSubcategoryComponent,
    StoreComponent,
    CreateStoreComponent,
    EditStoreComponent,
    FormStoreComponent,
    TableStoreComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'owners', component: OwnerComponent},
      { path: 'owners/create', component: CreateOwnerComponent},
      { path: 'owners/:id/edit', component: EditOwnerComponent},
      { path: 'categories', component: CategoryComponent },
      { path: 'categories/create', component: CreateCategoryComponent },
      { path: 'categories/:id/edit', component: EditCategoryComponent},
      { path: 'subcategories', component: SubCategoryComponent },
      { path: 'subcategories/create', component: CreateSubcategoryComponent },
      { path: 'subcategories/:id/edit', component: EditSubcategoryComponent },
      { path: 'stores', component: StoreComponent },
      { path: 'stores/create', component: CreateStoreComponent},
      { path: 'stores/:id/edit', component: EditStoreComponent }

    ])
  ],
  providers: [Rest],
  bootstrap: [AppComponent]
})
export class AppModule { }

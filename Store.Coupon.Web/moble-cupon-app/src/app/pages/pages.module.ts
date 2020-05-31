import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

//modules
import { JwSocialButtonsModule } from 'jw-angular-social-buttons'
import { HttpClientModule } from '@angular/common/http'
//custom modules
import { HeaderPageModule } from '../layout/header/header.module'
import { PagesPageRoutingModule } from './pages-routing.module';
import { CommonsWebPageModule } from '../commons-web/commons-web.module'
//components
import { CommerceDetailsComponent } from './commerce/commerce-details/commerce-details.component';
import { CommerceListComponent } from './commerce/commerce-list/commerce-list.component';
import { CommerceComponent } from './commerce/commerce.component';

import { CategoryDetailsComponent } from './category/category-details/category-details.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryComponent } from './category/category.component';
import { SaveEditCouponComponent } from './coupon/save-edit-coupon/save-edit-coupon.component';
import { ListCouponComponent } from './coupon/list-coupon/list-coupon.component'
import { CouponComponent } from './coupon/coupon.component'
import { ProductComponent } from './product/product.component';
import { SaveEditProductComponent } from './product/save-edit-product/save-edit-product.component';
import { ProductListComponent } from './product/product-list/product-list.component';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    HttpClientModule,
    JwSocialButtonsModule,
    HeaderPageModule,
    CommonsWebPageModule,
    PagesPageRoutingModule
  ],
  declarations: [
    CommerceDetailsComponent,
    CommerceListComponent,
    CommerceComponent,
    CategoryDetailsComponent,
    CategoryListComponent,
    CategoryComponent,
    SaveEditCouponComponent,
    ListCouponComponent,
    CouponComponent,
    ProductListComponent,
    ProductComponent,
    SaveEditProductComponent
  ],
  providers: []
})
export class PagesPageModule {}

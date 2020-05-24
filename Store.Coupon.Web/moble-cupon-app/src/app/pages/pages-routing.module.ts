import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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
import { ProductListComponent } from './product/product-list/product-list.component'
const routes: Routes = [
  {
    path: 'product',
    component: ProductComponent,
    children: [
      {
        path: '',
        component: ProductListComponent
      },
      {
        path: ':id',
        component: SaveEditProductComponent
      }
    ]
  },
  {
    path: 'coupon',
    component: CouponComponent,
    children: [
      {
        path: '',
        component: ListCouponComponent
      },
      {
        path: ':id',
        component: SaveEditCouponComponent
      }
    ]
  },
  {
    path: 'category',
    component: CategoryComponent,
    children: [
      {
        path: '',
        component: CategoryListComponent
      },
      {
        path: ':id',
        component: CategoryDetailsComponent
      }
    ]
  },
  {
    path: 'commerce',
    component: CommerceComponent,
    children: [
      {
        path: '',
        component: CommerceListComponent
      },
      {
        path: ':id',
        component: CommerceDetailsComponent
      }
    ]
  }
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesPageRoutingModule {}

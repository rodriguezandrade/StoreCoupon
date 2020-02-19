import { environment } from "src/environments/environment";
import { AuthGuard } from "../../utils/guards/auth.guard";
import { RouterModule, Routes } from "@angular/router";
import { CategoryComponent } from "../category/category.component";
import { PagesComponent } from "./pages.component";
import { CategoryAddUpdateComponent } from "../category/category-add-update/category-add-update.component";
import { OwnerComponent } from '../owner/owner.component';
import { OwnerAddUpdateComponent } from '../owner/owner-add-update/owner-add-update.component';
import { SubCategoryComponent } from '../sub-category/sub-category.component';
import { SubCategoryAddUpdateComponent } from '../sub-category/sub-category-add-update/sub-category-add-update.component';
import { StoreComponent } from '../store/store.component';
import { StoreAddUpdateComponent } from '../store/store-add-update/store-add-update.component';

const pagesRoutes: Routes = [
  {
    path: "home",
    component: PagesComponent,
    // data: { roles: [environment.roleAdmin], title: 'Home' }
    children: [
      {
        path: "categories",
        children: [
          {
            path: "",
            component: CategoryComponent
            // canActivateChild: [AuthGuard],
            // data: { roles: [environment.roleAdmin], title: 'Categories' }
          },
          {
            path: "new",
            component: CategoryAddUpdateComponent
            // canActivate: [AuthGuard],
            // data: { roles: [environment.roleAdmin], title: "Editar Categoria" }
          },
          {
            path:":id/edit",
            component: CategoryAddUpdateComponent
          }
          // {
          //     path: ':id',
          //     component: CategoryAddUpdateComponent,
          //     canActivate: [AuthGuard],
          //     data: { roles: [environment.roleAdmin], title: "Editar Categoria" }
          // }
        ]
      },
      {
        path:"owners",
        children:[
          {
            path:"",
            component: OwnerComponent 
          },
          {
            path:"new",
            component: OwnerAddUpdateComponent
          },
          {
            path:":id/edit",
            component: OwnerAddUpdateComponent
          }
        ]
      },
      {
        path:"subcategories",
        children:[
          {
            path:"",
            component: SubCategoryComponent 
          },
          {
            path:"new",
            component: SubCategoryAddUpdateComponent
          },
          {
            path:":id/edit",
            component: SubCategoryAddUpdateComponent
          }
        ]
      },
      {
        path:"stores",
        children:[
          {
            path:"",
            component: StoreComponent 
          },
          {
            path:"new",
            component: StoreAddUpdateComponent
          },
          {
            path:":id/edit",
            component: StoreAddUpdateComponent
          }
        ]
      }
    ]
  },

  //   {
  //     path: "categories/:Id",
  //     component: CategoryAddUpdateComponent,
  //     canActivate: [AuthGuard],
  //     data: { roles: [environment.roleAdmin], title: "Editar Categoria" }
  //   },
  //   {
  //     path: "categories/new",
  //     component: CategoryAddUpdateComponent,
  //     canActivate: [AuthGuard],
  //     data: { roles: [environment.roleAdmin], title: "Nueva Categoria" }
  //   },

  // {
  //     path: 'addresslist', component: metecomponentequevasausar,
  //     canActivate: [AuthGuard],
  //     data: { roles: [environment.roleAdmin], title: 'Address Book' },
  // },
  // {
  //     path: 'customers', component: metecomponentequevasausar,
  //     canActivate: [AuthGuard],
  //     data: { roles: [environment.roleAdmin], title: 'Customers' }
  // },

   
   { path: '', redirectTo: '/login', pathMatch: 'full' },
   { path: '**', redirectTo: '/login' }
];
export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);

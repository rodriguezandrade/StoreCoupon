import { environment } from "src/environments/environment";
import { AuthGuard } from "../../utils/guards/auth.guard";
import { RouterModule, Routes } from "@angular/router";
import { CategoryComponent } from "../category/category.component";
import { PagesComponent } from "./pages.component";
import { CategoryAddUpdateComponent } from "../category/category-add-update/category-add-update.component";
import { OwnerComponent } from '../owner/owner.component';
import { OwnerAddUpdateComponent } from '../owner/owner-add-update/owner-add-update.component';

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

  

  //temporalmente estara logeandose a home, luego seria montarla al login de inicio
  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "**", redirectTo: "/home" }
  // { path: '', redirectTo: '/login', pathMatch: 'full' },
  //  { path: '**', redirectTo: '/login' }
];
export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);

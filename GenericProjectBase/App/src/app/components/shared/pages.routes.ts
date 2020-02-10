import { environment } from "src/environments/environment";
import { HomeComponent } from "../home/home.component";
import { AuthGuard } from "../../utils/guards/auth.guard";
import { RouterModule, Routes } from "@angular/router";
import { CategoryComponent } from "../category/category.component";
import { PagesComponent } from "./pages.component";
import { CategoryAddUpdateComponent } from "../category/category-add-update/category-add-update.component";

const pagesRoutes: Routes = [
  {
    path: "home",
    component: PagesComponent
    // data: { roles: [environment.roleAdmin], title: 'Home' }
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
  {
    path: "categories",
    component: CategoryComponent,
    // canActivate: [AuthGuard],
    data: { roles: [environment.roleAdmin], title: "Categorías" },
    children: [
      // {
      //     path: ':id',
      //     component: CategoryAddUpdateComponent,
      //     canActivate: [AuthGuard],
      //     data: { roles: [environment.roleAdmin], title: "Editar Categoria" }
      // },
      {
        path: "new",
        component: CategoryAddUpdateComponent
        // canActivate: [AuthGuard],
        // data: { roles: [environment.roleAdmin], title: "Editar Categoria" }
      }
    ]
  },
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

import { environment } from "src/environments/environment";
import { AuthGuard } from "../../utils/guards/auth.guard";
import { RouterModule, Routes } from "@angular/router";
import { ProductComponent } from '../product/product.component';
import { ProductSaveUpdateComponent } from '../product/product-save-update/product-save-update.component';
import { CategoryComponent } from "../category/category.component";
import { PagesComponent } from "./pages.component";
import { CategoryAddUpdateComponent } from "../category/category-add-update/category-add-update.component";
import { OwnerComponent } from '../owner/owner.component';
import { OwnerAddUpdateComponent } from '../owner/owner-add-update/owner-add-update.component';
import { SubCategoryComponent } from '../sub-category/sub-category.component';
import { SubCategoryAddUpdateComponent } from '../sub-category/sub-category-add-update/sub-category-add-update.component';
import { StoreComponent } from '../store/store.component';
import { StoreAddUpdateComponent } from '../store/store-add-update/store-add-update.component';
import { Roles } from 'src/app/utils/enums/roles';

const pagesRoutes: Routes = [
  {
    path: "home",
    component: PagesComponent,
    canActivate: [AuthGuard],
    data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Home' },
    children: [
      {
        path: "products",
        canActivate: [AuthGuard],
        data: { roles: [Roles.Admin, Roles.Consumer,  Roles.Owner], title: 'Productos' },
        children: [
          {
            path: "",
            component: ProductComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Productos' }
          },
          {
            path: "new",
            component: ProductSaveUpdateComponent,
            canActivate: [AuthGuard],
            data: { roles: [Roles.Admin, Roles.Owner], title: "Nuevo Producto" }
          },
          {
            path: ":id/edit",
            component: ProductSaveUpdateComponent,
            canActivate: [AuthGuard],
            data: { roles: [Roles.Admin], title: "Editar Producto" }
          }
        ]
      },
      {
        path: "categories",
        canActivate: [AuthGuard],
        data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Categorias' },
        children: [
          {
            path: "",
            component: CategoryComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Categorias' }
          },
          {
            path: "new",
            component: CategoryAddUpdateComponent,
            canActivate: [AuthGuard],
            data: { roles: [Roles.Admin, Roles.Owner,], title: "Nueva Categoria" }
          },
          {
            path: ":id/edit",
            component: CategoryAddUpdateComponent,
            canActivate: [AuthGuard],
            data: { roles: [Roles.Admin], title: "Editar Categoria" }
          }
        ]
      },
      {
        path: "owners",
        canActivate: [AuthGuard],
        data: { roles: [Roles.Admin], title: 'Propietarios' },
        children: [
          {
            path: "",
            component: OwnerComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: 'Propietarios' }
          },
          {
            path: "new",
            component: OwnerAddUpdateComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: "Nuevo Propietario" }
          },
          {
            path: ":id/edit",
            component: OwnerAddUpdateComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: "Editar Propietario" }
          }
        ]
      },
      {
        path: "subcategories",
        canActivate: [AuthGuard],
        data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Subcategorias' },
        children: [
          {
            path: "",
            component: SubCategoryComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Subcategorias' }
          },
          {
            path: "new",
            component: SubCategoryAddUpdateComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: 'Nueva Subcategoria' }
          },
          {
            path: ":id/edit",
            component: SubCategoryAddUpdateComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: 'Editar Subcategoria' }
          }
        ]
      },
      {
        path: "stores",
        canActivate: [AuthGuard],
        data: { roles: [Roles.Admin, Roles.Owner, Roles.Consumer], title: 'Negocios' },
        children: [
          {
            path: "",
            component: StoreComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: 'Negocios' }
          },
          {
            path: "new",
            component: StoreAddUpdateComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: 'Nuevo Negocio' }
          },
          {
            path: ":id/edit",
            component: StoreAddUpdateComponent,
            canActivateChild: [AuthGuard],
            data: { roles: [Roles.Admin], title: 'Editar Negocio' }
          }
        ]
      }
    ]
  },

  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' }
];
export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);

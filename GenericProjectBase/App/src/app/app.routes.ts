import { AppComponent } from './app.component';
import { CategoryComponent } from './components/category/category.component';
import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './components/shared/pages.component'; 

const appRoutes: Routes = [
    {
        path: '',
        loadChildren: './components/shared/pages.module#PagesModule'
    }
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes);

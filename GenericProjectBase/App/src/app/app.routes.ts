import { AppComponent } from './app.component';
import { CategoryComponent } from './components/category/category.component';
import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './components/shared/pages.component';
import { HomeComponent } from './components/home/home.component';

const appRoutes: Routes = [
    {
        path: 'home',
        component: PagesComponent,
        data: { title: 'Categories' }
     },
    // {
    //     path: 'forgotPassword',
    //     component: ForgotPasswordComponent,
    //     data: { title: 'Forgot Password' }
    // },
    // {
    //     path: 'menusurvey/:Id',
    //     component: SurveyComponent,
    //     data: { title: 'Survey' }
    // },
    // {
    //     path: 'error',
    //     component: ErrorsComponent,
    //     data: { title: 'Error' }
    // },
  
    {
        path: '',
        component: PagesComponent,
        loadChildren: './components/shared/pages.module#PagesModule'
    }
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes, { useHash: false });

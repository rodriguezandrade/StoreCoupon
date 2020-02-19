
import { Routes, RouterModule } from '@angular/router';
import { ForgotPasswordComponent } from './account/forgot-password/forgot-password.component';
import { LoginComponent } from './account/login/login.component';

const appRoutes: Routes = [
    {
        path: 'login',
        component: LoginComponent,
        data: { title: 'Login' }
    },
    {
        path: 'forgotPassword',
        component: ForgotPasswordComponent,
        data: { title: 'Forgot Password' }
    },
    {
        path: '',
        loadChildren: './components/shared/pages.module#PagesModule'
    }
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes);

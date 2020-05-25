
import { Routes, RouterModule } from '@angular/router';
import { ForgotPasswordComponent } from './components/account/forgot-password/forgot-password.component';
import { LoginComponent } from './components/account/login/login.component';
import { SignupComponent } from './components/account/signup/signup.component';

const appRoutes: Routes = [
    {
        path: 'signUp',
        component: SignupComponent,
        data:{ title : 'Sign Up' }
    },
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
        loadChildren: () => import('./components/shared/pages.module').then(m => m.PagesModule)
    }
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes, { useHash: false });

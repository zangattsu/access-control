import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { authGuard } from './features/auth/auth.guard';
import { HomeComponent } from './features/home/home.component';
import { OktaWidgetComponent } from './features/auth/login/okta-widget/okta-widget.component';
import { CallbackComponent } from './features/auth/login/callback/callback.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [authGuard] },
  { path: 'login', component: LoginComponent },  // Formulário personalizado
  { path: 'account/login', component: LoginComponent },  // Formulário personalizado
  { path: 'login-widget', component: OktaWidgetComponent },  // Widget do Okta
  { path: 'login/callback', component: CallbackComponent },
  { 
    path: 'dashboard', 
    loadComponent: () => import('./features/dashboard/dashboard-view/dashboard-view.component').then(m => m.DashboardViewComponent),
    canActivate: [authGuard]
  },
  { path: '**', redirectTo: '' }
];
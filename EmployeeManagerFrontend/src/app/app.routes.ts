import { Routes } from '@angular/router';

import { Login } from './components/login/login';
import { EmployeeDashboard } from './components/employee-dashboard/employee-dashboard';
import { ManagerDashboard } from './components/manager-dashboard/manager-dashboard';

import { authGuard } from './guards/auth-guard';

export const routes: Routes = [

  {
    path: '',
    component: Login
  },

  {
    path: 'employee-dashboard',
    component: EmployeeDashboard,
    canActivate: [authGuard]
  },

  {
    path: 'manager-dashboard',
    component: ManagerDashboard,
    canActivate: [authGuard]
  }

];
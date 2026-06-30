import { Routes } from '@angular/router';

import { Login } from './components/login/login';
import { EmployeeDashboard } from './components/employee-dashboard/employee-dashboard';
import { ManagerDashboard } from './components/manager-dashboard/manager-dashboard';
import { LeaveHistoryComponent } from './components/leave-history/leave-history';
import { ApplyLeaveComponent } from './components/apply-leave/apply-leave';
import { PendingRequestsComponent } from './components/pending-requests/pending-requests';

import { employeeGuard } from './guards/employee-guard';
import { managerGuard } from './guards/manager-guard';

export const routes: Routes = [

  {
    path: '',
    component: Login
  },

  // Employee Routes
  {
    path: 'employee-dashboard',
    component: EmployeeDashboard,
    canActivate: [employeeGuard]
  },

  {
    path: 'leave-history',
    component: LeaveHistoryComponent,
    canActivate: [employeeGuard]
  },

  {
    path: 'apply-leave',
    component: ApplyLeaveComponent,
    canActivate: [employeeGuard]
  },

  // Manager Routes
  {
    path: 'manager-dashboard',
    component: ManagerDashboard,
    canActivate: [managerGuard]
  },

  {
    path: 'pending-requests',
    component: PendingRequestsComponent,
    canActivate: [managerGuard]
  }

];
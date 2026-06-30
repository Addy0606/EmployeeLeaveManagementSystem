import { Routes } from '@angular/router';
import { PendingRequestsComponent } from './components/pending-requests/pending-requests';
import { Login } from './components/login/login';
import { EmployeeDashboard } from './components/employee-dashboard/employee-dashboard';
import { ManagerDashboard } from './components/manager-dashboard/manager-dashboard';
import { ApplyLeaveComponent } from './components/apply-leave/apply-leave';
import { authGuard } from './guards/auth-guard';
import { LeaveHistoryComponent } from './components/leave-history/leave-history';

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
  },
  {
    path: 'leave-history',
    component: LeaveHistoryComponent,
    canActivate: [authGuard]
  },
  

{
    path: 'apply-leave',
    component: ApplyLeaveComponent,
    canActivate: [authGuard]
},
{
    path: 'pending-requests',
    component: PendingRequestsComponent,
    canActivate: [authGuard]
}
];
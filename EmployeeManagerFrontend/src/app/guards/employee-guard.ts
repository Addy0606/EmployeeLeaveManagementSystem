import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../services/auth';

export const employeeGuard: CanActivateFn = () => {

  const authService = inject(AuthService);
  const router = inject(Router);

  if (
    authService.isLoggedIn() &&
    authService.getRole() === 'Employee'
  ) {
    return true;
  }

  router.navigate(['/']);

  return false;
};
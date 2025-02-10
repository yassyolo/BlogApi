import { inject, Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const userRoles = authService.getUserRole();
  const requiredRoles = route.data['roles'] || [];

  if (requiredRoles.length === 0) {
    return true;
  }

  const hasRequiredRole = requiredRoles.some((role: string) => userRoles.includes(role));

  if (hasRequiredRole) {
    return true; 
  }

  router.navigate(['/login']);
  return false;
};

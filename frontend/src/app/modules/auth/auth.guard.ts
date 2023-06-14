import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from './auth.sevice';

export const authGuardFn: CanActivateFn = () => {
  const authService = inject(AuthService);
  const hasToken = authService.hasToken();
  return hasToken || authService.authenticated || authService.authenticated$;
};

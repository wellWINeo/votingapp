import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: OAuthService, private router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!this.matchApiUrl(req.url)) return next.handle(req);

    const headers = req.headers.set('Authorization', this.getAuthHeader());
    const apiReq = req.clone({ headers: headers });

    return next.handle(apiReq);
  }

  private matchApiUrl(url: string): boolean {
    return url.startsWith('/api') && !url.startsWith('/api/auth');
  }

  private getAuthHeader(): string {
    return `Bearer ${this.authService.getAccessToken()}`;
  }
}

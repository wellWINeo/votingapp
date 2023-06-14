import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authConfig } from './auth.settings';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { Subject } from 'rxjs';

@Injectable()
export class AuthService {
  public authenticated: boolean = false;
  public authenticated$ = new Subject<boolean>();

  private inProgress: boolean = false;

  constructor(private oauthService: OAuthService) {}

  public setup(): void {
    this.authenticated$.subscribe((value) => (this.authenticated = value));

    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();

    if (this.oauthService.hasValidAccessToken()) return;

    this.oauthService.loadDiscoveryDocumentAndTryLogin().then((value) => {
      const success = value && this.oauthService.hasValidAccessToken();
      if (success) {
        this.authenticated$.next(true);
        return;
      }
      this.login();
    });

    this.oauthService.setupAutomaticSilentRefresh();
  }

  public login() {
    if (this.inProgress) return;

    this.oauthService.initCodeFlow();
  }

  public hasToken(): boolean {
    return this.oauthService.hasValidAccessToken();
  }
}

import { AuthConfig } from "angular-oauth2-oidc";

export const authConfig: AuthConfig = {
  clientId: 'votingapp-client',
  issuer: 'http://localhost:5001/realms/votingapp',
  redirectUri: window.location.origin,
  responseType: 'code',
  scope: 'openid profile votingapp-api offline_access'
}

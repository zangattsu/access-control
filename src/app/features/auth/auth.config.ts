import { OktaAuthOptions } from '@okta/okta-auth-js';
import { WindowDefinition } from '../../shared/window.definition';

export const oktaAuthConfig: OktaAuthOptions = {
  // Configurações do Okta Auth
  // url: 'https://dev-67094057.okta.com/oauth2/default', // URL do servidor de autorização Okta  
  issuer: 'https://dev-67094057.okta.com/oauth2/default',
  clientId: '0oao9ep7pfvFyPrzU5d7',
  redirectUri: 'http/localhost:4200/login/callback',
  scopes: ['openid', 'profile', 'email'],
  pkce: true, // Proof Key for Code Exchange (PKCE) - obrigatório para Authorization Code Flow
  responseMode: 'query',
  responseType: 'code'
};
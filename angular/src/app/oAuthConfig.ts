import { Injectable } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';

import { ConfigService } from './service/config.service';

export const oAuthConfig: AuthConfig = {
  clientId: 'NotepadAngularApp',
  scope: 'NotepadAPI openid profile',
  dummyClientSecret: 'secret',
  oidc: false,
};

@Injectable()
export class OAuthConfig {

  constructor(private oAuthService: OAuthService, private configService: ConfigService) {
  }

  load(): Promise<object> {
    let url: string;
    oAuthConfig.issuer = this.configService.config().issuer;
    oAuthConfig.requireHttps = this.configService.config().issuerRequireHttps;
    this.oAuthService.configure(oAuthConfig);
    url = oAuthConfig.issuer + '/.well-known/openid-configuration';
    this.oAuthService.setStorage(localStorage);
    return this.oAuthService.loadDiscoveryDocument(url);
  }

}

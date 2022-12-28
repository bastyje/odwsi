import { Injectable } from '@angular/core';
import { OAuthService, UserInfo } from "angular-oauth2-oidc";
import { LoginModel } from "../models/login.model";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private oAuthService: OAuthService) {}

  public signIn(login: LoginModel): Promise<object> {
    return this.oAuthService.fetchTokenUsingPasswordFlowAndLoadUserProfile(login.username, login.password);
  }
}

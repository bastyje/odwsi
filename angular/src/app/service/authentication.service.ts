import { Injectable } from '@angular/core';
import { OAuthService } from "angular-oauth2-oidc";
import { LoginModel } from "../models/login.model";
import { RegisterUserModel } from "../models/register-user.model";
import { HttpService } from "./http.service";
import { ServiceMessage } from "../models/service-message.model";
import { Observable } from "rxjs";
import { Router } from "@angular/router";
import { routes } from "../app-routing.module";
import { HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private oAuthService: OAuthService, private httpService: HttpService, private router: Router) {}

  public signIn(login: LoginModel): Promise<object> {
    return this.oAuthService.fetchTokenUsingPasswordFlowAndLoadUserProfile(login.username, login.password);
  }

  public signOut() {
    this.oAuthService.logOut(true);
    this.router.navigate(['/', 'login']);
  }

  public register(registerUserModel: RegisterUserModel): Observable<ServiceMessage> {
    return this.httpService.post('User', registerUserModel);
  }

  public isLoggedIn(): boolean {
    const expireTime = localStorage.getItem('expires_at');
    let loggedIn = false;
    if (expireTime !== null)
      loggedIn = parseInt(expireTime) > Date.now();
    return loggedIn;
  }

  public getToken(): string {
    const token: string = this.oAuthService.getAccessToken();
    return token;
  }
}

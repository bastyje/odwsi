import { APP_INITIALIZER, Injector, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './views/login/login.component';
import { RegisterComponent } from './views/register/register.component';
import { LayoutComponent } from './views/shared/layout/layout.component';
import { NavbarComponent } from './views/shared/layout/navbar/navbar.component';
import { FooterComponent } from './views/shared/layout/footer/footer.component';
import { ConfigService } from "./service/config.service";
import { map } from "rxjs";
import { OAuthConfig } from "./oAuthConfig";
import { HttpClientModule } from "@angular/common/http";
import { OAuthLogger, OAuthModule, OAuthService, UrlHelperService } from "angular-oauth2-oidc";
import { ReactiveFormsModule } from "@angular/forms";

export function AppInitializer(appConfig: ConfigService, oAuthConfig: OAuthConfig, injector: Injector): Function {
  return () => appConfig.loadConfig().pipe(map(() => oAuthConfig.load()));
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LayoutComponent,
    NavbarComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    OAuthModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [
    OAuthConfig,
    {
      provide: APP_INITIALIZER,
      useFactory: AppInitializer,
      deps: [ConfigService, OAuthConfig, Injector],
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

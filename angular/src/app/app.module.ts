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
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { OAuthModule } from "angular-oauth2-oidc";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { JwtInterceptor } from "./service/jwt.interceptor";
import { HttpService } from "./service/http.service";

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
    ReactiveFormsModule,
    FormsModule
    ],
  providers: [
    OAuthConfig,
    {
      provide: APP_INITIALIZER,
      useFactory: AppInitializer,
      deps: [ConfigService, OAuthConfig, Injector],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    HttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

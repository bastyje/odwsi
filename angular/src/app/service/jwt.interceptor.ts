import { AuthenticationService } from "./authentication.service";
import { ConfigService } from "./config.service";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authentication: AuthenticationService, private configService: ConfigService ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const isApiUrl = request.url.startsWith(this.configService.config().apiURI);
    const token = this.authentication.getToken();
    if (token && isApiUrl) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
          Accept: 'application/json'
        }
      });
    }
    return next.handle(request);
  }
}

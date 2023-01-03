import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { ConfigService } from "./config.service";

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private readonly baseUrl: string;

  constructor(private http: HttpClient, configService: ConfigService) {
    this.baseUrl = configService.config().apiURI;
  }


  get<T>(url: string, httpHeaders?: HttpHeaders, httpParams?: HttpParams): Observable<T> {
    const options = {
      headers: httpHeaders,
      params: httpParams
    };
    url = this.baseUrl + url;
    return this.http.get<T>(url, options);
  }

  post<T>(url: string, data: any, httpHeaders?: HttpHeaders): Observable<T> {
    url = this.baseUrl + url;

    if (httpHeaders === null || httpHeaders === undefined) {
      httpHeaders = new HttpHeaders();
    }

    httpHeaders = httpHeaders!.append('Content-Type', 'application/json');

    const options = { headers: httpHeaders };

    return this.http.post<T>(url, data, options);
  }

  put<T>(url: string, data: any, httpHeaders?: HttpHeaders): Observable<T> {
    url = this.baseUrl + url;

    if (httpHeaders === null || httpHeaders === undefined) {
      httpHeaders = new HttpHeaders();
    }

    httpHeaders = httpHeaders!.append('Content-Type', 'application/json');

    const options = {headers: httpHeaders};

    return this.http.put<T>(url, data, options);
  }

  delete(url: string, data?: any, httpHeaders?: HttpHeaders): Observable<any> {
    url = this.baseUrl + url;

    if (httpHeaders === null || httpHeaders === undefined) {
      httpHeaders = new HttpHeaders();
    }
    httpHeaders = httpHeaders!.append('Content-Type', 'application/json');

    const options = {headers: httpHeaders, body: data};
    return this.http.delete(url, options);
  }
}

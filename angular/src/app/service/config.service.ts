import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigModel } from "../models/config.model";
import { catchError, map } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  private appConfig: ConfigModel;

  constructor(private http: HttpClient) {
    this.appConfig = {} as ConfigModel;
  }

  loadConfig() {
    const jsonFile = 'assets/app.config.json';
    return this.http.get(jsonFile).pipe(catchError(() => {
      throw new Error(`Application could not load configuration file '${jsonFile}'`);
    })).
    pipe(map(appConfig => {
      this.appConfig = <ConfigModel> appConfig;
    }));

  }

  config(): ConfigModel {
    return this.appConfig;
  }
}

import { ApplicationInsightsService } from "src/app/services/application-insights.service";
import { environment } from "./../../environments/environment";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { WeatherForecast } from "../models/weather-forecast.model";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  authUrl = environment.authBaseUrl + "api/auth";
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  isLoggedIn = false;

  constructor(
    private http: HttpClient,
    private aiService: ApplicationInsightsService
  ) {}

  getWeather = (): Observable<WeatherForecast[]> => {
    return this.http.get<WeatherForecast[]>(this.authUrl);
  };

  login = (username: string, password: string) => {
    return this.http
      .post(`${this.authUrl}/login`, {
        username: username,
        password: password,
      })
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem("token", user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            this.aiService.setUserId(user.id.toString());
            this.isLoggedIn = true;
          }
        })
      );
  };

  getLoggedInUserToken = (): string => localStorage.getItem("token");

  isLoggedInUser = (): boolean => this.isLoggedIn;
}

import { WeatherForecast } from "./../../models/weather-forecast.model";
import { AuthService } from "./../../services/auth.service";
import { Component, OnInit } from "@angular/core";
import { ApplicationInsightsService } from "src/app/services/application-insights.service";

@Component({
  selector: "app-weatherforecast",
  templateUrl: "./weatherforecast.component.html",
  styleUrls: ["./weatherforecast.component.css"],
})
export class WeatherforecastComponent implements OnInit {
  weatherArray: WeatherForecast[];
  constructor(
    private authService: AuthService,
    private aiService: ApplicationInsightsService
  ) {}

  ngOnInit() {
    this.authService.getWeather().subscribe((response) => {
      this.weatherArray = response;
    });
  }
}

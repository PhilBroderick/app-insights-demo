import { AuthService } from "src/app/services/auth.service";
import { Component } from "@angular/core";
import { ApplicationInsightsService } from "./services/application-insights.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  constructor(private aiService: ApplicationInsightsService) {}
  title = "frontend";
}

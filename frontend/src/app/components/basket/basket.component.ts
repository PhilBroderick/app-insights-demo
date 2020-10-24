import { ApplicationInsightsService } from "./../../services/application-insights.service";
import { Component, OnInit } from "@angular/core";
import { BasketItem } from "src/app/models/basket-item.model";
import { BasketService } from "src/app/services/basket.service";
import { Exception } from "@microsoft/applicationinsights-web";

@Component({
  selector: "app-basket",
  templateUrl: "./basket.component.html",
  styleUrls: ["./basket.component.css"],
})
export class BasketComponent implements OnInit {
  constructor(public basketService: BasketService) {}

  ngOnInit() {}
}

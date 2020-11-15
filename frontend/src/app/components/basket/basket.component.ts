import { BasketItem } from "./../../models/basket-item.model";
import { ApplicationInsightsService } from "./../../services/application-insights.service";
import { Component, OnInit } from "@angular/core";
import { BasketService } from "src/app/services/basket.service";
import { Exception } from "@microsoft/applicationinsights-web";

@Component({
  selector: "app-basket",
  templateUrl: "./basket.component.html",
  styleUrls: ["./basket.component.css"],
})
export class BasketComponent implements OnInit {
  constructor(
    public basketService: BasketService,
    private aiService: ApplicationInsightsService
  ) {}

  ngOnInit() {}

  checkout = () => {
    this.basketService.checkout().subscribe(
      (next) => {
        this.aiService.logEvent("checkout_success", { cart: next });
        this.basketService.clearBasket();
      },
      (err) => {
        let basket: BasketItem[] = [];
        this.basketService.basket$.subscribe(
          (basketResponse) => (basket = basketResponse)
        );
        this.aiService.logEvent("checkout_failure", {
          cart: basket,
          error: err,
        });
      }
    );
  };
}

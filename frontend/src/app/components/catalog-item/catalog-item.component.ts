import { BasketService } from "./../../services/basket.service";
import { CatalogItem } from "./../../models/catalog-item.model";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { ApplicationInsightsService } from "src/app/services/application-insights.service";

@Component({
  selector: "app-catalog-item",
  templateUrl: "./catalog-item.component.html",
  styleUrls: ["./catalog-item.component.css"],
})
export class CatalogItemComponent implements OnInit {
  @Input() catalogItem: CatalogItem;
  @Output() addToBasket: EventEmitter<CatalogItem> = new EventEmitter();
  constructor(private aiService: ApplicationInsightsService) {}

  ngOnInit() {}

  addToCart = (catalogItem: CatalogItem) => {
    this.addToBasket.emit(catalogItem);
  };
}

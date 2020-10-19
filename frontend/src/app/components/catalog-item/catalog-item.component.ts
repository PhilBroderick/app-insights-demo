import { CatalogItem } from "./../../models/catalog-item.model";
import { Component, Input, OnInit } from "@angular/core";
import { ApplicationInsightsService } from "src/app/services/application-insights.service";

@Component({
  selector: "app-catalog-item",
  templateUrl: "./catalog-item.component.html",
  styleUrls: ["./catalog-item.component.css"],
})
export class CatalogItemComponent implements OnInit {
  @Input() catalogItem: CatalogItem;
  constructor(private aiService: ApplicationInsightsService) {}

  ngOnInit() {}

  addToCart = (id: number) => {
    this.aiService.logEvent("add-to-cart", { id });
  };
}

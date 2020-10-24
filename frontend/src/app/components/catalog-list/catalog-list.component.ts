import { BasketService } from "./../../services/basket.service";
import { CatalogItem } from "./../../models/catalog-item.model";
import { CatalogService } from "./../../services/catalog.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-catalog-list",
  templateUrl: "./catalog-list.component.html",
  styleUrls: ["./catalog-list.component.css"],
})
export class CatalogListComponent implements OnInit {
  catalogItems: CatalogItem[];
  constructor(
    private catalogService: CatalogService,
    private basketService: BasketService
  ) {}

  ngOnInit() {
    this.catalogService.getCatalogItemsInStock().subscribe((response) => {
      this.catalogItems = response;
    });
  }

  addToBasketEvent = (catalogItem: CatalogItem) => {
    this.basketService.addToBasket(catalogItem, 1);
  };
}

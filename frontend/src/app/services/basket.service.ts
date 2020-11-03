import { ApplicationInsightsService } from "./application-insights.service";
import { CatalogItem } from "./../models/catalog-item.model";
import { environment } from "./../../environments/environment";
import { AuthService } from "src/app/services/auth.service";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BasketItem } from "../models/basket-item.model";
import { BehaviorSubject, Observable, Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class BasketService {
  basket$: Observable<BasketItem[]>;
  private basketSubject: BehaviorSubject<BasketItem[]>;
  private headers: HttpHeaders;
  private basketApiUrl = environment.basketBaseUrl + "api/basket";

  constructor(
    private http: HttpClient,
    private authService: AuthService,
    private aiService: ApplicationInsightsService
  ) {
    const token = this.authService.getLoggedInUserToken();
    this.headers = new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    });
    this.basketSubject = new BehaviorSubject<BasketItem[]>([]);
    this.basket$ = this.basketSubject.asObservable();
  }

  addToBasket = (catalogItem: CatalogItem, quantity: number) => {
    this.http
      .post<BasketItem[]>(
        this.basketApiUrl,
        { id: catalogItem.id, name: catalogItem.name, price: catalogItem.price, quantity },
        { headers: this.headers }
      )
      .subscribe((response) => {
        this.basketSubject.next(response);
      });
  };

  clearBasket = () => {
    this.http
      .delete(this.basketApiUrl, { headers: this.headers })
      .subscribe((response) => this.basketSubject.next([]));
  };

  checkout = () => {
    try {
      this.aiService.logEvent("checkout", {
        cart: this.basketSubject.getValue(),
      });
      throw new Error('An error occured when checking out');
    } catch (error) {
      console.error(error);
    }
  };
}

import { AuthService } from "src/app/services/auth.service";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BasketItem } from "../models/basket-item.model";

@Injectable({
  providedIn: "root",
})
export class BasketService {
  private basket: BasketItem[];

  constructor(private http: HttpClient, private authService: AuthService) {}

  getBasket;
}

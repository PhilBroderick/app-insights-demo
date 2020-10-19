import { AuthService } from "src/app/services/auth.service";
import { environment } from "src/environments/environment";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CatalogItem } from "../models/catalog-item.model";

@Injectable({
  providedIn: "root",
})
export class CatalogService {
  catalogApiUrl = environment.catalogBaseUrl + "api/catalog";

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {}

  getCatalogItemsInStock = (): Observable<CatalogItem[]> => {
    const token = this.authService.getLoggedInUserToken();
    const headers = new HttpHeaders({
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    });

    return this.httpClient.get<CatalogItem[]>(this.catalogApiUrl, {
      headers: headers,
    });
  };
}

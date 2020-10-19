import { BasketService } from "./services/basket.service";
import { CatalogService } from "./services/catalog.service";
import { AuthService } from "./services/auth.service";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./components/login/login.component";
import { WeatherforecastComponent } from "./components/weatherforecast/weatherforecast.component";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { CatalogListComponent } from "./components/catalog-list/catalog-list.component";
import { CatalogItemComponent } from "./components/catalog-item/catalog-item.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { HomeComponent } from "./components/home/home.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    WeatherforecastComponent,
    CatalogListComponent,
    CatalogItemComponent,
    NavBarComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [AuthService, CatalogService, BasketService],
  bootstrap: [AppComponent],
})
export class AppModule {}

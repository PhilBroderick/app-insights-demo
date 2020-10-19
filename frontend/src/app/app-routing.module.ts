import { CatalogListComponent } from './components/catalog-list/catalog-list.component';
import { LoginComponent } from "./components/login/login.component";
import { WeatherforecastComponent } from "./components/weatherforecast/weatherforecast.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  { path: "", redirectTo: "catalog", pathMatch: "full" },
  { path: "catalog", component: CatalogListComponent },
  { path: "login", component: LoginComponent },
  { path: "weather", component: WeatherforecastComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

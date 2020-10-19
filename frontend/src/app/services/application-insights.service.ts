import { Injectable } from "@angular/core";
import { ApplicationInsights } from "@microsoft/applicationinsights-web";
import { Subscription } from "rxjs";
import { filter } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { ActivatedRouteSnapshot, ResolveEnd, Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class ApplicationInsightsService {
  private routerSubscription: Subscription;
  private appInsights: ApplicationInsights;

  constructor(private router: Router) {
    this.appInsights = new ApplicationInsights({
      config: {
        instrumentationKey: environment.appInsights.instrumentationKey,
        enableAutoRouteTracking: true, // option to log all route changes
        disableCorrelationHeaders: false,
        enableCorsCorrelation: true,
      },
    });

    this.appInsights.loadAppInsights();

    this.appInsights.addTelemetryInitializer((envelope) => {
      envelope.tags["ai.cloud.role"] = "frontend";
    });

    this.routerSubscription = this.router.events
      .pipe(filter((event) => event instanceof ResolveEnd))
      .subscribe((event: ResolveEnd) => {
        const activatedComponent = this.getActivatedComponent(event.state.root);
        if (activatedComponent) {
          this.logPageView(
            `${activatedComponent.name} ${this.getRouteTemplate(
              event.state.root
            )}`,
            event.urlAfterRedirects
          );
          this.appInsights.flush(); // used in Debug - doesn't require waiting for browser to close to send telemetry
        }
      });
  }

  logPageView = (name?: string, url?: string) => {
    this.appInsights.trackPageView({
      name,
      uri: url,
    });
  };

  logEvent = (name: string, properties?: { [key: string]: any }) => {
    this.appInsights.trackEvent({ name }, properties);
  };

  setUserId = (userId: string) =>
    this.appInsights.setAuthenticatedUserContext(userId);

  private getActivatedComponent(snapshot: ActivatedRouteSnapshot): any {
    if (snapshot.firstChild) {
      return this.getActivatedComponent(snapshot.firstChild);
    }

    return snapshot.component;
  }

  private getRouteTemplate(snapshot: ActivatedRouteSnapshot): string {
    let path = "";
    if (snapshot.routeConfig) {
      path += snapshot.routeConfig.path;
    }

    if (snapshot.firstChild) {
      return path + this.getRouteTemplate(snapshot.firstChild);
    }

    return path;
  }
}

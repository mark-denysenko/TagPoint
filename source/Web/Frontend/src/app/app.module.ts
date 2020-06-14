import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing.module";
import { AppErrorHandler } from "./core/handlers/error.handler";
import { AppHttpInterceptor } from "./core/interceptors/http.interceptor";
import { DirectivesModule } from "./core/directives/directives.module";
import { APP_BASE_HREF } from "@angular/common";
import { AgmCoreModule } from "@agm/core";
import { environment } from "src/environments/environment";
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        DirectivesModule,
        AgmCoreModule.forRoot({
          apiKey: environment.keys.gmap,
          // from documentation - uk (Ukrainian)
          language: 'uk',
          region: 'ua',
          libraries: ["places", "geometry"]
        }),
        NoopAnimationsModule
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true },
        { provide: APP_BASE_HREF, useValue: '/' }
    ]
})
export class AppModule { }

import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing.module";
import { AppErrorHandler } from "./core/handlers/error.handler";
import { AppHttpInterceptor } from "./core/interceptors/http.interceptor";
import { DirectivesModule } from "./core/directives/directives.module";
import { APP_BASE_HREF } from "@angular/common";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        DirectivesModule
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true },
        { provide: APP_BASE_HREF, useValue: '/' }
    ]
})
export class AppModule { }

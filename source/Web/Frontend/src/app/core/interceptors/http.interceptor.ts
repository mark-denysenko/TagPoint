import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AppTokenService } from "../services/token.service";
import { catchError } from "rxjs/operators";
import { throwError } from "rxjs";
import { Router } from "@angular/router";

@Injectable({ providedIn: "root" })
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private readonly appTokenService: AppTokenService, private readonly router: Router) { }

    intercept(request: HttpRequest<any>, next: HttpHandler) {
        request = request.clone({
            setHeaders: { Authorization: `Bearer ${this.appTokenService.get()}` }
        });

        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401) {
                this.router.navigate(["login"]);
            }

            //const error = err.error.message || err.statusText;
            return throwError(err);
        }));;
    }
}

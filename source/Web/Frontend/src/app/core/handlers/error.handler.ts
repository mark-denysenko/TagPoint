import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable, Injector, NgZone } from "@angular/core";
import { Router } from "@angular/router";
import { AppModalService } from "../services/modal.service";

@Injectable({ providedIn: "root" })
export class AppErrorHandler implements ErrorHandler {
    constructor(private readonly injector: Injector) { }

    handleError(error: any) {
        
        if (error instanceof HttpErrorResponse) {
            switch (error.status) {
                case 401: {
                    const ngZone = this.injector.get<NgZone>(NgZone);
                    const router = this.injector.get<Router>(Router);
                    console.log('error', { ngZone, router});
                    ngZone.run(() => router.navigate(["login"]));
                    return;
                }
                case 422: {
                    const appModalService = this.injector.get<AppModalService>(AppModalService);
                    appModalService.alert(error.error);
                    return;
                }
            }
        }

        console.error(error);
    }
}

import { Injectable } from "@angular/core";

declare let UIkit: any;

@Injectable({ providedIn: "root" })
export class AppModalService {
    alert(message: string): void {
        UIkit.modal.alert(message);
    }

    successfullySavedNotification(): void {
        UIkit.notification({message: 'Успішно збережено', pos: 'top-right', status: 'success', timeout: 3000});
    }

    errorNotification(message: string): void {
        UIkit.notification({message, pos: 'top-right', status: 'danger', timeout: 3000});
    }
}

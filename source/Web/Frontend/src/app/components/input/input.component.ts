import { AppBaseComponent } from "../base/base.component";
import { ViewChild, ElementRef } from "@angular/core";

export abstract class AppInputComponent extends AppBaseComponent<any> {
    @ViewChild('input', {static: false}) inputElement!: ElementRef;
    
    constructor(type: string) {
        super();
        this.type = type;
    }

    type!: string;

    input($event: any): void {
        this.value = $event.target.value;
    }
}

import { Component, OnInit } from "@angular/core";
import { environment } from "src/environments/environment";

declare var google: any;

@Component({ selector: "app-root", templateUrl: "./app.component.html" })
export class AppComponent implements OnInit {
    ngOnInit(): void {
        this.loadScript();
    }

    async loadScript() {
        var oldScript = document.getElementById("agmGoogleMapsApiScript");
        if (oldScript !== null) {
            if (oldScript.parentNode) {
                oldScript.parentNode.removeChild(oldScript);
            }
            delete google.maps;
        }
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.async = true;
        script.src = 'https://maps.googleapis.com/maps/api/js?v=3&key=' + environment.keys.gmap + '&region=ua&language=uk';
        script.id = "agmGoogleMapsApiScript";
        document.body.appendChild(script);
        await new Promise(resolve => setTimeout(resolve, 1000));
    } 
}

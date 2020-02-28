import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { Country } from "src/typing";

const apiUrl = environment.apiBaseUrl;

@Injectable({ providedIn: "root" })
export class GeolocationService {
    constructor(private readonly http: HttpClient) {}

    public getCountries(): Observable<Country[]> {
        return this.http.get<Country[]>(`${apiUrl}Countries`);
    }
}
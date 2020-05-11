import { HttpClient, HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, BehaviorSubject } from "rxjs";
import { environment } from "src/environments/environment";
import { tap } from "rxjs/operators";

const apiUrl = environment.apiBaseUrl;

@Injectable({ providedIn: "root" })
export class RecommendationService {
    public preferredTypes$ = new  BehaviorSubject<string[]>([]);

    constructor(private readonly http: HttpClient) { }

    public selectRecommendation(tag: string): Observable<string[]> {
        return this.http.post<string[]>(`${apiUrl}Statistic/userTypeSeletions`, { tag }).pipe(
            tap((types: string[]) => this.preferredTypes$.next(types))
        );
    }

    public getUserPreferredTypes(): void {
        this.http.get<string[]>(`${apiUrl}Statistic/userPreferredTypes`).subscribe(types => this.preferredTypes$.next(types));
    }
}

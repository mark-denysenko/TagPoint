import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { AddPostModel } from "../models/post/add.post.model";
import { Observable } from "rxjs";

const apiUrl = environment.apiBaseUrl;

@Injectable({ providedIn: "root" })
export class AppPostService {
    constructor(private readonly http: HttpClient) {}

    public add(addPostModel: AddPostModel): Observable<Marker[]> {
        return this.http.post<Marker[]>(`${apiUrl}Post`, addPostModel);
    }

    public getMarkersWithPostsInRadius(center: Coordinate, radius: number): Observable<Marker[]> {
        return this.http.get<Marker[]>(`${apiUrl}Post/${center.latitude}/${center.longitude}/${radius}`);
    }
}
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { AddPostModel } from "../models/post/add.post.model";
import { Observable } from "rxjs";
import { MarkerWithPosts, Coordinate } from "src/typing";

const apiUrl = environment.apiBaseUrl;

@Injectable({ providedIn: "root" })
export class AppPostService {
    constructor(private readonly http: HttpClient) {}

    public add(addPostModel: AddPostModel): Observable<MarkerWithPosts[]> {
        return this.http.post<MarkerWithPosts[]>(`${apiUrl}Post`, addPostModel);
    }

    public getMarkersWithPostsInRadius(center: Coordinate, radius: number): Observable<MarkerWithPosts[]> {
        return this.http.get<MarkerWithPosts[]>(`${apiUrl}Post/${center.latitude}/${center.longitude}/${radius}`);
    }
}
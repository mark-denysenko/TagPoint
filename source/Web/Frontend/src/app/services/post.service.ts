import { HttpClient, HttpParams } from "@angular/common/http";
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

    public getUserPosts(): Observable<any[]> {
        return this.http.get<any[]>(`${apiUrl}Post/My`);
    }

    public deletePost(postId: number): Observable<any> {
        let httpParams = new HttpParams();
        httpParams.set('postId', postId.toString());

        let options = { params: httpParams };
        return this.http.delete<any>(`${apiUrl}Post/` + postId, options);
    }

    public toggleLike(postId: number): Observable<any> {
        return this.http.post<any>(`${apiUrl}Post/toggleLike`, {postId});
    }
}
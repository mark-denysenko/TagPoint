import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";
import { AppTokenService } from "../core/services/token.service";
import { RegisterModel, SignInModel } from "../models/signIn.model";
import { TokenModel } from "../models/token.model";
import { AddUserModel } from "../models/user/add.user.model";
import { UpdateUserModel } from "../models/user/update.user.model";
import { UserModel } from "../models/user/user.model";
import { Observable } from "rxjs";

const apiUrl = environment.apiBaseUrl;

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    add(addUserModel: AddUserModel) {
        return this.http.post<number>(`${apiUrl}Users`, addUserModel);
    }

    delete(id: number) {
        return this.http.delete(`${apiUrl}Users/${id}`);
    }

    list() {
        return this.http.get<UserModel[]>(`${apiUrl}Users`);
    }

    select(id: number) {
        return this.http.get<UserModel>(`${apiUrl}Users/${id}`);
    }

    register(signInModel: RegisterModel): void {
        this.http
            .post<TokenModel>(`${apiUrl}Users/Register`, signInModel)
            .subscribe((tokenModel) => {
                if (!tokenModel || !tokenModel.token) { return; }
                this.appTokenService.set(tokenModel.token);
                this.router.navigate(["/main/map"]);
            });
    }

    signIn(signInModel: SignInModel): void {
        this.http
            .post<TokenModel>(`${apiUrl}Users/SignIn`, signInModel)
            .subscribe((tokenModel) => {
                if (!tokenModel || !tokenModel.token) { return; }
                this.appTokenService.set(tokenModel.token);
                this.router.navigate(["/main/map"]);
            });
    }

    signOut() {
        if (this.appTokenService.any()) {
            this.http.post(`${apiUrl}Users/SignOut`, {}).subscribe();
        }

        this.appTokenService.clear();
        this.router.navigate(["/login"]);
    }

    update(updateUserModel: UpdateUserModel) {
        return this.http.put(`Users/${updateUserModel.id}`, updateUserModel);
    }

    public getProfile(): Observable<any> {
        return this.http.get<any>(`${apiUrl}Users/Profile`);
    }

    public uploadAvatar(avatar: any): Observable<any> {
        const formData = new FormData();
        formData.append('file', avatar, avatar.name);

        return this.http.post<any>(`${apiUrl}Users/SetAvatar`, formData);
        
        // this.http.post('https://localhost:5001/api/upload', formData, {reportProgress: true, observe: 'events'})
        // .subscribe(event => {
        //   if (event.type === HttpEventType.UploadProgress)
        //     this.progress = Math.round(100 * event.loaded / event.total);
        //   else if (event.type === HttpEventType.Response) {
        //     this.message = 'Upload success.';
        //     this.onUploadFinished.emit(event.body);
        //   }
        // });
    }
}

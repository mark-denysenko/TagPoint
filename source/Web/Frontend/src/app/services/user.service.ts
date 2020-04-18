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
import { Observable, BehaviorSubject } from "rxjs";
import { UserProfileModel } from "../models/user/user-profile.model";
import { tap } from "rxjs/operators";

const apiUrl = environment.apiBaseUrl;

@Injectable({ providedIn: "root" })
export class AppUserService {
    public currentUser$: BehaviorSubject<UserProfileModel> = new BehaviorSubject<UserProfileModel>({} as UserProfileModel);

    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        this.getProfile().subscribe(user => this.currentUser$.next(user));
    }

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
        console.log(updateUserModel);
        
        return this.http.put(`${apiUrl}Users/${updateUserModel.id}`, updateUserModel);
    }

    public changePassword(userId: number, oldPassword: string, newPassword: string): Observable<any> {
        return this.http.post<any>(`${apiUrl}Users/ChangePassword`, {userId, oldPassword, newPassword});
    }

    public getProfile(): Observable<any> {
        return this.http.get<any>(`${apiUrl}Users/Profile`).pipe(tap(user => this.currentUser$.next(user)));
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

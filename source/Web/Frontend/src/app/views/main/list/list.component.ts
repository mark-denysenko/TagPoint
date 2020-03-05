import { Component } from "@angular/core";
import { Cacheable } from "ngx-cacheable";
import { AppPostService } from "src/app/services/post.service";

@Component({ selector: "app-list", templateUrl: "./list.component.html" })
export class AppListComponent {
    public userPosts: any[] = [];

    constructor(private readonly postService: AppPostService) {
        this.postService.getUserPosts().subscribe(posts => this.userPosts = posts);
    }

}

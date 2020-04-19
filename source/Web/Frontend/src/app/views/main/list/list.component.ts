import { Component, OnInit } from "@angular/core";
import { AppPostService } from "src/app/services/post.service";
import { AppModalService } from "src/app/core/services/modal.service";
import { FormControl } from "@angular/forms";
import { debounceTime } from "rxjs/operators";

@Component({ 
    selector: "app-list", 
    templateUrl: "./list.component.html",
    styleUrls: ['./list.component.scss'] 
})
export class AppListComponent implements OnInit {
    public userPosts: any[] = [];
    public keyword = new FormControl('');

    public orderByLikes: boolean | null = null;
    public orderByDate: boolean | null = null;

    constructor(private readonly postService: AppPostService, private readonly modalService: AppModalService) {
    }

    ngOnInit(): void {
        this.keyword.valueChanges
            .pipe(debounceTime(800))
            .subscribe(status => this.getPosts());
        this.getPosts();
    }

    public deletePost(post: any): void {
        this.postService.deletePost(post.id).subscribe(_ => {
            this.userPosts = this.userPosts.filter(p => p.id !== post.id);
        });
    }

    public getPosts(): void {
        this.postService.getUserPosts(this.keyword.value, this.orderByDate, this.orderByLikes)
            .subscribe(posts => this.userPosts = posts);
    }

    public sortBy(likes: boolean, date: boolean): void {
        this.orderByLikes = this.orderByLikes && likes ? !this.orderByLikes : likes;
        this.orderByDate = this.orderByDate && date ? !this.orderByDate : date;

        this.getPosts();
    }
}

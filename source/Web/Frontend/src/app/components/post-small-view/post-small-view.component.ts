import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PostModel } from 'src/app/models/post/post.model';

@Component({
  selector: 'app-post-small-view',
  templateUrl: './post-small-view.component.html',
  styleUrls: ['./post-small-view.component.scss']
})
export class PostSmallViewComponent implements OnInit {

  @Input() public post!: PostModel;
  @Output() public deletePost = new EventEmitter<number>();
  @Output() public toggleLikePost = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  public handleDeletePost(): void {
    this.deletePost.emit(this.post.id);
  }

  public handleLikePost(): void {
    this.toggleLikePost.emit(this.post.id);
  }

}

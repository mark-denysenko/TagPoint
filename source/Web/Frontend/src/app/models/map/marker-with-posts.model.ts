import { PostModel } from "../post/post.model";

interface MarkerWithPosts extends Marker {
  posts: PostModel[];
}
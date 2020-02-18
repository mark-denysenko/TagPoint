import { PostModel } from "../post/post.model";

interface Marker {
    id?: number,
    latitude: number;
    longitude: number;
    label?: string;
}

interface MarkerWithPosts extends Marker {
  posts: PostModel[];
}
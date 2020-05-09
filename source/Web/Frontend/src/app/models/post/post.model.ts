export class PostModel {
    id!: number;
    message!: string;
    recommended!: boolean;
    location!: string;
    marker!: Marker;
    userId!: number;
    username!: string;
    creationDate!: string;
    liked!: boolean;
    timesLiked!: number;
    editable!: boolean;
    userAvatar!: string;
    tags!: string[];
}

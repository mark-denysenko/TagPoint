export enum Roles {
    None = 0,
    User = 1,
    Admin = 2
};

export enum Gender {
    Male = 0,
    Female = 1
};

interface Coordinate {
    latitude: number,
    longitude: number,
    //altitude: number
}

interface MarkerWithPosts extends Marker {
    posts: PostModel[];
}

interface Country {
    id: number,
    country: string,
    countryCode: string
}

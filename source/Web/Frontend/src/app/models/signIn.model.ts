export class SignInModel {
    login!: string;
    password!: string;
}

export class RegisterModel {
    username!: string;
    signIn!: SignInModel;
    email!: string;
    phone!: string;
    gender!: number;
    country!: number;
}

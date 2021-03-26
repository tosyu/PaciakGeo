export default interface IAuthService {
    getToken(): string;
    login(): Promise<boolean>;
}

export const IAuthServiceType = Symbol.for("IAuthService");
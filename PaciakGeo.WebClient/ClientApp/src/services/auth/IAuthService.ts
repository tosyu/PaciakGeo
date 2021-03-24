import AuthorizationResult from "../../models/AuthorizationResult";

export default interface IAuthService {
    getAuthorization(): Promise<AuthorizationResult>;
}

export const IAuthServiceType = Symbol.for("IAuthService");
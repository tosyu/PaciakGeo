import {injectable} from "inversify";
import IAuthService from "./IAuthService";
import AuthorizationResult from "../../models/AuthorizationResult";

@injectable()
class AuthService implements IAuthService {
    getAuthorization(): Promise<AuthorizationResult> {
        return Promise.resolve(undefined);
    }
    
}

export default AuthService;
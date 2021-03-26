import {injectable} from "inversify";
import axios from "axios";

import AuthorizationResult from "../../models/AuthorizationResult";
import IBrowserService, {IBrowserServiceType} from "../browser/IBrowserService";
import {resolve} from "../../ioc";
import IReduxService, {IReduxServiceType} from "../redux/IReduxService";
import {userSlice} from "../../redux/user/user-slice";
import {Api} from "../../models/Api";

import AuthError from "./AuthError";
import IAuthService from "./IAuthService";


@injectable()
class AuthService implements IAuthService {
    token: string;
    
    private browserService: IBrowserService;
    private reduxService: IReduxService;
    
    constructor() {
        this.browserService = resolve<IBrowserService>(IBrowserServiceType);
        this.reduxService = resolve<IReduxService>(IReduxServiceType);
    }

    getToken(): string {
        return this.token;
    }

    async login(): Promise<boolean> {
        const result = await axios.post<AuthorizationResult>(Api.LOGIN);
        
        if (result.status === 200) {
            this.token = result.data.token;
            
            const store = this.reduxService.getStore();
            if (store) {
                store.dispatch(userSlice.actions.load(result.data.user));
            }
            
            return Promise.resolve(true);
        }
        
        if (result.data.redirectUrl) {
            this.browserService.redirectWindowAsync(`${result.data.redirectUrl}?returnTo=${this.browserService.encodeUri(this.browserService.getCurrentLocation())}`);
        } else {
            throw new AuthError("Could not redirect user to login service");
        }
        
        return Promise.resolve(false);
    }
    
}

export default AuthService;
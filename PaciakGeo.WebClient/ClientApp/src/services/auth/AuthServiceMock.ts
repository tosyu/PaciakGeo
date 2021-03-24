import IAuthService from "./IAuthService";
import {injectable} from "inversify";
import AuthorizationResult from "../../models/AuthorizationResult";
import IBrowserService, {IBrowserServiceType} from "../browser/IBrowserService";
import {resolve} from "../../ioc";

@injectable()
class AuthServiceMock implements IAuthService {
    private browserService: IBrowserService;

    constructor() {
        this.browserService = resolve<IBrowserService>(IBrowserServiceType);
    }

    getAuthorization(): Promise<AuthorizationResult> {
        if (this.browserService.getFromLocalStorage("authorizedMock", "no") === "yes") {
            return Promise.resolve({
                success: true,
                token: "1234567",
                user: {
                    name: "MockUser",
                    location: "MockLocation",
                    picture: "",
                    slug: "mockuser",
                    uid: -1
                }
            });
        }

        this.browserService.setToLocalStorage("authorizedMock", "yes");
        return Promise.resolve({
            success: false,
            redirectUrl: `https://paciak.pl/login?returnTo=${this.browserService.encodeUri(this.browserService.getCurrentLocation())}`
        });
    }
}

export default AuthServiceMock;

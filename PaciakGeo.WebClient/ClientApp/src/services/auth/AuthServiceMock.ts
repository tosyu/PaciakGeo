import IAuthService from "./IAuthService";
import {injectable} from "inversify";
import IBrowserService, {IBrowserServiceType} from "../browser/IBrowserService";
import {resolve} from "../../ioc";

@injectable()
class AuthServiceMock implements IAuthService {
    private browserService: IBrowserService;

    constructor() {
        this.browserService = resolve<IBrowserService>(IBrowserServiceType);
    }

    login(): Promise<boolean> {
        if (this.browserService.getFromLocalStorage("authorizedMock", "no") === "yes") {
            return Promise.resolve(true);
        }

        this.browserService.setToLocalStorage("authorizedMock", "yes");
        this.browserService.redirectWindowAsync(`https://paciak.pl/login?returnTo=${this.browserService.encodeUri(this.browserService.getCurrentLocation())}`)

        return Promise.resolve(false);
    }

    getToken(): string {
        return this.browserService.getFromLocalStorage("authorizedMock", "no") === "no" ? null :"test-mock-token";
    }
}

export default AuthServiceMock;

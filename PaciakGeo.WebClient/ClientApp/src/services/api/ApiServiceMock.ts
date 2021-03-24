import IApiService from "./IApiService";
import MapUser from "../../models/MapUser";
import {Api} from "../../models/Api";
import {injectable} from "inversify";
import IAuthService, {IAuthServiceType} from "../auth/IAuthService";
import {resolve} from "../../ioc";
import IBrowserService, {IBrowserServiceType} from "../browser/IBrowserService";

@injectable()
export default class ApiServiceMock implements IApiService {
    private authService: IAuthService;
    private browserService: IBrowserService;

    constructor() {
        this.authService = resolve<IAuthService>(IAuthServiceType);
        this.browserService = resolve<IBrowserService>(IBrowserServiceType);
    }
    async get<T>(endpoint: string): Promise<T> {
        switch (endpoint) {
            case Api.GET_USERS:
                const users: Array<MapUser> = [
                    {
                        Uid: 0,
                        Name: "test1",
                        AvatarUrl: "https://www.gravatar.com/avatar/f5a492b2c0ec12f55f2a00879d7c12da?size=192&d=mm",
                        LocationLongitude: 22.016143457294312,
                        LocationLatitude: 50.013064
                    },
                    {
                        Uid: 1,
                        Name: "test2",
                        AvatarUrl: "/assets/uploads/profile/427-profileavatar.png",
                        LocationLongitude: 16.97819633051261,
                        LocationLatitude: 51.1263106
                    },
                ];

                const response = await this.authService.getAuthorization();
                if (response.success) {
                    return await new Promise(resolve => {
                        setTimeout(() => {
                            resolve(users as unknown as T);
                        }, 1500);
                    });
                }
                
                if (typeof response.redirectUrl === "string") {
                    this.browserService.redirectWindowAsync(response.redirectUrl, 100);
                }
                return null;
            default:
                return null;
        }
    }
}

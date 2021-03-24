import IUsersService from "./IUsersService";
import {injectable} from "inversify";
import IApiService, {IApiServiceType} from "../api/IApiService";
import MapUser from "../../models/MapUser";
import {Api} from "../../models/Api";
import {resolve} from "../../ioc";

@injectable()
export default class UserService implements IUsersService {
    private readonly apiService: IApiService;

    constructor() {
        this.apiService = resolve<IApiService>(IApiServiceType);        
    }

    async getMapUsers() {
        return await this.apiService.get<Array<MapUser>>(Api.GET_USERS);
    }
}

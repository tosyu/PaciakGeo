import IApiService from "./IApiService";
import {injectable} from "inversify";
import IAuthService, {IAuthServiceType} from "../auth/IAuthService";
import {resolve} from "../../ioc";
import axios from "axios";
import ILogService, {ILogServiceType} from "../log/ILogService";
import {LogLevel} from "../../models/LogLevel";

@injectable()
export default class ApiServiceMock implements IApiService {
    private authService: IAuthService;
    private logService: ILogService;

    constructor() {
        this.authService = resolve<IAuthService>(IAuthServiceType);
        this.logService = resolve<ILogService>(ILogServiceType);
    }

    async get<T>(endpoint: string): Promise<T> {
        const token = this.authService.getToken();

        if (!token) {
            const loginResult = await this.authService.login();

            if (!loginResult) {
                return null;
            }
        }

        this.logService.log(LogLevel.DEBUG, `GET ${endpoint}`);

        const response = await axios.get<T>(`/mock${endpoint}.json`);

        return response.data;
    }

    async post<T, E>(endpoint: string, data?: E): Promise<T> {
        const token = this.authService.getToken();

        if (!token) {
            const loginResult = await this.authService.login();

            if (!loginResult) {
                return null;
            }
        }

        this.logService.log(LogLevel.DEBUG, `GET ${endpoint}`, data);

        const response = await axios.get<T>(`/mock${endpoint}.json`);

        return response.data;
    }
}

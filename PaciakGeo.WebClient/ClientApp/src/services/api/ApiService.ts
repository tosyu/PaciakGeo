import {injectable} from "inversify";
import axios, {AxiosRequestConfig, Method} from 'axios';

import IApiService from "./IApiService";
import {resolve} from "../../ioc";
import IAuthService, {IAuthServiceType} from "../auth/IAuthService";
import ApiError from "./ApiError";
import ILogService, {ILogServiceType} from "../log/ILogService";
import {LogLevel} from "../../models/LogLevel";

@injectable()
export default class ApiService implements IApiService {
    private authService: IAuthService;
    private logService: ILogService;

    constructor() {
        this.authService = resolve<IAuthService>(IAuthServiceType);
        this.logService = resolve<ILogService>(ILogServiceType);
    }
    
    async call<T, E>(method: Method, endpoint: string, data?: E) {
        const token = this.authService.getToken();

        this.logService.log(LogLevel.DEBUG, `${method} ${endpoint}`, data);

        const config: AxiosRequestConfig = {
            method,
            url: endpoint,
            headers: {
                Authorization: `Bearer ${token}`
            },
            data
        }
        
        if (!token && await this.authService.login() === false) {
            return null;
        }

        let response = await axios.request<T>(config);

        if (response.status === 403) {
            this.logService.log(LogLevel.ERROR, "User not authorized");

            if (await this.authService.login() === false) {
                return Promise.resolve(null);
            } else {
                const token = this.authService.getToken();
                
                config.headers.Authorization = `Bearer ${token}`;
                response = await axios.request<T>(config);
            }
        }

        if (response.status !== 200) {
            throw new ApiError(`Api error (${response.status}): ${response.data}`);
        }

        return response.data;
    }

    async get<T>(endpoint: string): Promise<T> {
        return await this.call<T, any>("GET", endpoint);
    }
    
    async post<T, E>(endpoint: string, data?: E) {
        return await this.call<T, E>("POST", endpoint, data);
    }
}

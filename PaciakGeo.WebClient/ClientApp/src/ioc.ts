import {Container, interfaces} from 'inversify';
import {IUserServiceType} from "./services/users/IUsersService";
import UserService from "./services/users/UserService";
import ApiService from "./services/api/ApiService";
import {IApiServiceType} from "./services/api/IApiService";
import SettingsService from "./services/settings/SettingsService";
import ISettingsService, {ISettingsServiceType} from "./services/settings/ISettingsService";
import ApiServiceMock from "./services/api/ApiServiceMock";
import AuthServiceMock from "./services/auth/AuthServiceMock";
import {IAuthServiceType} from "./services/auth/IAuthService";
import AuthService from "./services/auth/AuthService";
import {BrowserService} from "./services/browser/BrowserService";
import {IBrowserServiceType} from "./services/browser/IBrowserService";
import LogService from "./services/log/LogService";
import {ILogServiceType} from "./services/log/ILogService";
import ReduxService from "./services/redux/ReduxService";
import {IReduxServiceType} from "./services/redux/IReduxService";

const container = new Container();

export function resolve<T>(identifier: interfaces.ServiceIdentifier<T>): T {
    return container.get<T>(identifier);
}

container.bind<UserService>(IUserServiceType).to(UserService);
container.bind<SettingsService>(ISettingsServiceType).to(SettingsService);
container.bind<BrowserService>(IBrowserServiceType).to(BrowserService);
container.bind<LogService>(ILogServiceType).to(LogService);
container.bind<ReduxService>(IReduxServiceType).to(ReduxService);

if (resolve<ISettingsService>(ISettingsServiceType).isDevelopment()) {
    container.bind<ApiServiceMock>(IApiServiceType).to(ApiServiceMock);
    container.bind<AuthServiceMock>(IAuthServiceType).to(AuthServiceMock);
} else {
    container.bind<ApiService>(IApiServiceType).to(ApiService);
    container.bind<AuthService>(IAuthServiceType).to(AuthService);
}

export default container;

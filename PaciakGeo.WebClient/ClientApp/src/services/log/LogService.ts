import ILogService from "./ILogService";
import {resolve} from "../../ioc";
import ISettingsService, {ISettingsServiceType} from "../settings/ISettingsService";
import {LogLevel} from "../../models/LogLevel";
import {injectable} from "inversify";

@injectable()
export default class LogService implements ILogService {
    private settingsService: ISettingsService;
    constructor() {
        this.settingsService = resolve<ISettingsService>(ISettingsServiceType);
    }

    log(level: LogLevel, ...data: any): void {
        if (this.settingsService.isDevelopment()) {
            switch (level) {
                case LogLevel.INFO:
                    console.info(...data);
                    break;
                case LogLevel.ERROR:
                    console.error(...data);
                    break;
                case LogLevel.DEBUG:
                    console.debug(...data);
                    break;
            }
        }
    }
} 
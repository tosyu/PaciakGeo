import ISettingsService from "./ISettingsService";
import {Settings} from "../../models/Settings";
import {injectable} from "inversify";
import EnvironmentDevelop from "../../models/EnvironmentDevelop";

interface SettingsContainer {
    [key: string]: any;
}

@injectable()
export default class SettingsService implements ISettingsService {
    private settings: SettingsContainer = {};
    
    get<T>(key: string): T {
        if (Object.keys(this.settings).indexOf(key) > -1) {
            return this.settings[key];
        }
        
        return (process.env[key] as any) as T;
    }

    isDevelopment(): boolean {
        return this.get<string>(Settings.ENVIRONMENT) === EnvironmentDevelop;
    }

    set<T>(key: string, value: T): void {
        this.settings[key] = value;
    }
}

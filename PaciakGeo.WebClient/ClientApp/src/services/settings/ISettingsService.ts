export default interface ISettingsService {
    get<T>(key: string): T;
    set<T>(key: string, value: T): void;
    isDevelopment(): boolean;
}

export const ISettingsServiceType = Symbol.for("ISettingsServiceType");

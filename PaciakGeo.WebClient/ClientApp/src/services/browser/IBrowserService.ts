export default interface IBrowserService {
    redirectWindow(url: string): void;
    redirectWindowAsync(url: string, timeout?: number): void;
    encodeUri(uri: string): string;
    decodeUri(uri: string): string;
    getCurrentLocation(): string;
    setToLocalStorage(key: string, value: string): void;
    getFromLocalStorage(key: string, def: string): string;
}

export const IBrowserServiceType = Symbol.for("IBrowserService");

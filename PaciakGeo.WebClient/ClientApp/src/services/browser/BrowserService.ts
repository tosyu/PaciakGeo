import IBrowserService from "./IBrowserService";
import {injectable} from "inversify";

@injectable()
export class BrowserService implements IBrowserService {
    redirectWindow(url: string): void {
        window.location.href = url;
    }

    redirectWindowAsync(url: string, timeout = 15): void {
        window.setTimeout(() => this.redirectWindow(url), timeout);
    }

    decodeUri(uri: string): string {
        return window.decodeURI(uri);
    }

    encodeUri(uri: string): string {
        return window.encodeURI(uri);
    }

    getCurrentLocation(): string {
        return window.location.href;
    }
    
    setToLocalStorage(key: string, value: string): void {
        window.localStorage.setItem(key, value);
    }
    
    getFromLocalStorage(key: string, def: string): string {
        return window.localStorage.getItem(key) ?? def;
    }
}
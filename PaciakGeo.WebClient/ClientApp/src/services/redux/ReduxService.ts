import IReduxService from "./IReduxService";
import {EnhancedStore} from "@reduxjs/toolkit";
import {injectable} from "inversify";

@injectable()
export default class ReduxService implements IReduxService {
    private store: EnhancedStore;

    getStore(): EnhancedStore {
        return this.store;
    }

    setStore(store: EnhancedStore): void {
        this.store = store;
    }
}

import {EnhancedStore} from "@reduxjs/toolkit";

export default interface IReduxService {
    getStore(): EnhancedStore;
    setStore(store: EnhancedStore): void;
}

export const IReduxServiceType = Symbol.for("IReduxServiceType");


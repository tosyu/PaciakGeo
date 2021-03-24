import {configureStore} from "@reduxjs/toolkit";
import {mapUsersSlice} from "./map-users/map-users-slice";
import RootState from "../models/RootState";

const setupStore = (initialState?: RootState) => {
    return configureStore<RootState>({
        devTools: true,
        reducer: {
            "mapUsers": mapUsersSlice.reducer
        },
        preloadedState: initialState
    });
}

export default setupStore;

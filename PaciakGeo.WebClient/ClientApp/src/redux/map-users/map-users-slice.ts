import {createSlice} from "@reduxjs/toolkit";

import * as mapUsersActions from "./map-users-actions";

import MapUsersState from "../../models/MapUsersState";
import {LoadingState} from "../../models/LoadingState";

const initialState: MapUsersState = {
    users: [],
    loading: LoadingState.Idle
}

export const mapUsersSlice = createSlice({
    name: "mapUsers",
    initialState,
    reducers: {},
    extraReducers: builder => {
       builder.addCase(mapUsersActions.loadUsers.fulfilled, (state, action) => {
           state.users = action.payload;
           state.loading = LoadingState.Idle;
       });

       builder.addCase(mapUsersActions.loadUsers.pending, (state) => {
           state.loading = LoadingState.Loading;
       });
    }
});
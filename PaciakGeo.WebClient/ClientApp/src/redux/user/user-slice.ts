import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {User} from "../../models/User";

const initialState: User = {
    uid: -1,
    slug: null,
    picture: null,
    location: null,
    name: 'Not logged'
}

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        load: (state: User, action: PayloadAction<User>) => {
            Object.assign(state, action.payload);
        },
        clear: (state: User) => {
            Object.assign(state, initialState);
        }
    }
});

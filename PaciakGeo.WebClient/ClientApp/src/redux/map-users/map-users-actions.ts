import {createAsyncThunk} from "@reduxjs/toolkit";
import IUsersService, {IUserServiceType} from "../../services/users/IUsersService";
import {resolve} from "../../ioc";

export const loadUsers = createAsyncThunk("mapUsers/load", async () => {
    const usersService = resolve<IUsersService>(IUserServiceType);

    return await usersService.getMapUsers();
});

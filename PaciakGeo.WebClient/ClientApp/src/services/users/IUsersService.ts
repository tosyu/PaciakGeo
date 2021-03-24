import MapUser from "../../models/MapUser";

export default interface IUsersService {
    getMapUsers(): Promise<Array<MapUser>>;
}

export const IUserServiceType = Symbol.for("IUsersService");

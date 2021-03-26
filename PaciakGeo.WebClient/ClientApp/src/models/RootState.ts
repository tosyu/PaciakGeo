import MapUsersState from "./MapUsersState";
import {User} from "./User";

export default interface RootState {
    mapUsers: MapUsersState;
    user: User;
}

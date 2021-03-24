import MapUser from "./MapUser";
import {LoadingState} from "./LoadingState";

export default interface MapUsersState {
    users: Array<MapUser>;
    loading: LoadingState
};

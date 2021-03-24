import {User} from "./User";

export default interface AuthorizationResult {
    success: boolean;
    token?: string;
    user?: User;
    redirectUrl?: string;
}

import config from '../Configuration/Config';
import { HttpClient } from './HttpClient';

class AuthClient extends HttpClient {
    // TODO:
    // public fetchUserInfo = () => {
    //     return this.get<Models.UserInfoDTO>(
    //         `/api/account`);
    // }
}

export const authClient = new AuthClient(config.authEndpoint);

import { loginManager } from '../Services/LoginManager';
import { createAction } from 'redux-actions';

export const TrySignInWithFacebookAction = createAction(
    'ACCOUNT/SIGN_IN_WITH_FACEBOOK', async (accessToken: string) => {
        return await loginManager.trySignInWithFacebook(accessToken);
    });
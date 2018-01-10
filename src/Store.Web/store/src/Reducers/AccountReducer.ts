import { TrySignInWithFacebookAction } from '../ActionCreators/AccountActionCreators';
import { AccountState, ApplicationState } from '../Store/Store';
import { Action } from 'redux-actions';

export const initialState: AccountState = {
    isSignedIn: false,
    signInError: ''
};

export const accountReducers: ReduxActions.ReducerMap<ApplicationState, any> = {
    [TrySignInWithFacebookAction.toString() + '_FULFILLED']: (state: ApplicationState, action: Action<boolean>): ApplicationState => {
        return {
            ...state,
            isSignedIn: action.payload,
            signInError: !action.payload ? 'Could not sign user with Facebook. Try again.' : null
        };
    }
};
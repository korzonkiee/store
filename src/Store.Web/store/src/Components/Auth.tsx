import { TrySignInWithFacebookAction } from '../ActionCreators/AccountActionCreators';
import * as React from 'react';
import { connect } from 'react-redux';
import { Card, CardTitle, CardText, TextField, CardActions, RaisedButton } from 'material-ui';
import FacebookLogin, { ReactFacebookLoginInfo } from 'react-facebook-login';
import config from '../Configuration/Config';
import { Dispatch } from 'redux';
import { User } from '../Models/User';
import { AccountState } from '../Store/Store';

interface AuthenticationProps {
    children?: React.ReactNode;
}

interface AuthenticationStateProps extends AuthenticationProps {
    isSigned: boolean;
    signInError?: string;
}

interface AuthenticationDispatchProps {
    signIn: (accessToken: string) => void;
}

interface FacebookResponse extends ReactFacebookLoginInfo {
    accessToken: string;
}

type LoginProps = AuthenticationStateProps & AuthenticationDispatchProps;

export class Login extends React.Component<LoginProps> {
    constructor(props: LoginProps) {
        super(props);
    }

    private signInWithFacebook = (response: FacebookResponse) => {
        this.props.signIn(response.accessToken);
    }

    render() {
        return !this.props.isSigned ?
            <div style={{ maxWidth: 600, margin: '5rem auto' }}>
                <form>
                    <Card containerStyle={{ textAlign: 'center', padding: '2rem 0' }}>
                        <CardTitle
                            title='Store'
                            subtitle={this.props.signInError}
                            subtitleStyle={{ marginTop: '12px' }} />

                        <CardText>
                            <FacebookLogin
                                appId={config.facebookAppId}
                                textButton='Sign in with Facebook'
                                callback={this.signInWithFacebook} />
                        </CardText>
                    </Card>
                </form>
            </div> : { ...this.props.children as any };
    }
}

const mapStateToProps = (state: AccountState, props: AuthenticationProps): AuthenticationStateProps => {
    return {
        ...props,
        isSigned: state.isSignedIn,
        signInError: state.signInError
    };
};

const mapDispatchToProps = (dispatch: Dispatch<any>): AuthenticationDispatchProps => {
    return {
        signIn: (accessToken: string) =>
            dispatch(TrySignInWithFacebookAction(accessToken))
    };
};

export const Auth = connect(
    mapStateToProps,
    mapDispatchToProps
)(Login);
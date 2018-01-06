import * as React from 'react';
import { Switch, Route } from 'react-router';
import Products from '../Containers/Products';

export class App extends React.Component<{}, {}> {
    public render() {
        return (
            <Switch>
                <Route exact path='/' render={() => <p>Store</p>}/>
                <Route path='/products' render={props => <Products {...props}/>} />
            </Switch>
        );
    }
}
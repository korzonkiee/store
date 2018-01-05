import * as React from 'react';
import ProductsList from '../Containers/ProductsList';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';

export class App extends React.Component<{}, {}> {
    public render() {
        return (
            <MuiThemeProvider>
                <ProductsList />
            </MuiThemeProvider>
        );
    }
}
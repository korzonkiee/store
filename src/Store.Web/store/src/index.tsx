import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { BrowserRouter } from 'react-router-dom';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { App } from './Components/App';
import store from './Store/Store';

ReactDOM.render(
  <BrowserRouter>
    <Provider store={store}>
        <MuiThemeProvider>
          <App />
        </MuiThemeProvider>
    </Provider>
  </BrowserRouter>,
  document.getElementById('app')
);
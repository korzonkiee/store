import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { App } from './Components/App';
import store from './Store/Store';

ReactDOM.render(
  <Provider store={store}>
    <App />
    </Provider>,
  document.getElementById('app')
);
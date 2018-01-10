import { loginManager } from '../Services/LoginManager';
import { applyMiddleware, combineReducers, createStore } from 'redux';
import { handleActions } from 'redux-actions';
import { Product } from '../Models/Product';
import { productsReducers, initialState } from '../Reducers/ProductsReducer';
import promiseMiddleware from 'redux-promise-middleware';
import { accountReducers } from '../Reducers/AccountReducer';

export interface ProductsState {
    products: Product[];
    selectedProduct: Product;
}

export interface AccountState {
    readonly isSignedIn: boolean;
    readonly signInError?: string;
}

export interface ApplicationState extends ProductsState, AccountState {
}

export const defaultState: ApplicationState = {
    isSignedIn: loginManager.isSigned,
    signInError: null,
    products: [],
    selectedProduct: null
};

const reducers = {
    ...productsReducers,
    ...accountReducers
};

const reducer = handleActions<ApplicationState>(reducers, defaultState);

const store = createStore(
    reducer,
    applyMiddleware(promiseMiddleware())
);

export default store;
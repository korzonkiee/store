import { applyMiddleware, combineReducers, createStore } from 'redux';
import { handleActions } from 'redux-actions';
import { Product } from '../Models/Product';
import { productsReducers, initialState } from '../Reducers/ProductsReducer';
import promiseMiddleware from 'redux-promise-middleware';

export interface ProductsState {
    products: Product[];
    selectedProduct: string;
}

export interface ApplicationState extends ProductsState {
}

export const defaultState: ApplicationState = {
    products: [],
    selectedProduct: null
};

const reducers = {
    ...productsReducers
};

const reducer = handleActions<ApplicationState>(reducers, defaultState);

const store = createStore(
    reducer,
    applyMiddleware(promiseMiddleware())
);

export default store;
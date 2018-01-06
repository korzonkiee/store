import { ApplicationState, ProductsState, defaultState } from '../Store/Store';
import { Reducer } from 'redux';
import {
    GetProductAction,
    GetProductsAction
} from '../ActionCreators/ProductActionCreators';
import { handleActions, Action, BaseAction} from 'redux-actions';
import { Product } from '../Models/Product';

export const initialState: ProductsState = {
    products: [],
    selectedProduct: null
};

export const productsReducers = {
    // [SelectProductAction.toString()]: (state: ProductsState, action: Action<SelectProductPayload>): ProductsState => {
    //     console.log(SelectProductAction.toString() + ' received');
    //     return {
    //         selectedProduct: action.payload.selectedProduct,
    //         ...state
    //     };
    // },
    [GetProductsAction.toString() + '_PENDING']: (state: ProductsState, action: BaseAction): ProductsState => {
        return state;
    },
    [GetProductsAction.toString() + '_REJECTED']: (state: ProductsState, action: Action<any>): ProductsState => {
        return state;
    },
    [GetProductsAction.toString() + '_FULFILLED']: (state: ProductsState, action: Action<Product[]>): ProductsState => {
        console.log(GetProductsAction.toString() + '_FULFILLED received');
        return {
            ...state,
            products: action.payload
        };
    },
    [GetProductAction.toString() + '_FULFILLED']: (state: ProductsState, action: Action<Product>): ProductsState => {
        console.log(GetProductsAction.toString() + '_FULFILLED received');
        return {
            ...state,
            selectedProduct: action.payload
        };
    }
};
    // [SelectProductAction.toString()]: (state: ApplicationState, action: Action<Payload>): ApplicationState => {
    //     return {
    //         ...state,
    //         selectedProduct: action.payload.selectedProduct
    //     };
    // }
// };
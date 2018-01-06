import { Product } from '../Models/Product';
import { ApplicationState, ProductsState, defaultState } from '../Store/Store';
import { Action, ActionCreator, Dispatch } from 'redux';
import { createAction } from 'redux-actions';
import { ThunkAction } from 'redux-thunk';

// export const SelectProductAction = createAction<SelectProductPayload, Product>(
//     'SELECT_PRODUCT',
//     product => ({selectedProduct: product})
// );

export const GetProductsAction = createAction('GET_PRODUCTS', async () => {
    await sleep(1000);
    let products: Array<Product> = [
        {id: 1, name: 'Name2', desc: 'Desc2', price: 2},
        {id: 2, name: 'Name3', desc: 'Desc3', price: 3},
        {id: 3, name: 'Name4', desc: 'Desc4', price: 4}
    ];
    return products;
});

export const GetProductAction = createAction('GET_PRODUCT', async (id: number) => {
    await sleep(5000);
    let products: Array<Product> = [
        {id: 1, name: 'Name2', desc: 'Desc2', price: 2},
        {id: 2, name: 'Name3', desc: 'Desc3', price: 3},
        {id: 3, name: 'Name4', desc: 'Desc4', price: 4}
    ];
    let product = products.find(p => p.id === id);
    return products;
});


// export const GetProductsAction: ActionCreator<ThunkAction<Promise<Action>, ProductsState, void>> = () => {
//     return async (dispatch: Dispatch<ProductsState>): Promise<Action> => {
//         await sleep(1000);
//         let products: Array<Product> = [
//             {name: 'Name2', desc: 'Desc2', price: 2},
//             {name: 'Name3', desc: 'Desc3', price: 3},
//             {name: 'Name4', desc: 'Desc4', price: 4}
//         ];
//         return dispatch(GetProductsSuccessAction({products}));
//     };
// };

// export const GetProductsSuccessAction = createAction<ProductsPayload, ProductsPayload>(
//     'GET_PRODUCT_SUCCESS',
//     payload => payload
// );

function sleep(ms: number) {
    return new Promise((resolve) => setTimeout(resolve, ms));
}


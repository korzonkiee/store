// import { GetProductsAction } from '../ActionCreators/ProductActionCreators';
// import { Dispatch } from 'redux';
// import { Product } from '../Models/Product';
// import { ApplicationState, ProductsState } from '../Store/Store';
// import { connect } from 'react-redux';
// import { ProductsListCompontent, ProductsProps } from '../Components/ProductsList';

// export interface ProductsStateProps {
//     products: Product[];
// }

// export interface ProductsDispatchProps {
//     getProducts: () => void;
// }

// function mapStateToProps(state: ApplicationState): ProductsStateProps {
//     return {
//         products: state.products
//     };
// }

// function mapDispatchToProps(dispatch: Dispatch<any>): ProductsDispatchProps {
//     return {
//         getProducts: () => {
//             dispatch(GetProductsAction());
//         }
//     };
// }

// const ConnectedProduct = connect(
//     mapStateToProps,
//     mapDispatchToProps
// )(ProductsListCompontent);

// export default ConnectedProduct;
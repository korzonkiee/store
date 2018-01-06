import { Dispatch } from 'redux';
import { ApplicationState } from '../Store/Store';
import { Product } from '../Models/Product';
import { RouteComponentProps } from 'react-router';
import { GetProductsAction } from '../ActionCreators/ProductActionCreators';
import { connect } from 'react-redux';
import { ProductsComponent } from '../Components/Products';

export interface ProductsDispatchProps {
    getProducts: () => void;
}

export interface ProductsStateProps {
    products: Product[];
}

interface ProductProps extends RouteComponentProps<{}> {}

function mapStateToProps(state: ApplicationState, props: ProductProps): ProductsStateProps {
    return {
        products: state.products
    };
}

function mapDispatchToProps(dispatch: Dispatch<any>, props: ProductProps): ProductsDispatchProps {
    return {
        getProducts: () => {
            dispatch(GetProductsAction());
        }
    };
}

const ConnectedProduct = connect(
    mapStateToProps,
    mapDispatchToProps
)(ProductsComponent);

export default ConnectedProduct;
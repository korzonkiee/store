import { Product } from '../Models/Product';
import { connect } from 'react-redux';
import { Dispatch } from 'redux';
import { ApplicationState } from '../Store/Store';
import ProductDetailsComponent from '../Components/ProductDetails';
import { GetProductAction, GetProductsAction } from '../ActionCreators/ProductActionCreators';
import { RouteComponentProps, withRouter } from 'react-router';

export interface ProductDetailsStateProps {
    product: Product;
}

export interface ProductDetailsDispatchProps {
    getProduct: () => void;
}

interface ProductProps extends RouteComponentProps<{ productId: number}> {}

function mapStateToProps(state: ApplicationState, props: ProductProps): ProductDetailsStateProps {
    let productId = Number(props.match.params.productId);
    let product = state.products.find(p => p.id === productId);
    return {
        product: product
    };
}

function mapDispatchToProps(dispatch: Dispatch<any>, props: ProductProps): ProductDetailsDispatchProps {
    return {
        getProduct: () => {
            dispatch(GetProductAction(props.match.params.productId));
        }
    };
}

const ConnectedProduct = connect(
    mapStateToProps,
    mapDispatchToProps
)(ProductDetailsComponent);

export default ConnectedProduct;
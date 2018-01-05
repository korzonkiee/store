import { connect } from 'react-redux';
import { Dispatch } from 'redux';
import { ApplicationState } from '../Store/Store';
import { ProductComponent, ProductProps as ProductProps } from '../Components/Product';
import * as ProductActions from '../ActionCreators/ProductActionCreators';
import { SelectProductAction, GetProductsAction } from '../ActionCreators/ProductActionCreators';

type DispatchProps = Pick<ProductProps, 'updateSelectedProduct'>;

function mapDispatchToProps(dispatch: Dispatch<any>): DispatchProps {
    return {
        updateSelectedProduct: (productName: string) => {
            dispatch(GetProductsAction());
        }
    };
}

const ConnectedProduct = connect(
    null,
    mapDispatchToProps
)(ProductComponent);

export default ConnectedProduct;
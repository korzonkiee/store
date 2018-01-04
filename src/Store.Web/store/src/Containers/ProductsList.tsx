import { ApplicationState } from '../Store/Store';
import { connect } from 'react-redux';
import { ProductsListCompontent, Props } from '../Components/ProductsList';

function mapStateToProps(state: ApplicationState): Props {
    return {
        products: state.products
    };
}

const ConnectedProduct = connect(
    mapStateToProps
)(ProductsListCompontent);

export default ConnectedProduct;
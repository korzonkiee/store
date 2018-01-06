import ProductDetails from '../Containers/ProductDetails';
import { ProductsStateProps, ProductsDispatchProps} from '../Containers/Products';
import * as React from 'react';
import { Switch, Route } from 'react-router-dom';
import { ProductsList } from './ProductsList';

type ProductsProps = ProductsStateProps & ProductsDispatchProps;

export class ProductsComponent extends React.Component<ProductsProps, {}> {
    componentDidMount() {
        this.props.getProducts();
    }

    public render() {
        return (
        <Switch>
            <Route exact path='/products' render={ props =>
                <ProductsList
                    products={this.props.products}
                    onProductSelected={(productId: number) => props.history.push(`/products/${productId}`)}
                /> }
            />
            <Route path='/products/:productId' render={ props =>
                <ProductDetails {...props } /> }
            />
        </Switch>
        );
    }
}
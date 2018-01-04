import { Product } from '../Models/Product';
import ProductContainer from '../Containers/Product';
import * as React from 'react';

export interface Props {
    products: Array<Product>;
}

export class ProductsListCompontent extends React.Component<Props, {}> {
    public render() {
        let products = this.props.products;
        let productsList = products.map((product) => <li>
            <ProductContainer name={product.name} desc={product.desc} price={product.price} />
        </li>);
        return (
            <ul>
                {productsList}
            </ul>
        );
    }
}
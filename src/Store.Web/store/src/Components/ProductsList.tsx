import { ProductsDispatchProps, ProductsStateProps } from '../Containers/ProductsList';
import { ProductsState } from '../Store/Store';
import { Product } from '../Models/Product';
import ProductContainer from '../Containers/Product';
import * as React from 'react';
import { Card, GridList, GridTile } from 'material-ui';

export type ProductsProps = ProductsStateProps & ProductsDispatchProps;

export class ProductsListCompontent extends React.Component<ProductsProps, {}> {
    constructor(props: ProductsProps) {
        super(props);
    }

    componentDidMount() {
        this.props.getProducts();
    }

    public render() {
        let products = this.props.products;
        let productsList = products.map((product) => <ProductContainer name={product.name} desc={product.desc} price={product.price} />);
        return (
            <GridList cols={2} style={{marginLeft: '30rem', marginRight: '30rem'}}>
                {productsList}
            </GridList>
        );
    }
}
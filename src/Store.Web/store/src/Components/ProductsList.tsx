// import { ProductsDispatchProps, ProductsStateProps } from '../Containers/ProductsList';
import CardTitle from 'material-ui/Card/CardTitle';
import CardText from 'material-ui/Card/CardText';
import ProductDetails from './ProductDetails';
import { ProductsState } from '../Store/Store';
import { Product } from '../Models/Product';
import * as React from 'react';
import { Card, GridList, GridTile } from 'material-ui';

interface ProductsListProps {
    products: Product[];

    onProductSelected: (productId: number) => void;
}

export class ProductsList extends React.Component<ProductsListProps, {}> {
    constructor(props: ProductsListProps) {
        super(props);
    }

    private handleProductClick(productId: number) {
        this.props.onProductSelected(productId);
    }

    public render() {
        let products = this.props.products;
        let productsList = products.map((product) =>
            <div onClick={() => this.handleProductClick(product.id)}>
                <Card>
                    <CardTitle title={product.name} />
                    <CardText><p>{product.desc}</p></CardText>
                </Card>
            </div>
        );
        return (
            <GridList padding={10} cellHeight={'auto'} cols={2} style={{marginLeft: '30rem', marginRight: '30rem'}}>
                {productsList}
            </GridList>
        );
    }
}
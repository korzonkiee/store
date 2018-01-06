import { ProductDetailsDispatchProps, ProductDetailsStateProps } from '../Containers/ProductDetails';
import * as React from 'react';
import { Card, CardTitle, CardText} from 'material-ui';
import { RouteComponentProps, withRouter } from 'react-router';

type ProductDetailsProps = ProductDetailsStateProps & ProductDetailsDispatchProps;

export default class ProductDetails extends React.Component<ProductDetailsProps, any> {
    constructor(props: ProductDetailsProps, context?: any) {
        super(props, context);
    }

    componentDidMount() {
        this.props.getProduct();
    }

    public render() {
        let product = this.props.product;
        if (product === undefined) {
            return null;
        }
        return (
            <Card expandable={true}>
                <CardTitle title={product.name} />
                <CardText>
                    <div>
                        <p>{product.desc}</p>
                    </div>
                </CardText>
            </Card>
        );
    }
}
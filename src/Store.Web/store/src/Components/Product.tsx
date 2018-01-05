import * as React from 'react';
import { Card, CardTitle, CardText} from 'material-ui';

export interface ProductProps {
    name: string;
    desc: string;
    price: number;
    updateSelectedProduct: (productName: string) => void;
}

export class ProductComponent extends React.Component<ProductProps, {}> {

    constructor(props: ProductProps, context?: any) {
        super(props, context);
        this.selectProductAction = this.selectProductAction.bind(this);
    }

    public selectProductAction() {
        this.props.updateSelectedProduct(this.props.name);
    }

    public render() {
        return (
            <Card expandable={true}>
                <CardTitle title={this.props.name} />
                <CardText>
                    <div onClick={this.selectProductAction}>
                        <p>{this.props.desc}</p>
                    </div>
                </CardText>
            </Card>
        );
    }
}
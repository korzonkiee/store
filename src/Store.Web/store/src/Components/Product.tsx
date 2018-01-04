import * as React from 'react';

export interface Props {
    name: string;
    desc: string;
    price: number;
    updateSelectedProduct: (productName: string) => void;
}

export class ProductComponent extends React.Component<Props, {}> {

    constructor(props: Props, context?: any) {
        super(props, context);
        this.selectProductAction = this.selectProductAction.bind(this);
    }

    public selectProductAction() {
        this.props.updateSelectedProduct(this.props.name);
    }

    public render() {
        return (
            <div onClick={this.selectProductAction}>
                <p>Name: {this.props.name}</p>
                <p>Description: {this.props.desc}</p>
                <p>Price: {this.props.price}</p>
            </div>
        );
    }
}
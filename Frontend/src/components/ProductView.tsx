import React, { Component } from 'react'
import Product from '../objects/Product';

interface ProductProps {
    product: Product
    onAdd: Function
}

export class ProductView extends Component<ProductProps, { imgSrc: string }> {

    constructor(props: any) {
        super(props);

        this.state = {
            imgSrc: this.props.product.image
        }
    }

    render() {
        return (
            <div className='product'>
                <img
                    src={this.state.imgSrc === null ? "" : this.state.imgSrc}
                    alt='☹'
                    onError={() => this.setState({ imgSrc: require("../img/defaultImage.jpeg") as string})} />
                <h2>{this.props.product.name}</h2>
                <p>{this.props.product.description}</p>
                <h4>Категория "{this.props.product.category.name}"</h4>
                <b>{this.props.product.price} ₽</b>
                <div className='add-to-cart' onClick={() => this.props.onAdd(this.props.product)}>+</div>
            </div>
        );
    }
}

export default ProductView
import React, { Component } from 'react'
import { FaTrash } from 'react-icons/fa6'
import Product from '../objects/Product';

interface OrderProps {
    order: Product
    onDelete: Function
}

export class Order extends Component<OrderProps, { imgSrc: string }> {

    constructor(props: any) {
        super(props);

        this.state = {
            imgSrc: this.props.order.image
        }
    }

    render() {
        return (
            <div className='product'>
                <img src={this.state.imgSrc === null ? "" : this.state.imgSrc} alt='☹' onError={() => this.setState({ imgSrc: require("../img/defaultImage.jpeg") })} />
                <h2>{this.props.order.name}</h2>
                <b>{this.props.order.price} ₽</b>
                <FaTrash className='delete-icon' onClick={() => this.props.onDelete(this.props.order.id)} />
            </div>
        );
    }
}

export default Order
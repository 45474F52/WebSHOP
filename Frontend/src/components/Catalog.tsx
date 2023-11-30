import React, { Component } from 'react'
import ProductView from './ProductView';
import Product from '../objects/Product';

interface CatalogProps {
    products: Product[]
    onAdd: Function
}

export class Catalog extends Component<CatalogProps> {
    render() {
        return (
            <main>
                {this.props.products.map(i => (
                    <ProductView key={i.id} product={i} onAdd={this.props.onAdd} />
                ))}
            </main>
        );
    }
}

export default Catalog
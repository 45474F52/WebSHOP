import React, { Component } from 'react'
import ProductCategory from '../objects/ProductCategory'

interface CategoriesProps {
    categories: ProductCategory[]
    chooseCategory: Function
}

export class Categories extends Component<CategoriesProps, { categoryViews: ProductCategory[] }> {

    constructor(props: any) {
        super(props)

        this.state = {
            categoryViews: []
        }
    }

    static getDerivedStateFromProps(props: CategoriesProps, state: { categoryViews: ProductCategory[] }) {
        let val: ProductCategory[] = [new ProductCategory(0, "Всё", [])];

        props.categories.forEach(i => {
            val.push(i);
        });

        state.categoryViews = val;

        return state;
    }

    render() {
        return (
            <div className='categories'>
                {this.state.categoryViews.map(i => (
                    <div key={i.id} onClick={() => this.props.chooseCategory(i.id)}>
                        {i.name}
                    </div>
                ))}
            </div>
        );
    }
}

export default Categories
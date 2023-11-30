import React, { Component } from 'react'
import { FaCartShopping } from "react-icons/fa6";
import Order from './Order';
import ShowOrder from './ShowOrder';
import Product from '../objects/Product';

interface HeaderProps {
    orders: Product[]
    onDeleteFromOrder: Function
}

interface HeaderState {
    orderClicked: boolean
    cartOpened: boolean
}

export class Header extends Component<HeaderProps, HeaderState> {
    constructor(props: any) {
        super(props);

        this.state = {
            orderClicked: false,
            cartOpened: false
        }

        this.inverseOrderClicked = this.inverseOrderClicked.bind(this)
    }

    render() {
        return (
            <header>
                <div>
                    <span className='logo'>Beauty Clothes</span>
                    <ul className='nav'>
                        <li>Про нас</li>
                        <li>Контакты</li>
                        <li>Кабинет</li>
                    </ul>

                    <FaCartShopping onClick={() => this.setState({ cartOpened: !this.state.cartOpened })} className={`shop-cart-button ${this.state.cartOpened && 'active'}`} />

                    {this.state.cartOpened && (
                        <div className='shop-cart'>
                            {this.props.orders.length > 0 ?
                                this.showOrders() : this.showNothing()}
                        </div>
                    )}

                    {this.state.orderClicked && (
                        <ShowOrder orders={this.props.orders} onClose={this.inverseOrderClicked} />
                    )}
                </div>
                <div className='presentation'></div>
            </header>
        );
    }

    inverseOrderClicked() {
        this.setState({ orderClicked: !this.state.orderClicked })
    }

    showNothing = () => {
        return (
            <div className='empty'>
                <h2>Добавьте товары в корзину!</h2>
            </div>
        );
    }

    showOrders = () => {
        let summa = 0.0
        this.props.orders.forEach(i => summa += i.price)

        return (
            <div>
                {this.props.orders.map(i => (
                    <Order key={i.id} order={i} onDelete={this.props.onDeleteFromOrder} />
                ))}
                <p className='summa'>Сумма: {new Intl.NumberFormat().format(summa)} ₽</p>
                <div className='order-btn-container'>
                    <div className='order-btn' onClick={() => this.setState({ orderClicked: !this.state.orderClicked })} >Сделать заказ</div>
                </div>
            </div>
        );
    }
}

export default Header
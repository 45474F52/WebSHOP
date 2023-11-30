import React, { Component } from 'react'
import { FaRotateLeft } from 'react-icons/fa6';
import RequestToOrderDTO from '../DTO/RequestToOrderDTO';
import Product from '../objects/Product';

interface ShowOrderProps {
    orders: Product[]
    onClose: Function
}

interface ShowOrderState {
    summa: number
    phone: string
    email: string
    message: string
}

export class ShowOrder extends Component<ShowOrderProps, ShowOrderState> {

    constructor(props: any) {
        super(props);

        let summa: number = 0.0
        this.props.orders.forEach(i => summa += i.price)

        this.state = {
            summa: summa,
            phone: "",
            email: "",
            message: ""
        }
    }

    render() {
        return (
            <div className='shownOrder'>
                <div className='shownOrder-container'>
                    <FaRotateLeft className='close-order' onClick={() => this.props.onClose()} />
                    <div>
                        <p className='summa'>Сумма: {new Intl.NumberFormat().format(this.state.summa)} ₽</p>
                        {this.props.orders.map(i => (
                            <div key={i.id} className='order-product'>
                                <h2>{i.name}</h2>
                                <b>{i.price} ₽</b>
                            </div>
                        ))}
                        <div className='client-data'>
                            <form action=''>
                                <div className='inner-data'>
                                    <p>Оставьте свои контакты. Мы свяжемся с Вами для уточнения заказа.</p>
                                    <input placeholder='Номер телефона' type='phone' onChange={(event) => this.setState({ phone: event.target.value })} />
                                    <input placeholder='Эл. почта' type='email' onChange={(event) => this.setState({ email: event.target.value })} />
                                    <textarea placeholder="Сообщение..." rows={3} onChange={(event) => this.setState({ message: event.target.value })}></textarea>
                                    <input type='button' value={"Готово"} onClick={() => {

                                        let data: RequestToOrderDTO = new RequestToOrderDTO(
                                            this.state.phone,
                                            this.state.email,
                                            this.state.summa,
                                            this.props.orders,
                                            this.state.message
                                        );

                                        let url: string = process.env.REACT_APP_API_URL + "messages";

                                        fetch(url, {
                                            method: 'POST',
                                            mode: 'cors',
                                            body: JSON.stringify(data),
                                            headers: {
                                                'Content-Type': 'application/json; charset=utf-8'
                                            }
                                        });

                                        this.props.onClose();
                                    }} />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default ShowOrder
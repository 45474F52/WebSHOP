import ProductInOrderDTO from "./ProductInOrderDTO";


export class RequestToOrderDTO {

    public readonly datetime: string;
    public readonly products: ProductInOrderDTO[];

    constructor(
        public readonly phone: string,
        public readonly email: string,
        public readonly summa: number,
        public readonly productsOriginal: any[],
        public readonly message: string) {

        this.products = [];
        productsOriginal.forEach(i => {
            let dto: ProductInOrderDTO = new ProductInOrderDTO(i.id, i.name, i.manufacturer, i.price, i.category);
            this.products.push(dto);
        });

        let now: Date = new Date();
        this.datetime = now.toLocaleDateString('ru-RU') + " " + now.toLocaleTimeString('ru-RU');
    }
}

export default RequestToOrderDTO
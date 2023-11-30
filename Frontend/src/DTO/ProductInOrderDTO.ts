export class ProductInOrderDTO {

    constructor(
        public readonly id: number,
        public readonly name: string,
        public readonly manufacturer: string,
        public readonly price: number, 
        public readonly category: any)
    { }
}

export default ProductInOrderDTO
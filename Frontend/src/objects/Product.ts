import { ProductCategory } from "./ProductCategory";

export class Product {
    constructor(
        public readonly id: number,
        public readonly name: string,
        public readonly description: string,
        public readonly manufacturer: string,
        public readonly image: string,
        public readonly price: number,
        public readonly category: ProductCategory
    )
    {}
}

export default Product
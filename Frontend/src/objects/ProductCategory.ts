import Product from "./Product";

export class ProductCategory {
    constructor(
        public readonly id: number,
        public readonly name: string,
        public readonly products: Product[]
    )
    {}
}

export default ProductCategory
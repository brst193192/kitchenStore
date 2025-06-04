import { Product } from "./product";

export interface ProdForOrder {
    id: number,
    amount: number,
    orderId: number,
    productId: number,
    product: Product
}
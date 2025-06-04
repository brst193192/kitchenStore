import { Product } from "./product";

export interface ProdForCart{
    id?:number,
    amount?:number,
    productId?:number,
    product?:Product,
    userId?:number,
    isSelect?:boolean,
}
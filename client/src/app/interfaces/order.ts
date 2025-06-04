import { ProdForOrder } from "./prodForOrder";
import { Product } from "./product";

export interface Order{
    id?:number,
    orderDate?:Date,
    receiveDate?:Date,
    userId?:number,
    sum?:number,
    products?:ProdForOrder[],
}
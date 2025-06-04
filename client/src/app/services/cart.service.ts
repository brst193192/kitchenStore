import { inject, Injectable, numberAttribute } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ProdForCart } from '../interfaces/ProdForCart';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  cart_prod: ProdForCart[] = [
    // {
    //   id: 1,
    //   amount: 1,
    //   product: {
    //     id: 1,
    //     name: "aaa",
    //     desc: "bbb",
    //     model: "ccc",
    //     price: 100,
    //     img: "ddd",
    //     amountInStock: 1,
    //     categoryId:2,
    //     categoryName:"סירים"
    //   }
    // },
    // {
    //   id: 2,
    //   amount: 10,
    //   product: {
    //     id: 5,
    //     name: "fff",
    //     desc: "ttt",
    //     model: "yyy",
    //     price: 150,
    //     img: "uuu",
    //     amountInStock: 80,
    //     categoryId:1,
    //     categoryName:"מיקסרים"
    //   }
    // },
    // {
    //   id: 2,
    //   amount: 10,
    //   product: {
    //     id: 5,
    //     name: "fff",
    //     desc: "ttt",
    //     model: "yyy",
    //     price: 150,
    //     img: "uuu",
    //     amountInStock: 80,
    //     categoryId:4,
    //     categoryName:"תנורים",
    //   }
    // }
  ];
  sum=0;

  http: HttpClient = inject(HttpClient)
  url = "https://localhost:7186/prodForCart/";

  getMyCart(userId:number): Observable<ProdForCart[]> {
    return this.http.get<ProdForCart[]>(this.url+"byUser/"+userId);
  }

  addToCart(p:ProdForCart): Observable<ProdForCart> {
    return this.http.post<ProdForCart>(this.url+"add", p);
  }

  addManyToCart(p:ProdForCart[]): Observable<ProdForCart[]> {
    return this.http.post<ProdForCart[]>(this.url+"addMany", p);
  }

  updateAmountInCart(p:ProdForCart): Observable<boolean>{
    return this.http.put<boolean>(this.url+"UpdateAmount/", p);
  }

  deleteFromCart(id:number): Observable<ProdForCart>{
    return this.http.delete<ProdForCart>(this.url+"delete/"+id);
  }

  changeSeleted(pfc:ProdForCart): Observable<void>{
    return this.http.post<void>(this.url+"changeSelected", pfc);
  }
}


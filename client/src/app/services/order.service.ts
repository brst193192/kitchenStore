import { inject, Injectable } from '@angular/core';
import { Order } from '../interfaces/order';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  orders: Order[] = [
    {
      id: 35,
      products: [
        {
          amount: 1,
          id: 26,
          orderId: 35,
          product:
            { id: 17, name: 'תנור בילד אין', model: 'Electrolox - 7040k', desc: 'גודל סטנדרט', price: 2999 },
          productId: 17
        },
        {
          amount: 1,
          id: 27,
          orderId: 35,
          product: { id: 16, name: 'סט 3 כפות הגשה', desc: 'פוקס הום מתכת', price: 89.9 },
          productId: 16
        }, {
          amount: 1,
          id: 28,
          orderId: 35,
          product: { id: 12, name: 'מיקסר', model: 'MR-300', desc: 'בוש 1000 וואט', price: 1690 },
          productId: 12
        },
        {
          amount: 3,
          id: 29,
          orderId: 35,
          product: { id: 4, name: 'סיר סולתם', model: '', desc: 'יציקה 8 ליטר', price: 200 },
          productId: 4
        }
      ],
      sum: 5378.9,
      userId: 1,
    }
  ];

  http: HttpClient = inject(HttpClient)
  url = "https://localhost:7186/order/";

  getMyOrders(userId: number): Observable<Order[]> {
    return this.http.get<Order[]>(this.url + "byUser/" + userId);
  }

  addOrder(order: Order): Observable<void> {
    return this.http.post<void>(this.url + "add", order);
  }

  apdateArrived(order: Order): Observable<Order> {
    return this.http.put<Order>(this.url + "apdateArrived/", order);
  }
}

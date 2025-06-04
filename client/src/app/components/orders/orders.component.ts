import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { User } from '../../interfaces/user';
import { OrderService } from '../../services/order.service';
import { Order } from '../../interfaces/order';
import { Router } from '@angular/router';
import { NumPipe } from '../../../pipes/num.pipe';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, NumPipe],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.less'
})
export class OrdersComponent {
  r: Router = inject(Router);

  #userS: UserService = inject(UserService);
  currentUser: User = this.#userS.currentUser.value;

  #orderS: OrderService = inject(OrderService);
  orders: Order[] = this.#orderS.orders;

  //שליפת ההזמנות של המשתמש מהשרת
  //רק אם יש משתמש מחובר
  ngOnInit() {
    if (this.currentUser.id != null) {
      this.#orderS.getMyOrders(this.currentUser.id).subscribe(
        data => {
          this.#orderS.orders = [...data];
          this.orders = this.#orderS.orders;
        },
        err => { console.log(err); }
      );
    }
  }

  //ניתוב לפרטי המוצר שמוצג בהזמנה
  goToProduct(id: number) {
    const path = "details/" + id;
    this.r.navigate([path]);
  }

  //עדכון סטטוס הזמנה - שנמסרה
  //בשרת בסרויס ובמחלקה
  updateRecived(order: Order) {
    this.#orderS.apdateArrived(order).subscribe(
      data => {
        if (data != null) {
          const index = this.#orderS.orders.findIndex(o => o.id == order.id);
          this.#orderS.orders[index] = { ...data };
          this.orders = this.#orderS.orders;
        }
      },
      err => console.log(err)
    )
  }

  //מעבר לדף התחברות
  navigate(){
    this.r.navigate(['login']);
  }
}

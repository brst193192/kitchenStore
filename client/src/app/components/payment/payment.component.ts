import { Component, inject } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { ProdForCart } from '../../interfaces/ProdForCart';
import { CartService } from '../../services/cart.service';
import { UserService } from '../../services/user.service';
import { OrderService } from '../../services/order.service';
import { Order } from '../../interfaces/order';
import { ProdForOrder } from '../../interfaces/prodForOrder';
import { NumPipe } from '../../../pipes/num.pipe';
import { Router } from '@angular/router';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [CommonModule, NumPipe],
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.less'
})
export class PaymentComponent {
  location: Location = inject(Location);
  cartS: CartService = inject(CartService);
  userS: UserService = inject(UserService);
  orderS: OrderService = inject(OrderService);
  prodS: ProductsService = inject(ProductsService);
  r: Router = inject(Router);
  isBirthMonth = false;
  address: string = "";
  products: ProdForCart[] = this.cartS.cart_prod.filter(p => p.isSelect == true);
  sum = this.cartS.sum;

  //טעינת המוצרים לתשלום - רק המוצרים הבחורים בעגלה
  //שליפת כתובת משתמש 
  ngOnInit() {
    this.products = this.cartS.cart_prod.filter(p => p.isSelect == true);
    this.sum = this.cartS.sum;
    this.userS.currentUser.subscribe(u => {
      const m = new Date(u.birthday!).getMonth();
      this.isBirthMonth = m == new Date().getMonth();
    });
    const address = this.userS.currentUser.value.address;
    this.address = address?.street + " " + address!.buildNumber + "/" + address?.houseNumber + " " + address?.city;
  }

  //חזרה לעגלה - תפריט קודם
  back() {
    this.location.back();
  }

  //הזמנה
  //ההזמנה מתווספת לשרת 
  order() {
    const o=this.buildOrderObj();
    //הוספה לשרת
    this.orderS.addOrder(o).subscribe(
      data => {
        alert('ההזמנה בוצעה בהצלחה');
        this.products.forEach(p => {
          this.updateCart(p.id!);
        });
      },
      err => console.log(err)
    );
  }

  //בנית אובייקט הזמנה מכל המוצרים שנבחרו
  buildOrderObj() {
    const products_for_order: ProdForOrder[] = [];
    this.products.forEach(prod => {
      products_for_order.push({ product: prod.product, productId: prod.productId, amount: prod.amount } as ProdForOrder);
    });
    const o: Order = {
      products: products_for_order,
      userId: this.userS.currentUser.value.id,
      sum: this.sum,
    };
    return o;
  }

  //מחיקת המוצרים שהוזמנו מהעגלה בשרת ובסרויס
  updateCart(id:number) {
    this.cartS.deleteFromCart(id).subscribe(
      data => {
        //יש לעדכן כמות בסרויס
        this.getAllProducts();
      },
      err => {
        console.log(err)
      }
    );
  }

  //שליפת כל המוצרים מהשרת
  getAllProducts() {
    this.prodS.getAllProducts().subscribe(
      data => {
        this.prodS.products = [...data];
        this.prodS.filteredList = [...data];
        this.r.navigate(['products']);
      },
      err => {
        console.log(err);
      }
    )
  }
}
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdForCart } from '../../interfaces/ProdForCart';
import { CartService } from '../../services/cart.service';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { User } from '../../interfaces/user';
import { NumPipe } from '../../../pipes/num.pipe';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, NumPipe],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.less'
})
export class CartComponent {
  
  #cartS: CartService = inject(CartService);
  cart_list: ProdForCart[] = this.#cartS.cart_prod;
  #userS: UserService = inject(UserService);
  user: User = {};
  #router: Router = inject(Router);
  sum = this.#cartS.sum;

  //אם יש משתמש מחובר - נשלוף את העגלה שלו מהשרת
  ngOnInit() {
    if (this.#userS.currentUser.value.id != null) {
      this.user = this.#userS.currentUser.value;
      this.#cartS.getMyCart(this.#userS.currentUser.value.id).subscribe(
        data => {
          this.#cartS.cart_prod = [...data];
          this.cart_list = this.#cartS.cart_prod;
          this.calcSum();
        },
        err => {
          console.log(err);
        }
      )
    }
  }

  //אם המשתמש רוצה לשנות את הכמות בעגלה
  //נעדכן בשרת את הכמות החדשה ואח"כ בשרת
  //אם הכמות היא 0 - נמחק
  //אם הכמות גדולה מהכמות במלאי - לא יתאפר ותוצג הודעה למשתמש
  changeAmount(index: number, num: number) {
    const p: ProdForCart = this.#cartS.cart_prod[index];
    p.amount = p.amount! + num;
    //נבדוק שהכמות לא גדולה מהכמות שבמלאי
    if (p.amount > p.product?.amountInStock!) {
      p.amount = p.product?.amountInStock!;
      alert(`ניתן להזמין עד כמות של ${p.amount} יחידות!`)
    }
    //רק אם יש משתמש מחובר
    if (this.#userS.currentUser.value.id != null) {
      //נעדכן בשרת
      p.userId == this.#userS.currentUser.value.id;
      this.#cartS.updateAmountInCart(p).subscribe(
        data => { this.#cartS.cart_prod[index] = p; },
        err => { console.log(err); }
      );
      //אם הכמות היא 0 - נמחק בסרויס
      if (p.amount !== 0) {
        this.#cartS.cart_prod.slice(index, 1);
      }
      //נעדכן את המצביע של המערך המקומי לסרויס
      this.cart_list = this.#cartS.cart_prod;
      this.calcSum();
    }
  }

  //שינוי סטטוס מוצר בעגלה - בחור או לא
  //רק מוצרים שנבחרו יוצגו בטופס ההזמנה
  changeSeleted(index: number) {
    this.#cartS.changeSeleted(this.cart_list[index]).subscribe(
      data => {
        this.cart_list[index].isSelect = !this.cart_list[index].isSelect;
        this.calcSum();
      },
      err => {
        console.log(err);
      }
    )
  }

  //חישוב סכום לחשלום של המוצרים שנבחרו בלבד 
  //החישוב כולל מחיר*כמות
  calcSum() {
    //עדכון הסכום לתשלום
    let newSum = 0;
    for (let i = 0; i < this.cart_list.length; i++) {
      if (this.cart_list[i].isSelect == true)
        newSum += this.cart_list[i].amount! * this.cart_list[i].product?.price!;
    };
    this.#cartS.sum = newSum;
    this.sum = this.#cartS.sum;
  }

  //בדיקת תקינות בכניסה כדי למנוע חריגה במקרה שהמלאי השתנה
  checkCart() {
    let p;
    for (let i = 0; i < this.cart_list.length; i++) {
      p = this.cart_list[i];
      if (p.isSelect == true && p.amount! > p.product?.amountInStock!)
        return false;
    }
    return true;
  }

  //מעבר לדף ההזמנה
  //רק אם העגלה תקינה
  order() {
    if (!this.checkCart())
      alert("כמות בעגלה לא תואמת לכמות במלאי!")
    else
      this.#router.navigate(['payment']);
  }

  //מעבר לדף התחברות
  navigate(){
    this.#router.navigate(['login']);
  }
}

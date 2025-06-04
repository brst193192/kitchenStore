import { Component, inject } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { Product } from '../../interfaces/product';
import { ProductsService } from '../../services/products.service';
import { ActivatedRoute } from '@angular/router';
import { CartService } from '../../services/cart.service';
import { UserService } from '../../services/user.service';
import { ProdForCart } from '../../interfaces/ProdForCart';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.less'
})
export class DetailsComponent {
  location: Location = inject(Location);
  prodS: ProductsService = inject(ProductsService);
  #cartS: CartService = inject(CartService);
  #userS: UserService = inject(UserService);
  #ar: ActivatedRoute = inject(ActivatedRoute);
  currentProd: Product = {};

  //טעינת כל המוצרים מהשרת לסרויס
  //רק במקרה שהסרויס ריק
  ngOnInit() {
    if (this.prodS.products.length == 0) {
      // subscribe - הרשמה לקבלת תשובה מהצופה 
      this.prodS.getAllProducts().subscribe(
        data => {
          // הנתונים מהשרת לתוך המערכים של הסרויס
          this.prodS.products = [...data];
          this.prodS.filteredList = [...data];
          //שליפת הקוד של המוצר הנוכחי
          this.#ar.params.subscribe(p => {
            this.currentProd = this.prodS.getProductById(p['id'] as number);
            console.log(this.currentProd);
          });
        },
        err => {
          console.log(err);
        }
      )
    }
    else {
      //שליפת הקוד של המוצר הנוכחי
      this.#ar.params.subscribe(p => {
        this.currentProd = this.prodS.getProductById(p['id'] as number);
        console.log(this.currentProd);
      });
    }
  }

  //חזרה לדף קודם
  back() {
    this.location.back();
  }

  //הוספת מוצר לעגלה בשרת ובסרויס
  //רק אם יש משתמש מחובר
  addToCart(id: number) {
    const p: ProdForCart = { productId: this.currentProd.id, amount: 1, isSelect: true };
    if (this.#userS.currentUser.value.id != null) {
      p.userId = this.#userS.currentUser.value.id;
      this.#cartS.addToCart(p).subscribe(
        data => {
          this.#cartS.cart_prod.push({ ...data });
          alert("המוצר נוסף בהצלחה לעגלה");
        },
        err => {
          console.log(err);
        }
      );
    }
    else {
      alert("יש להתחבר כדי להוסיף מוצר לעגלה");
    }
  }
}
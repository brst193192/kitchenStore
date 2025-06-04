import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Event, Router } from '@angular/router';
import { ProductsService } from '../../services/products.service';
import { Product } from '../../interfaces/product';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../interfaces/category';
import { ProdForCart } from '../../interfaces/ProdForCart';
import { UserService } from '../../services/user.service';
import { CartService } from '../../services/cart.service';
import { FontDirective } from '../../../directivs/font.directive';
import { ButtonDesighnDirective } from '../../../directivs/button-desighn.directive';
import { CssSelector } from '@angular/compiler';
import { __values } from 'tslib';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FontDirective, ButtonDesighnDirective],
  templateUrl: './products.Component.html',
  styleUrl: './products.component.less'
})
export class ProductsComponent {
  router: Router = inject(Router);
  prodS: ProductsService = inject(ProductsService);
  userS: UserService = inject(UserService);
  cartS: CartService = inject(CartService);
  userId = this.userS.currentUser.value.id;
  categoryS: CategoryService = inject(CategoryService);
  productsList: Product[] = this.prodS.products;
  categories: Category[] = this.categoryS.categories;

  //טעינת כל המוצרים והקטגוריות לסרויס
  ngOnInit() {
    if (this.prodS.products.length == 0) {
      // subscribe - הרשמה לקבלת תשובה מהצופה 
      this.prodS.getAllProducts().subscribe(
        data => {
          // הנתונים מהשרת לתוך המערכים של הסרויס
          this.prodS.products = [...data];
          this.prodS.filteredList = [...data];
          this.productsList = this.prodS.products;
        },
        err => {
          console.log(err);
        }
      )
    }
    //טעינת כל הקטגוריות לסרויס
    if (this.categoryS.categories.length == 0) {
      this.categoryS.getAll().subscribe(
        data => {
          this.categoryS.categories = [...data];
          this.categories = this.categoryS.categories;
        },
        err => {
          console.log(err);
        }
      )
    }
  }

  //מעבר לדף פרטי מוצר
  showDetails(id: number) {
    const path = "details/" + id;
    this.router.navigate([path]);
  }

  //עדכון במערך המסונן מותרים לפי הקטוגוריה שנבחרה 
  //רק מוצרים אלו יוצגו
  showByCategory(id: number) {
    this.prodS.filterByCategoryId(id).subscribe(
      data => {
        this.prodS.filteredList = [...data];
        this.productsList = this.prodS.filteredList;
      },
      err => {
        console.log(err);
      }
    )
  }

  //הצגת כל המוצרים - ללא סינון
  showAll() {
    if (this.prodS.products!.length == 0) {
      this.prodS.getAllProducts().subscribe(
        data => {
          this.prodS.products = [...data];
          this.productsList = this.prodS.products;
        },
        err => {
          console.log(err);
        }
      )
    }
    else {
      this.productsList = this.prodS.products!;
    }
  }

  //הוספת מוצר לעגלה
  //עדכון בשרת ובסרויס
  addToCart(id: number) {
    const p: ProdForCart = { productId: id, amount: 1, isSelect: true };
    p.userId = this.userId;
    this.cartS.addToCart(p).subscribe(
      data => {
        this.cartS.cart_prod.push({ ...data });
        alert("המוצר נוסף בהצלחה לעגלה");
      },
      err => {
        console.log(err);
      }
    );
  }

  //מיון המוצרים לפי מחיר עולה
  sort(type: string) {
    debugger
    // switch (type) {
    //   case 'hot':
    //     alert("hot")
    //     break
    //   case 'price-up':
    //     alert("price-up")
    this.productsList.sort((a, b) => a.price! - b.price!);
    //     break
    //   case 'price-down':
    //     alert("price-down")
    //     break
    //   case 'amountInStock':
    //     alert("amountInStock")
    //     break
    // }
  }

}

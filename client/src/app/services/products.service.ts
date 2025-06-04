import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Product } from '../interfaces/product';

@Injectable({
  providedIn: 'root'
})

export class ProductsService {

  products: Product[] = [];
  filteredList: Product[] = []

  //קריאות שרת
  http: HttpClient = inject(HttpClient)
  url = "https://localhost:7186/Product/";

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url+"all");
  }

  getProductById(id: number) {
    const index = this.products.findIndex(p => p.id == id)
    if (index != -1)
      return this.products[index];
    return {};
  }

  filterByCategoryId(catId:number) :Observable<Product[]> {
    return this.http.get<Product[]>(this.url+"byCategory"+catId);
  }
}

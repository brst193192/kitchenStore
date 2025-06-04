import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../interfaces/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  categories: Category[] = [];

  //קריאות שרת
  http: HttpClient = inject(HttpClient)
  url = "https://localhost:7186/category/";

  getAll(): Observable<Category[]> {
    const cat=this.http.get<Category[]>(this.url+"all")
    return cat; 
  }

  getById(id:number): Observable<string[]> {
    return this.http.get<string[]>(this.url+"byId/"+1);
  }
}

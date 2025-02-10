import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryIndex } from '../models/category-index.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = 'https://localhost:5001/Categories';
  constructor(private http: HttpClient) { }

  getCategories() : Observable<CategoryIndex[]>{
    return this.http.get<CategoryIndex[]>(`${this.apiUrl}`);
  }
}

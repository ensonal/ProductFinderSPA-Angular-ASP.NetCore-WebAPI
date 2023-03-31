import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  //web service call 
  private url = "category";
  constructor(private _http: HttpClient) { }

  // get Category
  public getCategory() : Observable<Category[]> {
    return this._http.get<Category[]>(`${environment.apiUrl}/${this.url}`);
  }

  // add Category
  public addCategory(data: Category) : Observable<any> {
    return this._http.post(`${environment.apiUrl}/${this.url}`, data);
    
  }
  
  // delete Category
  public deleteCategory(id: number): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/${this.url}/${id}`);
  }

  // update Category
  public updateCategory(id: number, data: any) : Observable<any> {
    return this._http.put(`${environment.apiUrl}/${this.url}/${id}`, data);
    
  }




}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  //web service call 
  private url = "product";
  constructor(private _http: HttpClient) { }

  // get product
  public getProducts() : Observable<Product[]> {
    return this._http.get<Product[]>(`${environment.apiUrl}/${this.url}`);
  }

  // add product
  public addProducts(data: Product) : Observable<any> {
    return this._http.post(`${environment.apiUrl}/${this.url}`, data);
    
  }
  
  // delete product
  public deleteProducts(id: number): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/${this.url}/${id}`);
  }

  // update product
  public updateProducts(id: number, data: any) : Observable<any> {
    return this._http.put(`${environment.apiUrl}/${this.url}/${id}`, data);
  
  }




}

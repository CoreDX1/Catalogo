import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../model/product';
import { ApiResponse } from '../model/ApiResponse/Response';

@Injectable({
  providedIn: 'root',
})
export class CatalogoService {
  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: {
      'Content-Type': 'application/json',
    },
  };

  public getCatalogo() {
    const url = 'http://localhost:5271/api/product';

    const products = this.http.get<ApiResponse<Product[]>>(
      `${url}/getproducts`,
      this.httpOptions
    );

    return products;
  }
}

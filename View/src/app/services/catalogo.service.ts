import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../model/product';
import { ApiResponse } from '../model/ApiResponse/Response';
import { FilterProductRequest } from '../model/Request/FilterProductRequest';
import { Observable } from 'rxjs';

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
        const products = this.http.get<ApiResponse<Product[]>>(`${url}/getproducts`, this.httpOptions);
        return products;
    }

    public postProductFilter(filter: FilterProductRequest): Observable<ApiResponse<Product[]>> {
        const url = 'http://localhost:5271/api/product';
        var products = this.http.post<ApiResponse<Product[]>>(`${url}/getfilterproduct`, filter, this.httpOptions);
        return products;
    }
}

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
    private readonly url = 'http://localhost:5271/api/product';

    constructor(private http: HttpClient) {}

    httpOptions = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    public getCatalogo() {
        const products = this.http.get<ApiResponse<Product[]>>(`${this.url}/getproducts`, this.httpOptions);
        return products;
    }

    public postProductFilter(filter: FilterProductRequest): Observable<ApiResponse<Product[]>> {
        const url = 'http://localhost:5271/api/product';
        var products = this.http.post<ApiResponse<Product[]>>(`${url}/getfilterproduct`, filter, this.httpOptions);
        return products;
    }

    public getSearchProducts(searchValue: string): Observable<ApiResponse<Product[]>> {
        return this.http.get<ApiResponse<Product[]>>(`${this.url}/searchproducts?title_like=${searchValue}`);
    }

    public getFindProductForName(name: string): Observable<ApiResponse<Product>> {
        return this.http.get<ApiResponse<Product>>(`${this.url}/findproductforname/${name}`);
    }
}

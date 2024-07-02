import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { FilterProductRequest } from '../../model/Request/FilterProductRequest';
import { ProductComponent } from '../product/product.component';
import { ApiResponse } from '../../model/ApiResponse/Response';
import { Product } from '../../model/product';
import { CatalogoService } from '../../services/catalogo.service';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import ProductDetailsComponent from '../product-details/product-details.component';

@Component({
    selector: 'app-product-filter',
    standalone: true,
    imports: [ProductComponent, FormsModule, ReactiveFormsModule, RouterModule, ProductDetailsComponent],
    templateUrl: './product-filter.component.html',
})
export default class ProductFilterComponent implements OnInit {
    public formFilter: FilterProductRequest = {
        name: '',
        category: 0,
        priceMin: 1,
        priceMax: 0,
        stock: 0,
        description: '',
        stars: 0,
        page: 0,
        pageSize: 0,
        order: 0,
    };

    public products: ApiResponse<Array<Product>> = {} as ApiResponse<Array<Product>>;

    constructor(private catalogoService: CatalogoService) {}

    public ngOnInit() {
        this.loadCatalog();
    }

    public loadCatalog = () => {
        this.catalogoService.getCatalogo().subscribe({
            next: (data) => {
                this.products = data;
            },
        });
    };

    public PostProductFilter = () => {
        this.catalogoService.postProductFilter(this.formFilter).subscribe({
            next: (data) => {
                this.products = data;
            },
        });
    };

    public FormatName(name: string): string {
        var nameFormat = name.split(' ').join('-');
        return nameFormat;
    }
}

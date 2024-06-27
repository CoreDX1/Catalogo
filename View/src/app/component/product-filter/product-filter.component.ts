import { Component } from '@angular/core';
import { FilterProductRequest } from '../../model/Request/FilterProductRequest';
import { ProductComponent } from '../product/product.component';
import { ApiResponse } from '../../model/ApiResponse/Response';
import { Product } from '../../model/product';
import { CatalogoService } from '../../services/catalogo.service';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-product-filter',
    standalone: true,
    imports: [ProductComponent, FormsModule],
    templateUrl: './product-filter.component.html',
})
export class ProductFilterComponent {
    public formFilter: FilterProductRequest = {
        name: '',
        category: 0,
        priceMin: 0,
        priceMax: 0,
        stock: 0,
        description: '',
        stars: 0,
        page: 0,
        pageSize: 0,
        order: 0,
    };

    public filterProducts(filter: FilterProductRequest) {
        this.formFilter = filter;
    }
    public products: ApiResponse<Product[]> = {
        data: [],
        metadata: {
            statusCode: 0,
            message: '',
        },
    };

    private readonly catalogoService: CatalogoService;

    constructor(catalogoService: CatalogoService) {
        this.catalogoService = catalogoService;
    }

    public ngOnInit() {
        this.fethchCatalogo();
    }

    public fethchCatalogo = async () => {
        this.catalogoService.getCatalogo().subscribe({
            next: (data) => {
                this.products = data;
            },
        });
    };

    public PostProductFilter = async () => {
        this.catalogoService.postProductFilter(this.formFilter).subscribe({
            next: (data) => {
                this.products = data;
            },
        });
    };
}

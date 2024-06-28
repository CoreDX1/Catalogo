import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { FilterProductRequest } from '../../model/Request/FilterProductRequest';
import { ProductComponent } from '../product/product.component';
import { ApiResponse } from '../../model/ApiResponse/Response';
import { Product } from '../../model/product';
import { CatalogoService } from '../../services/catalogo.service';
import { FormsModule } from '@angular/forms';
import { debounceTime, switchMap } from 'rxjs';

@Component({
    selector: 'app-product-filter',
    standalone: true,
    imports: [ProductComponent, FormsModule, ReactiveFormsModule],
    templateUrl: './product-filter.component.html',
})
export class ProductFilterComponent implements OnInit {
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

    public searchValue: string = '';

    public products: ApiResponse<Array<Product>> = {} as ApiResponse<Array<Product>>;

    public findProducts: ApiResponse<Array<Product>> = {} as ApiResponse<Array<Product>>;

    public searchForm = this.fb.nonNullable.group({
        searchValue: [''],
    });

    constructor(
        private catalogoService: CatalogoService,
        private fb: FormBuilder
    ) {}

    public ngOnInit() {
        this.fethchCatalogo();
        this.liveSearch();
    }

    public ngOnDestroy() {
        this.liveSearch();
    }

    public fethchCatalogo = () => {
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

    public getSearchProducts = () => {
        this.catalogoService.getSearchProducts(this.searchValue).subscribe({
            next: (data) => {
                this.findProducts = data;
            },
        });
    };

    public onSearchSubmit() {
        this.searchValue = this.searchForm.value.searchValue ?? '';
        this.getSearchProducts();
    }

    public liveSearch() {
        this.searchForm.valueChanges
            .pipe(
                debounceTime(300), // Espera 300ms después de que el usuario deja de escribir
                switchMap((value) => {
                    return value.searchValue
                        ? this.catalogoService.getSearchProducts(value.searchValue)
                        : this.catalogoService.getCatalogo();
                })
            )
            .subscribe({
                next: (data) => {
                    this.findProducts = data;
                },
            });
    }
}

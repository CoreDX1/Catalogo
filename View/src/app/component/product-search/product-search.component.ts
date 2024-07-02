import { Component, OnInit } from '@angular/core';
import { ApiResponse } from '../../model/ApiResponse/Response';
import { Product } from '../../model/product';
import { CatalogoService } from '../../services/catalogo.service';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, switchMap } from 'rxjs';
import { Router, RouterModule } from '@angular/router';
import { ProductUtils } from '../../shared/product-utils';

@Component({
    selector: 'app-product-search',
    standalone: true,
    imports: [FormsModule, ReactiveFormsModule, RouterModule],
    templateUrl: './product-search.component.html',
})
export class ProductSearchComponent implements OnInit {
    public searchValue: string = '';
    public findProducts: ApiResponse<Array<Product>> = {} as ApiResponse<Array<Product>>;
    public utils = new ProductUtils();

    public searchForm = this.fb.nonNullable.group({
        searchValue: [''],
    });

    constructor(
        private catalogoService: CatalogoService,
        private fb: FormBuilder,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.setupLiveSearch();
    }

    public onSearchSubmit() {
        this.searchValue = this.searchForm.value.searchValue ?? '';
        this.searchProductByName();
    }
    public searchProductByName = () => {
        this.catalogoService.searchProductByName(this.searchValue).subscribe({
            next: (data) => {
                this.findProducts = data;
            },
        });
    };

    public navigateToProductDetails(name: string) {
        const formattedName = this.utils.FormatName(name);
        this.router.navigate(['/product-details', formattedName]);
    }

    public setupLiveSearch() {
        this.searchForm.valueChanges
            .pipe(
                debounceTime(300), // Espera 300ms después de que el usuario deja de escribir
                switchMap((value) => {
                    return value.searchValue
                        ? this.catalogoService.searchProductByName(value.searchValue)
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

import { Component, OnInit } from '@angular/core';
import { ApiResponse } from '../../model/ApiResponse/Response';
import { Product } from '../../model/product';
import { CatalogoService } from '../../services/catalogo.service';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, switchMap } from 'rxjs';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-product-search',
    standalone: true,
    imports: [FormsModule, ReactiveFormsModule, RouterModule],
    templateUrl: './product-search.component.html',
})
export class ProductSearchComponent implements OnInit {
    public searchValue: string = '';
    public findProducts: ApiResponse<Array<Product>> = {} as ApiResponse<Array<Product>>;

    public searchForm = this.fb.nonNullable.group({
        searchValue: [''],
    });

    constructor(
        private catalogoService: CatalogoService,
        private fb: FormBuilder
    ) {}
    ngOnInit(): void {
        this.liveSearch();
    }

    public onSearchSubmit() {
        this.searchValue = this.searchForm.value.searchValue ?? '';
        this.getSearchProducts();
    }
    public getSearchProducts = () => {
        this.catalogoService.getSearchProducts(this.searchValue).subscribe({
            next: (data) => {
                this.findProducts = data;
            },
        });
    };

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

    public FormatName(name: string): string {
        var nameFormat = name.split(' ').join('-');
        return nameFormat;
    }
}

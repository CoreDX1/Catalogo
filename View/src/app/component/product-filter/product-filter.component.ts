import { Component } from '@angular/core'
import { NgModel } from '@angular/forms'
import { FilterProductRequest } from '../../model/Request/FilterProductRequest'

@Component({
    selector: 'app-product-filter',
    standalone: true,
    imports: [],
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
    }
}

import { Component, Input } from '@angular/core';
import { Product } from '../../model/product';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ProductUtils } from '../../shared/product-utils';

@Component({
    selector: 'app-product-cart',
    standalone: true,
    imports: [FormsModule, RouterModule],
    templateUrl: './product-cart.component.html',
})
export class ProductCartComponent {
    @Input() product: Product = {} as Product;

    public utils = new ProductUtils();

    constructor(private router: Router) {}

    public FormatPrice(price: number): string {
        var priceFormat = new Intl.NumberFormat('es-AR').format(price);
        var priceArgen = '$' + priceFormat;
        return priceArgen;
    }

    public navigateToProductDetails(name: string) {
        const formattedName = this.utils.FormatName(name);
        this.router.navigate(['/product-details', formattedName]);
    }
}

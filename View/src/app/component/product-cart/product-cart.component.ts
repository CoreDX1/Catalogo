import { Component, Input } from '@angular/core';
import { Product } from '../../model/product';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-product-cart',
    standalone: true,
    imports: [FormsModule, RouterModule],
    templateUrl: './product-cart.component.html',
})
export class ProductCartComponent {
    @Input() product: Product = {} as Product;

    public FormatPrice(price: number): string {
        var priceFormat = new Intl.NumberFormat('es-AR').format(price);
        var priceArgen = '$' + priceFormat;
        return priceArgen;
    }

    public CountStars(stars: number): number[] {
        return new Array(stars);
    }

    public FormatName(name: string): string {
        var nameFormat = name.split(' ').join('-');
        return nameFormat;
    }
}

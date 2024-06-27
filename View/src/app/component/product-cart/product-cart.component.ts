import { Component, Input, OnInit, input } from '@angular/core';
import { Product } from '../../model/product';

@Component({
  selector: 'app-product-cart',
  standalone: true,
  imports: [],
  templateUrl: './product-cart.component.html',
})
export class ProductCartComponent {
  @Input() product: Product = {} as Product;

  public FormatPrice(price: number) {
    var priceFormat = new Intl.NumberFormat('es-AR').format(price);
    var priceArgen = '$' + priceFormat;
    return priceArgen;
  }

  public CountStars(stars: number) {
    return new Array(stars);
  }
}

import { Component, Input } from '@angular/core';
import { ApiResponse } from '../../model/ApiResponse/Response';
import { Product } from '../../model/product';
import { CatalogoService } from '../../services/catalogo.service';
import { ProductCartComponent } from '../product-cart/product-cart.component';

@Component({
    selector: 'app-product',
    standalone: true,
    imports: [ProductCartComponent],
    templateUrl: './product.component.html',
})
export class ProductComponent {
    @Input() public products: ApiResponse<Product[]> = {
        data: [],
        metadata: {
            statusCode: 0,
            message: '',
        },
    };
}

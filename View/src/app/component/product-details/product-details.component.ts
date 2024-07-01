import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CatalogoService } from '../../services/catalogo.service';
import { Product } from '../../model/product';

@Component({
    selector: 'app-product-details',
    standalone: true,
    imports: [RouterModule],
    templateUrl: './product-details.component.html',
})
export default class ProductDetailsComponent implements OnInit {
    public productName: string = '';

    public product: Product = {} as Product;

    constructor(
        private route: ActivatedRoute,
        private productService: CatalogoService
    ) {}

    ngOnInit(): void {
        this.productName = this.route.snapshot.params['productName'];

        this.getProduct(this.productName);
    }

    public getProduct(productName: string) {
        this.productService.getFindProductForName(productName).subscribe({
            next: (data) => {
                this.product = data.data;
                console.log(this.product);
            },
        });
    }
}

import { Component } from '@angular/core';
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
}

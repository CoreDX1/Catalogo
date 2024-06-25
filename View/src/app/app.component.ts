import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiResponse } from './model/ApiResponse/Response';
import { Product } from './model/product';
import { CatalogoService } from './services/catalogo.service';
import { FooterComponent } from './component/footer/footer.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FooterComponent, NgClass],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
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

  ngOnInit() {
    this.fethchCatalogo();
  }

  public fethchCatalogo = async () => {
    this.catalogoService.getCatalogo().subscribe({
      next: (data) => {
        this.products = data;
      },
    });
  };

  public CountStars(stars: number) {
    return new Array(stars);
  }

  public FormatPrice(price: number) {
    var priceFormat = new Intl.NumberFormat('es-AR').format(price);
    var priceArgen = '$' + priceFormat;
    return priceArgen;
  }
}

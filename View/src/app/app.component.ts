import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductSearchComponent } from './component/product-search/product-search.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterModule, ProductSearchComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
})
export class AppComponent {}

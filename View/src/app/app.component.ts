import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductSearchComponent } from './component/product-search/product-search.component';
import { FooterComponent } from './component/footer/footer.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterModule, ProductSearchComponent, FooterComponent],
    templateUrl: './app.component.html',
})
export class AppComponent {}

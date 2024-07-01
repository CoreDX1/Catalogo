import { Routes, provideRouter } from '@angular/router';
import ProductFilterComponent from './component/product-filter/product-filter.component';
import ProductDetailsComponent from './component/product-details/product-details.component';

export const routes: Routes = [
    {
        path: 'filterProduct',
        component: ProductFilterComponent,
    },
    {
        path: 'product-details/:productName',
        component: ProductDetailsComponent,
    },
    {
        path: '',
        redirectTo: '/filterProduct',
        pathMatch: 'full',
    },
];

export const routing = provideRouter(routes);

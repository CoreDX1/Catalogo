import { Routes, provideRouter } from '@angular/router';

export const routes: Routes = [
    {
        path: 'filterProduct',
        loadComponent: () => import('./component/product-filter/product-filter.component'),
    },
    {
        path: 'product-details/:productName',
        loadComponent: () => import('./component/product-details/product-details.component'),
    },
    {
        path: '',
        redirectTo: '/filterProduct',
        pathMatch: 'full',
    },
];

export const routing = provideRouter(routes);

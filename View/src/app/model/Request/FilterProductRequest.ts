export interface FilterProductRequest {
    name: string
    category: number
    priceMin: number
    priceMax: number
    stock: number
    description: string
    stars: number
    page: number
    pageSize: number
    order: number
}

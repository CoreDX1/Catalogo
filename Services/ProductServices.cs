using Catalogo.Models.BaseResponse;
using Catalogo.Models.Entities;
using Catalogo.Models.Interfaces;

namespace Catalogo.Services;

public class ProductServices : IProductServices
{
    private readonly IProductRepository _productRepository;

    public ProductServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ApiResult<IEnumerable<Producto>>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        return ApiResult<IEnumerable<Producto>>.Success(products, "Success", 200);
    }
}

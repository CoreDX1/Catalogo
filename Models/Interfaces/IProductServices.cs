using Catalogo.Models.BaseResponse;
using Catalogo.Models.Dto.Request;
using Catalogo.Models.Dto.Response;
using Catalogo.Models.Entities;

namespace Catalogo.Models.Interfaces;

public interface IProductServices
{
	public Task<ApiResult<IEnumerable<ProductResponseDto>>> GetProducts();
	public Task<ApiResult<IEnumerable<ProductResponseDto>>> GetFilterProduct(FilterRequestDto filter);
	public Task<ApiResult<IEnumerable<ProductResponseDto>>> SearchProducts(string name);
	public Task<ApiResult<IEnumerable<ProductResponseDto>>> GetProductsByCategory(int categoryId);
}

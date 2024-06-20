using Catalogo.Models.BaseResponse;
using Catalogo.Models.Entities;

namespace Catalogo.Models.Interfaces;

public interface IProductServices
{
    public Task<ApiResult<IEnumerable<Producto>>> GetProducts();
}

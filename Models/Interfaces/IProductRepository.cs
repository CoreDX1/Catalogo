using Catalogo.Models.Dto.Request;
using Catalogo.Models.Entities;

namespace Catalogo.Models.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Producto>> GetProducts();
    Task<IEnumerable<Producto>> GetProductsByCategory(int category);
    public Task<IEnumerable<Producto>> GetFilterProduct(FilterRequestDto filter);
}

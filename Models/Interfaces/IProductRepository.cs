using Catalogo.Models.Entities;

namespace Catalogo.Models.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Producto>> GetProducts();
    Task<IEnumerable<Producto>> GetProductsByCategory(int category);
}

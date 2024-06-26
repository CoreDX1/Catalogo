using Catalogo.Models.Dto.Request;
using Catalogo.Models.Entities;

namespace Catalogo.Models.Interfaces;

public interface IProductRepository
{
	Task<IEnumerable<Producto>> GetProducts();
	Task<IEnumerable<Producto>> GetProductsByCategory(int category);
	Task<IEnumerable<Producto>> GetFilterProduct(FilterRequestDto filter);

	Task<IEnumerable<Producto>> GetProductsName(string name);
}

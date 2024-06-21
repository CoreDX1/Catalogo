using Catalogo.Models.BaseResponse;
using Catalogo.Models.Dto.Request;
using Catalogo.Models.Dto.Response;
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

	public async Task<ApiResult<IEnumerable<ProductResponseDto>>> GetProducts()
	{
		var products = await _productRepository.GetProducts();

		var productsDto = GetProductResponseDto(products);

		return ApiResult<IEnumerable<ProductResponseDto>>.Success(productsDto, "Success", 200);
	}

	public async Task<ApiResult<IEnumerable<ProductResponseDto>>> GetFilterProduct(FilterRequestDto filter)
	{
		var products = await _productRepository.GetFilterProduct(filter);

		var productsDto = GetProductResponseDto(products);

		return ApiResult<IEnumerable<ProductResponseDto>>.Success(productsDto, "Success", 200);
	}

	private IEnumerable<ProductResponseDto> GetProductResponseDto(IEnumerable<Producto> p)
	{
		var productsDto = p.Select(p => new ProductResponseDto
		{
			Id = p.ProductoId,
			Name = p.Nombre,
			Description = p.Descripcion,
			Stars = p.Stars,
			Price = p.Precio,
			Image = p.Imagen.Imagen,
			Category = p.Categoria.Nombre
		});
		return productsDto;
	}
}

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

	public async Task<ApiResult<IEnumerable<ProductResponseDto>>> SearchProducts(string name)
	{
		var products = await _productRepository.GetProductsName(name);

		if (!products.Any())
		{
			return ApiResult<IEnumerable<ProductResponseDto>>.Error("Product not found", 404);
		}

		var productsDto = GetProductResponseDto(products);

		return ApiResult<IEnumerable<ProductResponseDto>>.Success(productsDto, "Success", 200);
	}

	public async Task<ApiResult<IEnumerable<ProductResponseDto>>> GetProductsByCategory(int categoryId)
	{
		var products = await _productRepository.GetProductsByCategory(categoryId);
		if (!products.Any())
		{
			return ApiResult<IEnumerable<ProductResponseDto>>.Error("Product not found", 404);
		}

		var productsDto = GetProductResponseDto(products);

		return ApiResult<IEnumerable<ProductResponseDto>>.Success(productsDto, "Success", 200);
	}

	public async Task<ApiResult<ProductResponseDto>> GetFindProductForName(string name)
	{
		var product = await _productRepository.FindProductForName(name);

		if (product == null)
		{
			return ApiResult<ProductResponseDto>.Error("Product not found", 404);
		}

		var productDto = new ProductResponseDto
		{
			Id = product.ProductoId,
			Name = product.Nombre,
			Description = product.Descripcion,
			Stars = product.Stars,
			Price = product.Precio,
			Image = product.Imagen?.Imagen,
			Category = product.Categoria?.Nombre
		};

		return ApiResult<ProductResponseDto>.Success(productDto, "Success", 200);
	}

	private static IEnumerable<ProductResponseDto> GetProductResponseDto(IEnumerable<Producto> p)
	{
		var productsDto = p.Select(p => new ProductResponseDto
		{
			Id = p.ProductoId,
			Name = p.Nombre,
			Description = p.Descripcion,
			Stars = p.Stars,
			Price = p.Precio,
			Image = p.Imagen?.Imagen,
			Category = p.Categoria?.Nombre
		});

		return productsDto;
	}
}

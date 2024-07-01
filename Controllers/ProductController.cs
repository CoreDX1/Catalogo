using Catalogo.Models.Dto.Request;
using Catalogo.Models.Entities;
using Catalogo.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
	private readonly IProductServices _productServices;

	public ProductController(IProductServices productServices)
	{
		_productServices = productServices;
	}

	[HttpGet]
	[Route("GetProducts")]
	[ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetProducts()
	{
		var products = await _productServices.GetProducts();
		return Ok(products);
	}

	[HttpPost]
	[Route("GetFilterProduct")]
	[ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetFilterProduct(FilterRequestDto filter)
	{
		var products = await _productServices.GetFilterProduct(filter);
		return Ok(products);
	}

	[HttpGet]
	[Route("SearchProducts")]
	[ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
	public async Task<IActionResult> SearchProducts([FromQuery] string title_like)
	{
		var products = await _productServices.SearchProducts(title_like);
		return Ok(products);
	}

	[HttpGet]
	[Route("GetProductsByCategory/{categoryId}")]
	[ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
	{
		var products = await _productServices.GetProductsByCategory(categoryId);
		return Ok(products);
	}

	[HttpGet]
	[Route("findProductForName/{name}")]
	[ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
	public async Task<IActionResult> FundProductForName([FromRoute] string name)
	{
		Console.WriteLine(name);
		var formmatedName = name.Replace("-", " ");
		var products = await _productServices.GetFindProductForName(formmatedName);
		return Ok(products);
	}
}

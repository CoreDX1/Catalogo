using Catalogo.Data;
using Catalogo.Models.Dto.Request;
using Catalogo.Models.Entities;
using Catalogo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repository;

public class ProductRepository : IProductRepository
{
	private readonly AlmacenDbContext _context;

	public ProductRepository(AlmacenDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Producto>> GetProducts()
	{
		// IQueryable<Producto> products = _context.Productos.Include(p => p.Categoria);

		var query =
			from p in _context.Productos
			select new Producto
			{
				Nombre = p.Nombre,
				Descripcion = p.Descripcion,
				Stars = p.Stars,
				Precio = p.Precio,
				Imagen = p.Imagen,
				Categoria = p.Categoria
			};

		return await query.AsNoTracking().ToListAsync();
	}

	private IQueryable<Producto> GetProductsQuery()
	{
		var query =
			from p in _context.Productos
			select new Producto
			{
				ProductoId = p.ProductoId,
				Nombre = p.Nombre,
				Descripcion = p.Descripcion,
				Stars = p.Stars,
				Precio = p.Precio,
				Imagen = p.Imagen,
				Categoria = p.Categoria
			};
		return query;
	}

	public async Task<IEnumerable<Producto>> GetProductsByCategory(int category)
	{
		var products = await _context.Productos.AsNoTracking().Where(p => p.CategoriaId == category).ToListAsync();

		return products;
	}

	public async Task<IEnumerable<Producto>> GetFilterProduct(FilterRequestDto filter)
	{
		// Uso Queryable para mejorar el rendimiento de la consulta, por que se ejecuta en la base de datos
		IQueryable<Producto> query = GetProductsQuery();

		switch (filter.Order)
		{
			case OrderBy.Asc:
				query = query.OrderBy(p => p.Precio);
				break;
			case OrderBy.Desc:
				query = query.OrderByDescending(p => p.Precio);
				break;
		}

		if (filter.Name != string.Empty && filter.Name != null)
		{
			query = query.Where(p => p.Nombre.Contains(filter.Name));
		}

		if (filter.Category != 0)
		{
			query = query.Where(p => p.CategoriaId == filter.Category);
		}

		if (filter.Stars != 0)
		{
			query = query.Where(p => p.Stars == filter.Stars);
		}

		if (filter.PriceMax > 0 && filter.PriceMin > 0)
		{
			query = query.Where(p => p.Precio >= filter.PriceMin && p.Precio <= filter.PriceMax);
		}

		return await query.ToListAsync();
	}

	public async Task<IEnumerable<Producto>> GetProductsName(string name)
	{
		var products = await _context
			.Productos.Where(p => p.Nombre.Contains(name))
			.Select(p => new Producto
			{
				ProductoId = p.ProductoId,
				Nombre = p.Nombre,
				Descripcion = p.Descripcion,
				Stars = p.Stars,
				Precio = p.Precio,
				Imagen = p.Imagen,
				Categoria = p.Categoria
			})
			.ToListAsync();

		return products;
	}

	public async Task<IEnumerable<Producto>> GetProductForCategory(int id)
	{
		var products = await _context
			.Productos.Where(p => p.CategoriaId == id)
			.Select(p => new Producto
			{
				ProductoId = p.ProductoId,
				Nombre = p.Nombre,
				Descripcion = p.Descripcion,
				Stars = p.Stars,
				Precio = p.Precio,
				Imagen = p.Imagen,
				Categoria = p.Categoria
			})
			.ToListAsync();

		return products;
	}

	public async Task<Producto> FindProductForName(string name)
	{
		var product = await _context
			.Productos.AsNoTracking()
			.Where(p => p.Nombre == name)
			.Select(p => new Producto
			{
				ProductoId = p.ProductoId,
				Nombre = p.Nombre,
				Descripcion = p.Descripcion,
				Stars = p.Stars,
				Precio = p.Precio,
				Imagen = p.Imagen,
				Categoria = p.Categoria
			})
			.FirstOrDefaultAsync();

		if (product == null)
		{
			return null!;
		}

		return product;
	}
}

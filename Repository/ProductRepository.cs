using Catalogo.Data;
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
        var product = await _context.Productos.AsNoTracking().ToListAsync();
        return product;
    }

    public async Task<IEnumerable<Producto>> GetProductsByCategory(int category)
    {
        var product = await _context
            .Productos.AsNoTracking()
            .Where(p => p.CategoriaId == category)
            .ToListAsync();

        return product;
    }
}

namespace Catalogo.Models.Dto.Response;

public class ProductResponseDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public int Stars { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }
}

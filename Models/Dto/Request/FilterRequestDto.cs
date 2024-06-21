namespace Catalogo.Models.Dto.Request;

public class FilterRequestDto
{
    public string? Name { get; set; } = string.Empty;

    public int Category { get; set; } = 0;

    public int PriceMin { get; set; } = 0;

    public int PriceMax { get; set; }

    public int Stock { get; set; }

    public string? Description { get; set; }

    public int Stars { get; set; } = 0;

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public OrderBy Order { get; set; } = OrderBy.Asc;
}

public enum OrderBy
{
    Asc,
    Desc
}

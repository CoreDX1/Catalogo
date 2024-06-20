using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    [HttpGet("demo")]
    public string Get()
    {
        return "Hola mundo";
    }
}

using FitBalanceBlazor.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Produkt>>> GetProducts()
    {
        return await _productService.GetProductsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produkt>> GetProduct(int id)
    {
        return await _productService.GetProductByIdAsync(id);
    }    
}
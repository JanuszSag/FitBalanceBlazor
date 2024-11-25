using FitBalanceBlazor.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Rodzaj>>> GetCategories()
    {
        return await _categoryService.GetCategoriesAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Rodzaj>> GetCategory(int id)
    {
        return await _categoryService.GetCategoryByIdAsync(id);
    }
    
}
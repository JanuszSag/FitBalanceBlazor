using Microsoft.EntityFrameworkCore;
using FitBalanceBlazor.Context;

namespace FitBalanceBlazor.Services.ProductService;

public class ProductService : IProductService
{
    private readonly MyDbContext _context;

    public ProductService(MyDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Method <c>GetProductsAsync</c> returns list of all products stored in database
    /// </summary>
    /// <returns>List of products</returns>
    public async Task<List<Produkt>> GetProductsAsync()
    {
        return await _context.Produkt.ToListAsync();
    }
    
    /// <summary>
    /// Method <c>GetProductByIdAsync</c> return product object stored in database based on id
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>Product object</returns>
    public async Task<Produkt?> GetProductByIdAsync(int id)
    {
        
        return await _context.Produkt.FindAsync(id);
    }

    /// <summary>
    /// Method <c>GetProductsForMeal</c> return list of products for given meal
    /// </summary>
    /// <param name="id">Id of meal</param>
    /// <returns>List of products</returns>
    public async Task<List<Produkt?>> GetProductsForMeal(int id)
    {
        var result = await _context.Produkt.Include(p => p.Produkt_Danie)
            .Where(p => p.Produkt_Danie.Select(d => d.id_danie).Contains(id))
            .Select(p => new Produkt
            {
                id_produkt = p.id_produkt,
                nazwa = p.nazwa,
                Produkt_Danie = p.Produkt_Danie,
                id_dieta = p.id_dieta,
            })
            .ToListAsync();

        return result;
    }
}
using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.DietService;

public class DietService: IDietService
{
    private readonly MyDbContext _context;

    public DietService(MyDbContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Method <c>GetAllDietsAsync</c> return list of all diets stored in database
    /// </summary>
    /// <returns>List of diets</returns>
    public async Task<List<Dieta>> GetAllDietsAsync()
    {
        var result = await _context.Dieta.Include(d => d.Danie_id_danie)
            .Select(d => new Dieta
            {
                id_dieta = d.id_dieta,
                nazwa = d.nazwa,
                opis = d.opis,
                kalorycznosc = d.kalorycznosc,
                autor = d.autor,
                rodzaj = d.rodzaj,
                Opinia = d.Opinia,
                Przypisana_dieta = d.Przypisana_dieta,
                Raport = d.Raport,
                autorNavigation = d.autorNavigation,
                rodzajNavigation = d.rodzajNavigation,
                Danie_id_danie = d.Danie_id_danie,
                id_produkt = d.id_produkt
            }).ToListAsync();

        return result;
    }

    /// <summary>
    /// Method <c>GetAllDietsByCategoryIdAsync</c> return list of all diets with specific category stored in database
    /// </summary>
    /// <param name="categoryId">Id of category</param>
    /// <returns>List of diets with specific category</returns>

    public async Task<List<Dieta>> GetAllDietsByIdAsync(List<int> dietId)
    {
        var result = await _context.Dieta.Include(d => d.Danie_id_danie)
                                              .Select(d => new Dieta
                                              {
                                                  id_dieta = d.id_dieta,
                                                  nazwa = d.nazwa,
                                                  opis = d.opis,
                                                  kalorycznosc = d.kalorycznosc,
                                                  rodzaj = d.rodzaj,
                                                  Danie_id_danie = d.Danie_id_danie
                                              }).Where(d => dietId.Contains(d.id_dieta))
                                              .ToListAsync();
        
        return result;
    }
    
    public async Task<List<Dieta>> GetAllDietsByCategoryIdAsync(int categoryId)
    {
        return await _context.Dieta.Where(d => d.rodzaj == categoryId).ToListAsync();
    }
    
    
    /// <summary>
    /// Method <c>GetDietAsync</c> return diet based on id given in parameter
    /// </summary>
    /// <param name="dietId">id of diet stored in database</param>
    /// <returns>diet object</returns>
    public async Task<Dieta?> GetDietAsync(int dietId)
    {
        var result = await _context.Dieta.Include(d => d.Danie_id_danie)
                                         .Where(dieta => dieta.id_dieta == dietId)
                                         .Select(d => new Dieta
                                         {
                                             id_dieta = d.id_dieta,
                                             nazwa = d.nazwa,
                                             opis = d.opis,
                                             kalorycznosc = d.kalorycznosc,
                                             Danie_id_danie = d.Danie_id_danie.Select(danie => new Danie
                                             {
                                                 id_danie = danie.id_danie,
                                                 nazwa = danie.nazwa
                                             }).ToList()
                                         }).FirstAsync();

        
        return result;
    }

    /// <summary>
    /// method <c>RemoveDietAsync</c> removes diet from database based on id parameter
    /// </summary>
    /// <param name="dietId">id of diet to remove</param>
    public async void RemoveDietAsync(int dietId)
    {
        try
        {
            var dieta = await _context.Dieta.FindAsync(dietId);
            
            _context.Dieta.Attach(await _context.Dieta.SingleAsync(d => d.id_dieta == dietId));
            _context.Dieta.Remove(await _context.Dieta.SingleAsync(d => d.id_dieta == dietId));
            
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Method <c>AddDietAsync</c> adds new entry of diet to database
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="nazwa">Name</param>
    /// <param name="opis">Description</param>
    /// <param name="kalorycznosc">Calorie</param>
    /// <param name="autor">Author</param>
    /// <param name="rodzaj">Category</param>
    public void AddDiet(DietaDTO dieta)
    {
        var max =  _context.Dieta.Select(d => d.id_dieta).Max();
        
        try{
             _context.Dieta.Add(new Dieta
             {
                
                id_dieta = max+1,
                nazwa = dieta.Nazwa,
                opis = dieta.Opis,
                kalorycznosc = dieta.Kalorycznosc,
                autor = dieta.Autor,
                rodzaj = dieta.Rodzaj
             });
            _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<bool> AddMealsToDiet(int id, List<Danie> meals)
    {
        try
        {
            var diet = await _context.Dieta
                .Include(d => d.Danie_id_danie)
                .FirstOrDefaultAsync(d => d.id_dieta == id);

            if (diet == null) return false;
            diet.Danie_id_danie.Clear();
            foreach (var meal in meals)
            {
                diet.Danie_id_danie.Add(meal);
            }

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}

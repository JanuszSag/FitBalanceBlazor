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
    public async Task<ServiceResponse<List<Dieta>>> GetAllDietsAsync()
    {
        var response = new ServiceResponse<List<Dieta>>();
        var diets = await _context.Dieta.Include(d => d.Danie_id_danie)
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
        if (diets is null)
        {
            response.Success = false;
            response.Message = "Cannot find any diets";
        }
        response.Data = diets;
        response.Success = true;
        return response;
    }

    /// <summary>
    /// Method <c>GetAllDietsByCategoryIdAsync</c> return list of all diets with specific category stored in database
    /// </summary>
    /// <param name="categoryId">Id of category</param>
    /// <returns>List of diets with specific category</returns>

    public async Task<ServiceResponse<List<Dieta>>> GetAllDietsByIdAsync(List<int> dietId)
    {
        var response = new ServiceResponse<List<Dieta>>();
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
        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Failed to get diets";
            return response;
        }
        response.Data = result;
        response.Success = true;
        return response;
        
    }
    
    public async Task<ServiceResponse<List<Dieta>>> GetAllDietsByCategoryIdAsync(int categoryId)
    {
        var response = new ServiceResponse<List<Dieta>>();
        var result = await _context.Dieta.Where(d => d.rodzaj == categoryId).ToListAsync();

        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Failed to get diets";
            return response;
        }
        response.Data = result;
        response.Success = true;
        return response;
    }
    
    
    /// <summary>
    /// Method <c>GetDietAsync</c> return diet based on id given in parameter
    /// </summary>
    /// <param name="dietId">id of diet stored in database</param>
    /// <returns>diet object</returns>
    public async Task<ServiceResponse<Dieta>> GetDietAsync(int dietId)
    {
        var response = new ServiceResponse<Dieta>();
        var result = await _context.Dieta
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

        if (result == null)
        {
            response.Success = false;
            response.Message = "Failed to get diet";
            return response;
        }
        response.Data = result;
        response.Success = true;
        return response;
    }

    /// <summary>
    /// method <c>RemoveDietAsync</c> removes diet from database based on id parameter
    /// </summary>
    /// <param name="dietId">id of diet to remove</param>
    public async Task<ServiceResponse<bool>> RemoveDietAsync(int dietId)
    {
        var response = new ServiceResponse<bool>();

            var dieta = await _context.Dieta.FindAsync(dietId);
            
            _context.Dieta.Remove(await _context.Dieta.FindAsync(dietId));
            
            await _context.SaveChangesAsync();
            
            response.Success = true;
            response.Message = "Diet has been removed";
            response.Data = true;
            return response;

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
    public ServiceResponse<bool> AddDiet(DietaDTO dieta)
    {
        var response = new ServiceResponse<bool>();
        var max =  _context.Dieta.Select(d => d.id_dieta).Max();
        if (max == 0)
        {
            response.Success = false;
            response.Message = "Cannot find diet";
            return response;
        }
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
            
            response.Success = true;
            response.Message = "Diet has been created";
            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
            return response;
        }
    }

    public async Task<ServiceResponse<bool>> AddMealsToDiet(int id, List<int> meals)
    {
        var response = new ServiceResponse<bool>();
        
            var diet = await _context.Dieta
                .Include(d => d.Danie_id_danie)
                .FirstOrDefaultAsync(d => d.id_dieta == id);

            if (diet == null)
            {
                response.Success = false;
                response.Message = "Diet not found";
                
                return response;
            }

            var bufor = diet.Danie_id_danie;
            bufor.Clear();
            foreach (var meal in meals)
            {
                bufor.Add(_context.Danie.Find(meal));
            }
            diet.Danie_id_danie = bufor;
            await _context.SaveChangesAsync();

            response.Data = true;
            response.Success = true;
            
            return response;

    }

    public async Task<ServiceResponse<bool>> UpdateMealsInUserDiet(int dietId, List<int> meals)
    {
        var response = new ServiceResponse<bool>();
        
        var diet = await _context.Przypisana_dieta
            .Include(d => d.id_danie)
            .ThenInclude(d => d.id_przypisana_dieta)
            .FirstOrDefaultAsync(d => d.id_przypisana_dieta == dietId);

        if (diet == null)
        {
            response.Success = false;
            response.Message = "Diet not found";
                
            return response;
        }

        var bufor = diet.id_danie;
        bufor.Clear();
        foreach (var meal in meals)
        {
            bufor.Add(_context.Danie.Find(meal));
        }
        diet.id_danie = bufor;
        await _context.SaveChangesAsync();

        response.Data = true;
        response.Success = true;
            
        return response;

    }
}

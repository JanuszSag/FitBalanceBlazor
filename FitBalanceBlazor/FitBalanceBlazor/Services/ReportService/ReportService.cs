using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace FitBalanceBlazor.Services.ReportService;

public class ReportService : IReportService
{
    private readonly MyDbContext _context;

    public ReportService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<Raport>>> GetDietRaportsAsync(int id)
    {
        var response = new ServiceResponse<List<Raport>>();
        
        var result = await _context.Raport.Select(r => new Raport
        {
            id_raport = r.id_raport,
            dieta = r.dieta,
            data = r.data,
            dietaNavigation = r.dietaNavigation,
            uzytkownik = r.uzytkownik,
            uzytkownikNavigation = r.uzytkownikNavigation
        }).Where(r => r.uzytkownik == id).ToListAsync();

        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Can't get diet raports";
            
            return response;
        }
        
        response.Success = true;
        response.Data = result;
        
        return response;
    }

    public async Task<ServiceResponse<List<Wypita_woda>>> GetWaterRaportsAsync(int id)
    {
        var response = new ServiceResponse<List<Wypita_woda>>();

        var result = await _context.Wypita_woda.Select(w => new Wypita_woda
        {
            id_wypita_woda = w.id_wypita_woda,
            data = w.data,
            ilosc = w.ilosc,
            id_uzytkownik = w.id_uzytkownik,
            id_uzytkownikNavigation = w.id_uzytkownikNavigation
        }).Where(w => w.id_uzytkownik == id).ToListAsync();

        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Can't get water raports";
            return response;
        }
        response.Success = true;
        response.Data = result;
        
        return response;
    }

    public async Task<ServiceResponse<List<Pomiar_wagi>>> GetWeightRaportsAsync(int id)
    {
        var response = new ServiceResponse<List<Pomiar_wagi>>();
        
        var result = await _context.Pomiar_wagi.Where(w => w.id_uzytkownik == id).ToListAsync();

        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Can't get weight raports";
            return response;
        }
        response.Success = true;
        response.Data = result;
        return response;
    }
}
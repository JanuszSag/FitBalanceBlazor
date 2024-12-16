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
    
    public async Task<List<Raport>> GetDietRaportsAsync(int id)
    {
        var result = await _context.Raport.Select(r => new Raport
        {
            id_raport = r.id_raport,
            dieta = r.dieta,
            data = r.data,
            dietaNavigation = r.dietaNavigation,
            uzytkownik = r.uzytkownik,
            uzytkownikNavigation = r.uzytkownikNavigation
        }).Where(r => r.id_raport == id).ToListAsync();
        
        return result;
    }

    public async Task<List<Wypita_woda>> GetWaterRaportsAsync(int id)
    {
        var result = await _context.Wypita_woda.Select(w => new Wypita_woda
        {
            id_wypita_woda = w.id_wypita_woda,
            data = w.data,
            ilosc = w.ilosc,
            id_uzytkownik = w.id_uzytkownik,
            id_uzytkownikNavigation = w.id_uzytkownikNavigation
        }).Where(w => w.id_wypita_woda == id).ToListAsync();
        
        return result;
    }

    public async Task<List<Pomiar_wagi>> GetWeightRaportsAsync(int id)
    {
        var result = await _context.Pomiar_wagi.Select(w => new Pomiar_wagi
        {
            id_pomiar = w.id_pomiar,
            data = w.data,
            waga = w.waga,
            id_uzytkownik = w.id_uzytkownik,
            id_uzytkownikNavigation = w.id_uzytkownikNavigation
        }).Where(w => w.id_pomiar == id).ToListAsync();

        return result;
    }
}
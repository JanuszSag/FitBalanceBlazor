using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.ProgramService;

public class ProgramService : IProgramService
{
    private readonly MyDbContext _context;

    public ProgramService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Programy>> GetProgramsAsync()
    {
        return await _context.Programy.ToListAsync();
    }

    public async Task<Programy> GetProgramByIdAsync(int id)
    {
        return await _context.Programy.FindAsync(id);
    }
}
using System.Data.Entity;
using FitBalanceBlazor.Context;
using FitBalanceBlazor.Models;

namespace FitBalanceBlazor.Services.ReviewService;

public class ReviewService : IReviewService
{
    private readonly MyDbContext _context;

    public ReviewService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Opinia>> getAllReviewsAsync()
    {
        return await _context.Opinia.ToListAsync();
    }

    public async Task<Opinia> getReviewByIdAsync(int id)
    {
        return await _context.Opinia.FindAsync(id);
    }
}
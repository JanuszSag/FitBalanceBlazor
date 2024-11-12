using FitBalanceBlazor.Models;

namespace FitBalanceBlazor.Services.ReviewService;

public interface IReviewService
{
    Task<List<Opinia>> getAllReviewsAsync();
    Task<Opinia> getReviewByIdAsync(int id);
}
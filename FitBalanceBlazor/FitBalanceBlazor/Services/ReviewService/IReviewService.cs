

namespace FitBalanceBlazor.Services.ReviewService;

public interface IReviewService
{
    Task<List<Opinia>> GetAllReviewsAsync();
    Task<Opinia> GetReviewByIdAsync(int id);
}
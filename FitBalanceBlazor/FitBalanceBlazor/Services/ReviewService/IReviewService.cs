

using ClassLibrary1;

namespace FitBalanceBlazor.Services.ReviewService;

public interface IReviewService
{
    Task<ServiceResponse<List<Opinia>>> GetAllReviewsAsync();
    Task<Opinia> GetReviewByIdAsync(int id);
    Task<ServiceResponse<bool>> AddReviewAsync(OpiniaDTO review);
}
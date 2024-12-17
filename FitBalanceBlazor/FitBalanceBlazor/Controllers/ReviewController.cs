using FitBalanceBlazor.Services.ReviewService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Opinia>>> GetReviews()
    {
        return await _reviewService.GetAllReviewsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Opinia>> GetReview(int id)
    {
        return await _reviewService.GetReviewByIdAsync(id);
    }
}
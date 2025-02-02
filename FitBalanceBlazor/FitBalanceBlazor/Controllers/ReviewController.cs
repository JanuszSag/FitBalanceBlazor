using ClassLibrary1;
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
    public async Task<ActionResult<ServiceResponse<List<Opinia>>>> GetReviews()
    {
        var response = await _reviewService.GetAllReviewsAsync();
        if(!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Opinia>> GetReview(int id)
    {
        return await _reviewService.GetReviewByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult> AddReviewAsync(Opinia review)
    {
        var response = await _reviewService.AddReviewAsync(review);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }
}
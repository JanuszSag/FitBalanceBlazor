using ClassLibrary1;
using FitBalanceBlazor.Services.QuestionAnswerService;
using Microsoft.AspNetCore.Mvc;

namespace FitBalanceBlazor.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class QuestionAnswerController : ControllerBase
{
    private readonly IQuestionAnswerService _questionAnswerService;

    public QuestionAnswerController(IQuestionAnswerService questionAnswerService)
    {
        _questionAnswerService = questionAnswerService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Pytania_i_odpowiedzi>>>> GetQuestionAnswer()
    {
        var response = await _questionAnswerService.GetAllQuestionAnswer();
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Pytania_i_odpowiedzi>> GetQuestionAnswer(int id)
    {
        return await _questionAnswerService.GetQuestionAnswerById(id);
    }
}
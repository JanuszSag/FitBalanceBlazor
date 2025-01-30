using System.Data.Entity;
using ClassLibrary1;
using FitBalanceBlazor.Context;

namespace FitBalanceBlazor.Services.QuestionAnswerService;

public class QuestionAnswerService : IQuestionAnswerService
{
    private readonly MyDbContext _context;

    public QuestionAnswerService(MyDbContext context)
    {
        this._context = context;
    }

    public async Task<ServiceResponse<List<Pytania_i_odpowiedzi>>> GetAllQuestionAnswer()
    {
        var response = new ServiceResponse<List<Pytania_i_odpowiedzi>>();
        var result = await _context.Pytania_i_odpowiedzi.ToListAsync();
        if (result.Count == 0)
        {
            response.Success = false;
            response.Message = "Cannot find any question and answers.";
            return response;
        }
        response.Data = result;
        response.Success = true;

        return response;
    }

    public async Task<Pytania_i_odpowiedzi> GetQuestionAnswerById(int id)
    {
        return await _context.Pytania_i_odpowiedzi.FindAsync(id);
    }
}
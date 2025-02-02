
using ClassLibrary1;

namespace FitBalanceBlazor.Services.QuestionAnswerService;

public interface IQuestionAnswerService
{
    Task<ServiceResponse<List<Pytania_i_odpowiedzi>>> GetAllQuestionAnswer();
    Task<Pytania_i_odpowiedzi> GetQuestionAnswerById(int id);
    Task<ServiceResponse<bool>> DeleteQuestionAnswerAsync(int id);
    Task<ServiceResponse<bool>> AddQuestionAnswerAsync(Pytania_i_odpowiedzi questionAnswer);
}
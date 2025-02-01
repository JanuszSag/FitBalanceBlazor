
using ClassLibrary1;

namespace FitBalanceBlazor.Services.QuestionAnswerService;

public interface IQuestionAnswerService
{
    Task<ServiceResponse<List<Pytania_i_odpowiedzi>>> GetAllQuestionAnswer();
    Task<Pytania_i_odpowiedzi> GetQuestionAnswerById(int id);
}
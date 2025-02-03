using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.QuestionAnswerService;

public class QuestionAnswerService : IQuestionAnswerService
{
    private readonly MyDbContext _context;

    public QuestionAnswerService(MyDbContext context)
    {
        this._context = context;
    }

    //metody do wyciągania danych z tabeli Pytania_i_odpowiedzi (wszytskich i po id)
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

    //metoda usuwania danych z tabeli Pytania_i_odpowiedzi
    public async Task<ServiceResponse<bool>> DeleteQuestionAnswerAsync(int id)
    {
        var response = new ServiceResponse<bool>();
        var pytaniaIodpowiedzi = await _context.Pytania_i_odpowiedzi.FindAsync(id);
        _context.Pytania_i_odpowiedzi.Remove((await _context.Pytania_i_odpowiedzi.FindAsync(id)));
       
        await _context.SaveChangesAsync();

        response.Success = true;
        response.Message = "Successfully deleted question and answer.";
        response.Data = response.Success;
        return response;
    }
    //metoda dodawania danych do tabeli Pytania_i_odpowiedzi
    public async Task<ServiceResponse<bool>> AddQuestionAnswerAsync(Pytania_i_odpowiedzi pytaniaIOdpowiedzi)
    {
        var response = new ServiceResponse<bool>();
        var maxId = _context.Pytania_i_odpowiedzi.Select(p => p.id).Max();
        if (maxId == 0)
        {
            response.Success = false;
            response.Message = "Cannot find any question and answers.";
            return response;
        }

        try
        {
            _context.Pytania_i_odpowiedzi.Add(new Pytania_i_odpowiedzi
            {
                id = maxId + 1,
                pytanie = pytaniaIOdpowiedzi.pytanie,
                odpowiedz = pytaniaIOdpowiedzi.odpowiedz,

            });
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Successfully added question and answer.";
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
            return response;
        }
    }
}
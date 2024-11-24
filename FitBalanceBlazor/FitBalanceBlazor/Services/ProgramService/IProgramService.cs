namespace FitBalanceBlazor.Services.ProgramService;

public interface IProgramService
{
    Task<List<Programy>> GetProgramsAsync();
    Task<Programy> GetProgramByIdAsync(int id);
}
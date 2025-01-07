using ClassLibrary1;

namespace FitBalanceBlazor.Services.ReportService;

public interface IReportService
{
    Task<ServiceResponse<List<Raport>>> GetDietRaportsAsync(int id);
    Task<ServiceResponse<List<Wypita_woda>>> GetWaterRaportsAsync(int id);
    Task<ServiceResponse<List<Pomiar_wagi>>> GetWeightRaportsAsync(int id);
}
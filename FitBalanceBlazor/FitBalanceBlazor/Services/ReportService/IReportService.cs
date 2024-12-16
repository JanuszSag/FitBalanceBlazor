namespace FitBalanceBlazor.Services.ReportService;

public interface IReportService
{
    Task<List<Raport>> GetDietRaportsAsync(int id);
    Task<List<Wypita_woda>> GetWaterRaportsAsync(int id);
    Task<List<Pomiar_wagi>> GetWeightRaportsAsync(int id);
}
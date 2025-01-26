using ClassLibrary1;

namespace FitBalanceBlazor.Services.UserService;

public interface IUserService
{
    public Task<ServiceResponse<Uzytkownik>> GetAllUserData(int userId);
    public Task<ServiceResponse<bool>> UpdateUserData(Uzytkownik uzytkownik);
    public Task<ServiceResponse<List<Uzytkownik>>> SearchListUserData();
    public Task<ServiceResponse<Uzytkownik>> GetUserDataWithDiet(int userId);
    public Task<ServiceResponse<bool>> AssignDiet(int userId, int dietId);
    public Task<ServiceResponse<bool>> AssignWater(int userId, int water);
}
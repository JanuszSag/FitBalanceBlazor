using ClassLibrary1;

namespace FitBalanceBlazor.Services.UserService;

public interface IUserService
{
    public Task<ServiceResponse<Uzytkownik>> GetAllUserData(int userId);
    public Task<ServiceResponse<bool>> UpdateUserData(Uzytkownik uzytkownik);
    public Task<ServiceResponse<List<Uzytkownik>>> SearchListUserData();
}
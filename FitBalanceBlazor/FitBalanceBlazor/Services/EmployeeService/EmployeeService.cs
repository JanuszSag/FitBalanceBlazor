using ClassLibrary1;
using FitBalanceBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor.Services.EmployeeService;

public class EmployeeService(MyDbContext context) : IEmployeeService
{
    public async Task<ServiceResponse<Pracownik>> GetEmployeePracownikAsync(int id)
    {
        var response = new ServiceResponse<Pracownik>();
        var employee = await context.Pracownik.FirstOrDefaultAsync(e => e.id_uzytkownik==id);
        if (employee is null)
        {
            response.Success = false;
            response.Message = "Cannot find employee.";
            return response;
        }
        response.Data = employee;
        response.Success = true;
        return response;
    }

    public async Task<ServiceResponse<List<Pracownik>>> GetAllEmployeesAsync()
    {
        var response = new ServiceResponse<List<Pracownik>>();
        var AllEmployees = await context.Pracownik.ToListAsync();
        if (AllEmployees is null)
        {
            response.Success = false;
            response.Message = "Cannot find employee.";
            return response;
        }
        response.Data = AllEmployees;
        response.Success = true;
        return response;
    }

    public async Task<ServiceResponse<bool>> AddEmployeeAsync(PracownikDTO pracownik)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var foundUser = await context.Uzytkownik.FindAsync(pracownik.id_uzytkownik);
            
            var newEmployee = new Pracownik
            {
                id_uzytkownik = pracownik.id_uzytkownik,
                id_pracownik = pracownik.id_pracownik,
                Adres = new List<Adres>(),
                imie = pracownik.imie,
                nazwisko = pracownik.nazwisko,
                numer_telefonu = pracownik.numer_telefonu,
                stanowisko = pracownik.stanowisko,
                id_uzytkownikNavigation = foundUser
            };
            
            await context.Pracownik.AddAsync(newEmployee);
            await context.SaveChangesAsync();
            response.Success = true;
            response.Data = true;
            response.Message = "Dodano pracownika";
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Data = false;
            response.Message = "Cannot add employee.";
            return response;
        }
    }

    public async Task<ServiceResponse<List<Adres>>> GetAllAddressesAsync()
    {
        var response = new ServiceResponse<List<Adres>>();
        var AllAddresses = await context.Adres.ToListAsync();
        response.Data = AllAddresses;
        response.Success = true;
        return response;
    }

    public async Task<ServiceResponse<bool>> AddAddressAsync(AdresDTO adress)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var foundEmp = await context.Pracownik.FindAsync(adress.id_pracownik);
            
            var newAdress = new Adres
            {
                id_adres = adress.id_adres,
                id_pracownik = adress.id_pracownik,
                miasto = adress.miasto,
                ulica = adress.ulica,
                numer_mieszkania = adress.numer_mieszkania,
                kod_pocztowy = adress.kod_pocztowy,
                id_pracownikNavigation = foundEmp
            };
            
            await context.Adres.AddAsync(newAdress);
            await context.SaveChangesAsync();
            response.Success = true;
            response.Data = true;
            response.Message = "Dodano adres";
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Cannot add Address.";
            return response;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteAddressAsync(int id)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var foundAdress = await context.Adres.FindAsync(id);
            context.Adres.Remove(foundAdress);
            await context.SaveChangesAsync();
            response.Success = true;
            response.Data = true;
            response.Message = "Removed address";
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Cannot delete Address.";
            return response;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var foundEmployee = await context.Pracownik.Include(x => x.Adres).FirstOrDefaultAsync(x => x.id_uzytkownik == id);
            if(foundEmployee.Adres.Count!=0)
                await DeleteAddressAsync(foundEmployee.Adres.ToList()[0].id_adres);
            context.Pracownik.Remove(foundEmployee);
            await context.SaveChangesAsync();
            response.Success = true;
            response.Data = true;
            response.Message = "Removed Employee";
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Cannot delete Employee.";
            return response;
        }    }

    public async Task<ServiceResponse<bool>> UpdateEmployeeAsync(PracownikDTO pracownik)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var foundEmployee = await context.Pracownik.FindAsync(pracownik.id_pracownik);
            foundEmployee.imie = pracownik.imie;
            foundEmployee.nazwisko = pracownik.nazwisko;
            foundEmployee.numer_telefonu = pracownik.numer_telefonu;
            foundEmployee.stanowisko = pracownik.stanowisko;
            foundEmployee.id_uzytkownik = pracownik.id_uzytkownik;
            context.Pracownik.Update(foundEmployee);
            await context.SaveChangesAsync();
            response.Success = true;
            response.Data = true;
            response.Message = "Updated Employee";
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Cannot update Address.";
            return response;
        }}
}
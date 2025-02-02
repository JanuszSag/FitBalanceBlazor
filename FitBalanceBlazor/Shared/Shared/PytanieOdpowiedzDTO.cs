namespace ClassLibrary1;
using FitBalanceBlazor;

public class PytanieOdpowiedzDTO
{
    public int id { get; set; }

    public string Pytanie { get; set; }

    public string Odpowiedz { get; set; }

    public PytanieOdpowiedzDTO(int id, string pytanie, string odpowiedz)
    {
        this.id = id;
        Pytanie = pytanie;
        Odpowiedz = odpowiedz;
    }
}
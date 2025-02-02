namespace ClassLibrary1;

public class OpiniaDTO
{
    public int id_opinia { get; set; }

    public int? ocena { get; set; }

    public string? zawartosc { get; set; }

    public DateOnly? data { get; set; }

    public int id_uzytkownik { get; set; }

    public int id_dieta { get; set; }
    public OpiniaDTO(int id, int rate, string content, int idUzytkownik)
    {
        this.id_opinia = id;
        ocena = rate;
        id_uzytkownik = idUzytkownik;
        DateOnly.FromDateTime(DateTime.Today);
        id_dieta = 1;
    }
}
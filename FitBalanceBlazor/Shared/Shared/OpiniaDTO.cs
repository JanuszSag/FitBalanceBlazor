namespace ClassLibrary1;

public class OpiniaDTO
{
    public int id_opinia { get; set; }

    public int? ocena { get; set; }

    public string? zawartosc { get; set; }

    public DateOnly? data { get; set; }

    public int id_uzytkownik { get; set; }

    public int id_dieta { get; set; }
}
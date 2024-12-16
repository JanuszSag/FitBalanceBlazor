namespace ClassLibrary1;

public class DietaDTO
{
    private int id { get; set; }
    private string Nazwa { get; set; }
    private string Opis { get; set; }
    private int kalorycznosc { get; set; }
    private int autor { get; set; }
    private int rodzaj { get; set; }

    public DietaDTO(int id, string nazwa, string opis, int kalorycznosc, int autor, int rodzaj)
    {
        this.id = id;
        Nazwa = nazwa;
        Opis = opis;
        this.kalorycznosc = kalorycznosc;
        this.autor = autor;
        this.rodzaj = rodzaj;
    }
}
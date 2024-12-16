namespace ClassLibrary1;

public class DietaDTO
{
    public int id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public int Kalorycznosc { get; set; }
    public int Autor { get; set; }
    public int Rodzaj { get; set; }

    public DietaDTO(int id, string nazwa, string opis, int kalorycznosc, int autor, int rodzaj)
    {
        this.id = id;
        Nazwa = nazwa;
        Opis = opis;
        this.Kalorycznosc = kalorycznosc;
        this.Autor = autor;
        this.Rodzaj = rodzaj;
    }
}
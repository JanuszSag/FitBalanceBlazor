using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Dieta
{
    public int IdDieta { get; set; }

    public string Nazwa { get; set; } = null!;

    public string? Opis { get; set; }

    public int Kalorycznosc { get; set; }

    public int Autor { get; set; }

    public int Rodzaj { get; set; }

    public virtual Pracownik AutorNavigation { get; set; } = null!;

    public virtual ICollection<Opinia> Opinia { get; set; } = new List<Opinia>();

    public virtual ICollection<PrzypisanaDieta> PrzypisanaDieta { get; set; } = new List<PrzypisanaDieta>();

    public virtual ICollection<Raport> Raports { get; set; } = new List<Raport>();

    public virtual Rodzaj RodzajNavigation { get; set; } = null!;

    public virtual ICollection<Danie> DanieIdDanies { get; set; } = new List<Danie>();

    public virtual ICollection<Produkt> IdProdukts { get; set; } = new List<Produkt>();
}

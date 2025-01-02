using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Dieta
{
    public int id_dieta { get; set; }

    public string? nazwa { get; set; }

    public string? opis { get; set; }

    public int? kalorycznosc { get; set; }

    public int autor { get; set; }

    public int rodzaj { get; set; }

    public virtual ICollection<Opinia> Opinia { get; set; } = new List<Opinia>();

    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();

    public virtual ICollection<Raport> Raport { get; set; } = new List<Raport>();

    public virtual Pracownik autorNavigation { get; set; } = null!;

    public virtual Rodzaj rodzajNavigation { get; set; } = null!;

    public virtual ICollection<Danie>? Danie_id_danie { get; set; } = new List<Danie>();

    public virtual ICollection<Produkt> id_produkt { get; set; } = new List<Produkt>();
}

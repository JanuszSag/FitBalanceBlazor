using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Danie
{
    public int id_danie { get; set; }

    public string? nazwa { get; set; }

    public virtual ICollection<Produkt_Danie> Produkt_Danie { get; set; } = new List<Produkt_Danie>();

    public virtual ICollection<Dieta> Dieta_id_dieta { get; set; } = new List<Dieta>();

    public virtual ICollection<Przypisana_dieta> id_przypisana_dieta { get; set; } = new List<Przypisana_dieta>();
}

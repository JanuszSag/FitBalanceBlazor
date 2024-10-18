using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Danie
{
    public int IdDanie { get; set; }

    public string Nazwa { get; set; } = null!;

    public int Kalorie { get; set; }

    public virtual ICollection<ProduktDanie> ProduktDanies { get; set; } = new List<ProduktDanie>();

    public virtual ICollection<Dieta> DietaIdDieta { get; set; } = new List<Dieta>();

    public virtual ICollection<PrzypisanaDieta> IdPrzypisanaDieta { get; set; } = new List<PrzypisanaDieta>();
}

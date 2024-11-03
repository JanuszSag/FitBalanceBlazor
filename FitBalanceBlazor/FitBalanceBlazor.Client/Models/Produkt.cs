using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Produkt
{
    public int IdProdukt { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<ProduktDanie> ProduktDanie { get; set; } = new List<ProduktDanie>();

    public virtual ICollection<Dieta> IdDieta { get; set; } = new List<Dieta>();
}

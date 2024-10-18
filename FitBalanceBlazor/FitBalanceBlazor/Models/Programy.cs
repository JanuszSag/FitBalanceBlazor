using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Programy
{
    public int IdProgram { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<PrzypisanaDieta> PrzypisanaDieta { get; set; } = new List<PrzypisanaDieta>();
}

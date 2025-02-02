using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Rodzaj
{
    public int id_rodzaj { get; set; }

    public string? nazwa { get; set; }

    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();
}

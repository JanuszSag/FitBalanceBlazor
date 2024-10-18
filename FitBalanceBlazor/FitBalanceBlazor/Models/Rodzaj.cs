using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Rodzaj
{
    public int IdRodzaj { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();
}

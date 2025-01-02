using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Programy
{
    public int id_program { get; set; }

    public string? nazwa { get; set; }

    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();
}

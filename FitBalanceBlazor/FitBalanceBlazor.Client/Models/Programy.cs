using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Programy
{
    public int id_program { get; set; }

    public string nazwa { get; set; } = null!;

    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();
}

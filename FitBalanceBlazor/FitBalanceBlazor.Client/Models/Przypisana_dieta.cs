using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Przypisana_dieta
{
    public int id_przypisana_dieta { get; set; }

    public int id_dieta { get; set; }

    public int id_uzytkownik { get; set; }

    public int id_program { get; set; }

    public virtual Dieta id_dietaNavigation { get; set; } = null!;

    public virtual Programy IdProgramyNavigation { get; set; } = null!;

    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;

    public virtual ICollection<Danie> id_danie { get; set; } = new List<Danie>();
}

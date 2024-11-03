using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class PrzypisanaDieta
{
    public int IdPrzypisanaDieta { get; set; }

    public int IdDieta { get; set; }

    public int IdUzytkownik { get; set; }

    public int IdProgram { get; set; }

    public virtual Dieta IdDietaNavigation { get; set; } = null!;

    public virtual Programy IdProgramyNavigation { get; set; } = null!;

    public virtual Uzytkownik IdUzytkownikNavigation { get; set; } = null!;

    public virtual ICollection<Danie> IdDanie { get; set; } = new List<Danie>();
}

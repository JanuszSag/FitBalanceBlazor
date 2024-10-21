using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Raport
{
    public int IdRaport { get; set; }

    public DateOnly Data { get; set; }

    public int Uzytkownik { get; set; }

    public int Dieta { get; set; }

    public virtual Dieta DietaNavigation { get; set; } = null!;

    public virtual Uzytkownik UzytkownikNavigation { get; set; } = null!;
}

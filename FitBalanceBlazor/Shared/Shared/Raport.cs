using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Raport
{
    public int id_raport { get; set; }

    public DateOnly? data { get; set; }

    public int uzytkownik { get; set; }

    public int dieta { get; set; }

    public virtual Dieta dietaNavigation { get; set; } = null!;

    public virtual Uzytkownik uzytkownikNavigation { get; set; } = null!;
}

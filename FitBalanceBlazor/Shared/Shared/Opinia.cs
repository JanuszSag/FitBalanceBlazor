using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Opinia
{
    public int id_opinia { get; set; }

    public int? ocena { get; set; }

    public string? zawartosc { get; set; }

    public DateOnly? data { get; set; }

    public int id_uzytkownik { get; set; }

    public int id_dieta { get; set; }

    public virtual Dieta id_dietaNavigation { get; set; } = null!;

    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

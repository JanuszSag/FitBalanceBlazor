using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Wypita_woda
{
    public int id_wypita_woda { get; set; }

    public DateOnly? data { get; set; }

    public int? ilosc { get; set; }

    public int id_uzytkownik { get; set; }

    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class WypitaWoda
{
    public int IdWypitaWoda { get; set; }

    public DateOnly Data { get; set; }

    public int Ilosc { get; set; }

    public int IdUzytkownik { get; set; }

    public virtual Uzytkownik IdUzytkownikNavigation { get; set; } = null!;
}

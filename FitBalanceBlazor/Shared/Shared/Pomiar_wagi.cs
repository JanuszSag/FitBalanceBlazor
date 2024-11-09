using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Pomiar_wagi
{
    public int id_pomiar { get; set; }

    public DateOnly data { get; set; }

    public int waga { get; set; }

    public int id_uzytkownik { get; set; }

    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

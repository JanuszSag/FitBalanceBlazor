using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class PomiarWagi
{
    public int IdPomiar { get; set; }

    public DateOnly Data { get; set; }

    public int Waga { get; set; }

    public int IdUzytkownik { get; set; }

    public virtual Uzytkownik IdUzytkownikNavigation { get; set; } = null!;
}

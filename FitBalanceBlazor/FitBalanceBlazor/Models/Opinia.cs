using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Opinia
{
    public int IdOpinia { get; set; }

    public int Ocena { get; set; }

    public string Zawartosc { get; set; } = null!;

    public DateOnly Data { get; set; }

    public int IdUzytkownik { get; set; }

    public int IdDieta { get; set; }

    public virtual Dieta IdDietaNavigation { get; set; } = null!;

    public virtual Uzytkownik IdUzytkownikNavigation { get; set; } = null!;
}

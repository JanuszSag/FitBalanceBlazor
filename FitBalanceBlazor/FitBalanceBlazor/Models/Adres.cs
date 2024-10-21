using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Adres
{
    public int IdAdres { get; set; }

    public int IdPracownik { get; set; }

    public string Miasto { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public string NumerMieszkania { get; set; } = null!;

    public string KodPocztowy { get; set; } = null!;

    public virtual Pracownik IdPracownikNavigation { get; set; } = null!;
}

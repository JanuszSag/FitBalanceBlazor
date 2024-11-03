using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Adres
{
    public int id_adres { get; set; }

    public int id_pracownik { get; set; }

    public string miasto { get; set; } = null!;

    public string ulica { get; set; } = null!;

    public string numer_mieszkania { get; set; } = null!;

    public string kod_pocztowy { get; set; } = null!;

    public virtual Pracownik id_pracownikNavigation { get; set; } = null!;
}

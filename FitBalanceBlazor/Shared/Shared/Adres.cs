using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Adres
{
    public int id_adres { get; set; }

    public int id_pracownik { get; set; }

    public string? miasto { get; set; }

    public string? ulica { get; set; }

    public string? numer_mieszkania { get; set; }

    public string? kod_pocztowy { get; set; }

    public virtual Pracownik id_pracownikNavigation { get; set; } = null!;
}

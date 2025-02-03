using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Pracownik
{
    public int id_pracownik { get; set; }

    public string? imie { get; set; }

    public string? nazwisko { get; set; }

    public string? numer_telefonu { get; set; }

    public string? stanowisko { get; set; }

    public int id_uzytkownik { get; set; }

    public virtual ICollection<Adres> Adres { get; set; } = new List<Adres>();

    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();

    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null;
}

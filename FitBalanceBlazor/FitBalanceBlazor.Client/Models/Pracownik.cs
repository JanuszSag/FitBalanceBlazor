using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Pracownik
{
    public int IdPracownik { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public DateOnly DataUrodzenia { get; set; }

    public string NumerTelefonu { get; set; } = null!;

    public string Stanowisko { get; set; } = null!;

    public int IdUzytkownik { get; set; }

    public virtual ICollection<Adres> Adres { get; set; } = new List<Adres>();

    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();

    public virtual Uzytkownik IdUzytkownikNavigation { get; set; } = null!;
}

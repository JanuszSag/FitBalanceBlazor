using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Uzytkownik
{
    public int IdUzytkownik { get; set; }

    public string Pseudonim { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DataUrodzenia { get; set; }

    public string Plec { get; set; } = null!;

    public int Wzrost { get; set; }

    public int Waga { get; set; }

    public int ZapotrzebowanieKaloryczne { get; set; }

    public string HasloHashed { get; set; } = null!;

    public string HasloSalt { get; set; } = null!;

    public virtual ICollection<Opinia> Opinia { get; set; } = new List<Opinia>();

    public virtual ICollection<PomiarWagi> PomiarWagis { get; set; } = new List<PomiarWagi>();

    public virtual ICollection<Pracownik> Pracowniks { get; set; } = new List<Pracownik>();

    public virtual ICollection<PrzypisanaDieta> PrzypisanaDieta { get; set; } = new List<PrzypisanaDieta>();

    public virtual ICollection<Raport> Raports { get; set; } = new List<Raport>();

    public virtual ICollection<WypitaWoda> WypitaWoda { get; set; } = new List<WypitaWoda>();
}

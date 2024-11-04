using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Uzytkownik
{
    public int id_uzytkownik { get; set; }

    public string pseudonim { get; set; } = null!;

    public string email { get; set; } = null!;

    public DateOnly data_urodzenia { get; set; }

    public string plec { get; set; } = null!;

    public int wzrost { get; set; }

    public int waga { get; set; }

    public int zapotrzebowanie_kaloryczne { get; set; }

    public string haslo_hashed { get; set; } = null!;

    public string haslo_salt { get; set; } = null!;

    public virtual ICollection<Opinia> Opinia { get; set; } = new List<Opinia>();

    public virtual ICollection<Pomiar_wagi> Pomiar_wagi { get; set; } = new List<Pomiar_wagi>();

    public virtual ICollection<Pracownik> Pracownik { get; set; } = new List<Pracownik>();

    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();

    public virtual ICollection<Raport> Raport { get; set; } = new List<Raport>();

    public virtual ICollection<Wypita_woda> Wypita_woda { get; set; } = new List<Wypita_woda>();
}

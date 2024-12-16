using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Uzytkownik
{
    [Key]
    public int id_uzytkownik { get; set; }

    [Column(TypeName = "text")]
    public string pseudonim { get; set; } = null!;

    [Column(TypeName = "text")]
    public string email { get; set; } = null!;

    public DateOnly data_urodzenia { get; set; }

    [Column(TypeName = "text")]
    public string plec { get; set; } = null!;

    public int wzrost { get; set; }

    public int waga { get; set; }

    public int zapotrzebowanie_kaloryczne { get; set; }

    public byte[]? haslo_hashed { get; set; }

    public byte[]? haslo_salt { get; set; }

    [InverseProperty("id_uzytkownikNavigation")]
    public virtual ICollection<Opinia> Opinia { get; set; } = new List<Opinia>();

    [InverseProperty("id_uzytkownikNavigation")]
    public virtual ICollection<Pomiar_wagi> Pomiar_wagi { get; set; } = new List<Pomiar_wagi>();

    [InverseProperty("id_uzytkownikNavigation")]
    public virtual ICollection<Pracownik> Pracownik { get; set; } = new List<Pracownik>();

    [InverseProperty("id_uzytkownikNavigation")]
    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();

    [InverseProperty("uzytkownikNavigation")]
    public virtual ICollection<Raport> Raport { get; set; } = new List<Raport>();

    [InverseProperty("id_uzytkownikNavigation")]
    public virtual ICollection<Wypita_woda> Wypita_woda { get; set; } = new List<Wypita_woda>();
}

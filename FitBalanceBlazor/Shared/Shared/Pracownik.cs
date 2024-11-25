using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Pracownik
{
    [Key]
    public int id_pracownik { get; set; }

    [Column(TypeName = "text")]
    public string imie { get; set; } = null!;

    [Column(TypeName = "text")]
    public string nazwisko { get; set; } = null!;

    [Column(TypeName = "text")]
    public string numer_telefonu { get; set; } = null!;

    [Column(TypeName = "text")]
    public string stanowisko { get; set; } = null!;

    public int id_uzytkownik { get; set; }

    [InverseProperty("id_pracownikNavigation")]
    public virtual ICollection<Adres> Adres { get; set; } = new List<Adres>();

    [InverseProperty("autorNavigation")]
    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();

    [ForeignKey("id_uzytkownik")]
    [InverseProperty("Pracownik")]
    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

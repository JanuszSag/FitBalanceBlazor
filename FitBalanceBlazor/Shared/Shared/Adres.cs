using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Adres
{
    [Key]
    public int id_adres { get; set; }

    public int id_pracownik { get; set; }

    [Column(TypeName = "text")]
    public string miasto { get; set; } = null!;

    [Column(TypeName = "text")]
    public string ulica { get; set; } = null!;

    [Column(TypeName = "text")]
    public string numer_mieszkania { get; set; } = null!;

    [Column(TypeName = "text")]
    public string kod_pocztowy { get; set; } = null!;

    [ForeignKey("id_pracownik")]
    [InverseProperty("Adres")]
    public virtual Pracownik id_pracownikNavigation { get; set; } = null!;
}

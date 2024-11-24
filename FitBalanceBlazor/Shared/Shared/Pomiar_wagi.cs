using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Pomiar_wagi
{
    [Key]
    public int id_pomiar { get; set; }

    public DateOnly data { get; set; }

    public int waga { get; set; }

    public int id_uzytkownik { get; set; }

    [ForeignKey("id_uzytkownik")]
    [InverseProperty("Pomiar_wagi")]
    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

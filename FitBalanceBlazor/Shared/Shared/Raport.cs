using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Raport
{
    [Key]
    public int id_raport { get; set; }

    public DateOnly data { get; set; }

    public int uzytkownik { get; set; }

    public int dieta { get; set; }

    [ForeignKey("dieta")]
    [InverseProperty("Raport")]
    public virtual Dieta dietaNavigation { get; set; } = null!;

    [ForeignKey("uzytkownik")]
    [InverseProperty("Raport")]
    public virtual Uzytkownik uzytkownikNavigation { get; set; } = null!;
}

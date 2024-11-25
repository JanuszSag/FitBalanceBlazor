using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Opinia
{
    [Key]
    public int id_opinia { get; set; }

    public int ocena { get; set; }

    [Column(TypeName = "text")]
    public string zawartosc { get; set; } = null!;

    public DateOnly data { get; set; }

    public int id_uzytkownik { get; set; }

    public int id_dieta { get; set; }

    [ForeignKey("id_dieta")]
    [InverseProperty("Opinia")]
    public virtual Dieta id_dietaNavigation { get; set; } = null!;

    [ForeignKey("id_uzytkownik")]
    [InverseProperty("Opinia")]
    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Przypisana_dieta
{
    [Key]
    public int id_przypisana_dieta { get; set; }

    public int id_dieta { get; set; }

    public int id_uzytkownik { get; set; }

    public int id_program { get; set; }

    [ForeignKey("id_dieta")]
    [InverseProperty("Przypisana_dieta")]
    public virtual Dieta id_dietaNavigation { get; set; } = null!;

    [ForeignKey("id_program")]
    [InverseProperty("Przypisana_dieta")]
    public virtual Programy id_programNavigation { get; set; } = null!;

    [ForeignKey("id_uzytkownik")]
    [InverseProperty("Przypisana_dieta")]
    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;

    [ForeignKey("id_przypisana_dieta")]
    [InverseProperty("id_przypisana_dieta")]
    public virtual ICollection<Danie> id_danie { get; set; } = new List<Danie>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Programy
{
    [Key]
    public int id_program { get; set; }

    [Column(TypeName = "text")]
    public string nazwa { get; set; } = null!;

    [InverseProperty("id_programNavigation")]
    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Rodzaj
{
    [Key]
    public int id_rodzaj { get; set; }

    [Column(TypeName = "text")]
    public string nazwa { get; set; } = null!;

    [InverseProperty("rodzajNavigation")]
    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();
}

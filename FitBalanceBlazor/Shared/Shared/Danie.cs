using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Danie
{
    [Key]
    public int id_danie { get; set; }

    [Column(TypeName = "text")]
    public string nazwa { get; set; } = null!;

    [InverseProperty("id_danieNavigation")]
    public virtual ICollection<Produkt_Danie> Produkt_Danie { get; set; } = null;

    [ForeignKey("Danie_id_danie")]
    [InverseProperty("Danie_id_danie")]
    public virtual ICollection<Dieta> Dieta_id_dieta { get; set; } = null;

    [ForeignKey("id_danie")]
    [InverseProperty("id_danie")]
    public virtual ICollection<Przypisana_dieta> id_przypisana_dieta { get; set; } = null;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Produkt
{
    [Key]
    public int id_produkt { get; set; }

    [Column(TypeName = "text")]
    public string nazwa { get; set; } = null!;

    [InverseProperty("id_produktNavigation")]
    public virtual ICollection<Produkt_Danie> Produkt_Danie { get; set; } = new List<Produkt_Danie>();

    [ForeignKey("id_produkt")]
    [InverseProperty("id_produkt")]
    public virtual ICollection<Dieta> id_dieta { get; set; } = new List<Dieta>();
}

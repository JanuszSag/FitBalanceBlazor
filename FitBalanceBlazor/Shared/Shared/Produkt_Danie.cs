using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

[PrimaryKey("id_produkt", "id_danie")]
public partial class Produkt_Danie
{
    [Key]
    public int id_produkt { get; set; }

    [Key]
    public int id_danie { get; set; }

    public int ilosc { get; set; }

    [ForeignKey("id_danie")]
    [InverseProperty("Produkt_Danie")]
    public virtual Danie id_danieNavigation { get; set; } = null!;

    [ForeignKey("id_produkt")]
    [InverseProperty("Produkt_Danie")]
    public virtual Produkt id_produktNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Wypita_woda
{
    [Key]
    public int id_wypita_woda { get; set; }

    public DateOnly data { get; set; }

    public int ilosc { get; set; }

    public int id_uzytkownik { get; set; }

    [ForeignKey("id_uzytkownik")]
    [InverseProperty("Wypita_woda")]
    public virtual Uzytkownik id_uzytkownikNavigation { get; set; } = null!;
}

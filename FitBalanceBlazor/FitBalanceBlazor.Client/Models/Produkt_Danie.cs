using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Produkt_Danie
{
    public int id_produkt { get; set; }

    public int id_danie { get; set; }

    public int ilosc { get; set; }

    public virtual Danie id_danieNavigation { get; set; } = null!;

    public virtual Produkt id_produktNavigation { get; set; } = null!;
}

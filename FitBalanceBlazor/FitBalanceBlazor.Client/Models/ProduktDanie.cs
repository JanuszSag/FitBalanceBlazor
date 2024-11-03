using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class ProduktDanie
{
    public int IdProdukt { get; set; }

    public int IdDanie { get; set; }

    public int Ilosc { get; set; }

    public virtual Danie IdDanieNavigation { get; set; } = null!;

    public virtual Produkt IdProduktNavigation { get; set; } = null!;
}

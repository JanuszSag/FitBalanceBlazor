﻿using System;
using System.Collections.Generic;

namespace FitBalanceBlazor.Models;

public partial class Produkt
{
    public int id_produkt { get; set; }

    public string nazwa { get; set; } = null!;

    public virtual ICollection<Produkt_Danie> Produkt_Danie { get; set; } = new List<Produkt_Danie>();

    public virtual ICollection<Dieta> id_dieta { get; set; } = new List<Dieta>();
}

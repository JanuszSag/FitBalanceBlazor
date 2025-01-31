using System;
using System.Collections.Generic;

namespace FitBalanceBlazor;

public partial class Pytania_i_odpowiedzi
{
    public int id { get; set; }

    public string pytanie { get; set; } = null!;

    public string odpowiedz { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitBalanceBlazor;

public partial class Dieta
{
    [Key]
    public int id_dieta { get; set; }

    [Column(TypeName = "text")]
    public string nazwa { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? opis { get; set; }

    public int kalorycznosc { get; set; }

    public int autor { get; set; }

    public int rodzaj { get; set; }

    [InverseProperty("id_dietaNavigation")]
    public virtual ICollection<Opinia> Opinia { get; set; } = new List<Opinia>();

    [InverseProperty("id_dietaNavigation")]
    public virtual ICollection<Przypisana_dieta> Przypisana_dieta { get; set; } = new List<Przypisana_dieta>();

    [InverseProperty("dietaNavigation")]
    public virtual ICollection<Raport> Raport { get; set; } = new List<Raport>();

    [ForeignKey("autor")]
    [InverseProperty("Dieta")]
    public virtual Pracownik autorNavigation { get; set; } = null!;

    [ForeignKey("rodzaj")]
    [InverseProperty("Dieta")]
    public virtual Rodzaj rodzajNavigation { get; set; } = null!;

    [ForeignKey("Dieta_id_dieta")]
    [InverseProperty("Dieta_id_dieta")]
    public virtual ICollection<Danie> Danie_id_danie { get; set; } = new List<Danie>();

    [ForeignKey("id_dieta")]
    [InverseProperty("id_dieta")]
    public virtual ICollection<Produkt> id_produkt { get; set; } = new List<Produkt>();
}

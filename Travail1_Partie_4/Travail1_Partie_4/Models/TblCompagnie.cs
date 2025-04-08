﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travail1_Partie_4.Models;

[Table("tbl_compagnie")]
[Index("Nom", Name = "UQ__tbl_comp__DF90DC2CBAEC8812", IsUnique = true)]
public partial class TblCompagnie
{
    [Key]
    [Column("id_compagnie")]
    public int IdCompagnie { get; set; }

    [Column("nom")]
    [StringLength(200)]
    public string Nom { get; set; }

    [InverseProperty("IdCompagnieNavigation")]
    public virtual ICollection<TblProjet> TblProjets { get; set; } = new List<TblProjet>();
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travail1_Partie_4.Models;

[Table("tbl_projet")]
[Index("Description", Name = "UQ__tbl_proj__489B0D97AA6E5471", IsUnique = true)]
[Index("Nom", Name = "UQ__tbl_proj__DF90DC2CBDD7C7DE", IsUnique = true)]
public partial class TblProjet
{
    [Key]
    [Column("id_projet")]
    public int IdProjet { get; set; }

    [Column("nom")]
    [StringLength(200)]
    public string Nom { get; set; }

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; }

    [Column("id_compagnie")]
    public int IdCompagnie { get; set; }

    [ForeignKey("IdCompagnie")]
    [InverseProperty("TblProjets")]
    public virtual TblCompagnie IdCompagnieNavigation { get; set; }

    [InverseProperty("IdProjetNavigation")]
    public virtual ICollection<TblStock> TblStocks { get; set; } = new List<TblStock>();
}
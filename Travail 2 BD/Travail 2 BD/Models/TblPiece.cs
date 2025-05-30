﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travail_2_BD.Models;

[Table("tbl_piece")]
[Index("NumeroIndustrie", Name = "UQ__tbl_piec__2742638F4AAB0FDD", IsUnique = true)]
public partial class TblPiece
{
    [Key]
    [Column("id_piece")]
    public int IdPiece { get; set; }

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; }

    [Column("numeroIndustrie")]
    [StringLength(200)]
    public string NumeroIndustrie { get; set; }

    [InverseProperty("IdPieceNavigation")]
    public virtual ICollection<TblStock> TblStocks { get; set; } = new List<TblStock>();
}
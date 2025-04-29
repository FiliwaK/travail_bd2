using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Travail_2_BD.Models
{
    public partial class Bd_ReseauContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VueListerQuantitePrevueProjet>(entity =>
            {
                entity.HasKey(i => new { i.IdStock });
                entity.UpdateUsingStoredProcedure("ModifierQuantitePrevueProjet", sp =>
                {
                    sp.HasOriginalValueParameter(i => i.IdStock);
                    sp.HasParameter(i => i.IdProjet); // ne fait pas partie de la clé de la table a modifier
                    sp.HasParameter(i => i.NomProjet);
                    sp.HasParameter(i => i.IdPiece);
                    sp.HasParameter(i => i.NomPiece);
                    sp.HasParameter(i => i.QuantitePrevu); 
                });

                entity.ToTable("TblStock", i => i.ExcludeFromMigrations());
            });
        }
    }
}

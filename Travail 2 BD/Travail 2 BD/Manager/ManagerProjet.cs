using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travail_2_BD.Models;

namespace Travail_2_BD.Manager
{
    public class ManagerProjet
    {
        Bd_ReseauContext Context;

        public List<TblProjet> ListerProjetEagerLoading()
        {
            try
            {
                using (var context = new Bd_ReseauContext())
                {
                    return context.TblProjets.Include(c => c.TblStocks).OrderBy(c => c.Nom).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VueListerQuantitePrevueProjet> ListerPieces(int projetSelectionne)
        {

            Context = new Bd_ReseauContext();// parce ce qu'on fait des modications dans les vues, pour ne pas fermer le context

            return Context.VueListerQuantitePrevueProjets.Where(l => l.IdProjet == projetSelectionne).OrderBy(p => p.NomProjet).ToList();      
        }

        public int EnregistrerChangementDeQuantite()
        {
            int nombreLigne = 0;
            try
            {
                nombreLigne = Context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                //if (ex.InnerException is SqlException sqlException)
                {
                    if (ex.InnerException.Message.Contains("CHECK") && ex.InnerException.Message.Contains("quantite_prevu"))
                    {
                        MessageBox.Show("La quantite que vous demander est superieur a la quantite prevu");
                        var ligneErreur = ex.Entries.Single();
                        ligneErreur.Property("QuantitePrevu").CurrentValue = ligneErreur.Property("QuantitePrevu").OriginalValue;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return nombreLigne;
        }
    }
}

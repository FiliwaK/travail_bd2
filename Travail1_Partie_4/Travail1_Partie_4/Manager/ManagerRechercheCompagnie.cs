using Microsoft.EntityFrameworkCore;
using Travail1_Partie_4.Models;
using System.Collections.Generic;
using System.Linq;

namespace Travail1_Partie_4
{
    public class ManagerRechercheCompagnie
    {
        private Bd_ReseauContext context;

        public ManagerRechercheCompagnie()
        {
            context = new Bd_ReseauContext();
        }
        public List<TblCompagnie> ObtenirToutesLesCompagnies()
        {
            return context.TblCompagnies
                          .Include(c => c.TblProjets)
                          .ToList();
        }

        public List<TblProjet> ObtenirProjetsDeLaCompagnie(int idCompagnie)
        {
            var compagnie = context.TblCompagnies
                                   .Include(c => c.TblProjets)
                                   .FirstOrDefault(c => c.IdCompagnie == idCompagnie);

            return compagnie?.TblProjets.ToList();
        }

        public List<TblCompagnie> ObtenirToutesLesCompagniesSansProjets()
        {
            return context.TblCompagnies.ToList();
        }

        public List<TblProjet> ChargerLesProjetsPourCompagnie(int idCompagnie)
        {
            var compagnie = context.TblCompagnies.FirstOrDefault(c => c.IdCompagnie == idCompagnie);

            if (compagnie != null)
            {
                context.Entry(compagnie)
                       .Collection(c => c.TblProjets)
                       .Load();

                return compagnie.TblProjets.ToList();
            }

            return new List<TblProjet>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travail1_Partie_4.Models;

namespace Travail1_Partie_4.Manager
{
    public class ManagerPiece
    {

        public async Task<List<RechercherPieceParNumeroIndustrieResult>> ListerPiece(string numeroDePiece)  
        {
            List<RechercherPieceParNumeroIndustrieResult> listeDesPieces;
            using (var context = new Bd_ReseauContext())
            {
                listeDesPieces = await context.Procedures.RechercherPieceParNumeroIndustrieAsync(numeroDePiece);
            }
            return listeDesPieces;
        }

        public async Task<List<RechercherProjetsParNumeroIndustrieResult>> ListerProjet(string numeroDePiece) 
        {
            List<RechercherProjetsParNumeroIndustrieResult> listeDesProjets;
            using (var context = new Bd_ReseauContext())
            {
                listeDesProjets = await context.Procedures.RechercherProjetsParNumeroIndustrieAsync(numeroDePiece);
            }
            return listeDesProjets;
        }

        public async Task AjouterImputation(int noEmploye, int noProjet, int noPiece, int quantiteImputee, DateTime dateImputation)
        {
            using (var context = new Bd_ReseauContext())
            {
                await context.Procedures.AjouterImputationAsync(noEmploye, noProjet, noPiece, quantiteImputee, dateImputation);
            }
        }

    }
}

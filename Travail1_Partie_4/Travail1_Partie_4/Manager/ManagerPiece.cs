using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travail1_Partie_4.Models;

namespace Travail1_Partie_4.Manager
{
    internal class ManagerPiece
    {
        public List<TblPiece> ListPiece(string recherche)
        {
            using (var context = new Bd_ReseauContext())
            {
                return context.TblPieces.Where(e => EF.Functions.Like(e.NumeroIndustrie, $"%{recherche}%")).Take(100).ToList();

            }
        }
        public int RechercherPieceParNumero(TblPiece piece)
        {
            int nombreLigneAffectee = 0;

            using (var context = new Bd_ReseauContext())
            {
                var pieceRechercher = context.TblPieces.Find(piece.NumeroIndustrie);
                if (pieceRechercher != null)
                {
                    pieceRechercher.Description = piece.Description;
                    nombreLigneAffectee = context.SaveChanges();
                }
            }
            return nombreLigneAffectee;
        }
    }
}

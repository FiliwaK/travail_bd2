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
        //public List<TblPiece> ListPiece(string recherche)
        //{
        //    using (var context = new Bd_ReseauContext())
        //    {
        //        return context.TblPieces.Where(e => EF.Functions.Like(e.NumeroIndustrie, $"%{recherche}%")).OrderBy(e => e.NumeroIndustrie).ToList();
        //    }
        //}

        public async Task<List<RechercherPieceParNumeroIndustrieResult>> ListPiece(string numeroDePiece) //pour afficher dans un messagebox, procedure qui retourne un scalaire 
        {
            List<RechercherPieceParNumeroIndustrieResult> listeDesPieces;
            using (var context = new Bd_ReseauContext())
            {
                listeDesPieces = await context.Procedures.RechercherPieceParNumeroIndustrieAsync(numeroDePiece);
            }
            return listeDesPieces;
        }

    }
}

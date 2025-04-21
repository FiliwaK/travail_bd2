using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
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

        public async Task AjouterImputationAvecUpdateStock(int noEmploye, int noProjet, int noPiece, int quantiteImputee, DateTime dateImputation)
        {
            
                try
                {
                        using (var context = new Bd_ReseauContext())
                        {
                            var stock = await context.TblStocks
                            .FirstOrDefaultAsync(s => s.IdPiece == noPiece && s.IdProjet == noProjet);

                            if (stock == null)
                            throw new Exception("Stock introuvable.");


                            var imputation = new TblImpute
                            {
                                IdEmployee = noEmploye,
                                IdStock = stock.IdStock,
                                QuantiteImpute = quantiteImputee,
                                DateImputee = dateImputation
                            };

                            context.TblImputes.Add(imputation);

                            await context.Procedures.MettreAJourStockAsync(noPiece, noProjet, quantiteImputee);


                            context.SaveChanges();
                        }

                }

                catch (DbUpdateException ExDbUpdate)
                {
                    var errorMessage = "Erreur, corrigez puis réessayer. \n\r";
                    if (ExDbUpdate.InnerException is SqlException sqlException)
                    {
                        if (sqlException.Number == 50001)
                        {
                            errorMessage += "La quantité demandée dépasse le stock disponible.";
                        }
                        else
                        {
                            errorMessage += $" Error Number: {sqlException.Number}\n\r Message: {sqlException.Message}\n\r";
                        }
                    }   
                    throw new Exception(errorMessage);
                }


                catch (Exception)
                {
                    throw;
                }
        }
    }
}

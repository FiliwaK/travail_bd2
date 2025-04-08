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
    public class ManagerEmploye
    {
        public List<TblEmployee> ListerEmployee(string recherche)
        {
            using (var context = new Bd_ReseauContext())
            {
                return context.TblEmployees.Where(e => EF.Functions.Like(e.Nom, $"%{recherche}%") || EF.Functions.Like(e.Prenom, $"%{recherche}%")).OrderBy(e => e.Nom).ToList();
            }
        }

        public int ModifierEmployee(TblEmployee Employee)
        {
            int nombreLigneAffectee = 0;
            try
            {
                using(var context = new Bd_ReseauContext())
                {
                    var employeModifie = context.TblEmployees.Find(Employee.IdEmployee);

                    employeModifie.IdEmployee = Employee.IdEmployee;
                    employeModifie.Prenom = Employee.Prenom;
                    employeModifie.Nom = Employee.Nom;
                    employeModifie.Email = Employee.Email;

                    nombreLigneAffectee = context.SaveChanges();
                }

                    return nombreLigneAffectee;
            }

            catch (DbUpdateException ExDbUpdate)
            {
                var errorMessage = "Erreur, corrigez puis réessayer. \n\r";
                if (ExDbUpdate.InnerException is SqlException sqlException)
                {
                    if (sqlException.Number == 547 && sqlException.Message.Contains("email"))
                    {
                        errorMessage += $"il manque un arrobase à l'email. \n\r";
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

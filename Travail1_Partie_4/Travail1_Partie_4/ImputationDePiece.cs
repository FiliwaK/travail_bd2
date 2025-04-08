using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Travail1_Partie_4.Manager;
using Travail1_Partie_4.Models;

namespace Travail1_Partie_4
{
    public partial class ImputationDePiece : Form
    {
        List<TblPiece> pieces;

        public ImputationDePiece()
        {
            InitializeComponent();
        }

        private void FiltrerRechercheComboBox(string recherche)
        {
            var managerPiece = new ManagerPiece();
            pieces = managerPiece.ListPiece(recherche);
            //selectionnerEmploye_ComboBox.DataSource = employes;
            //selectionnerEmploye_ComboBox.DisplayMember = "NomComplet";
            //selectionnerEmploye_ComboBox.ValueMember = "IdEmployee"; //ce n'est pas le nom de la colonne dans la base de Donnees mais le nom de la colonne dans la classe
            //selectionnerEmploye_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //selectionnerEmploye_ComboBox.SelectedValue = "";

            remplirDataGridView();

        }

        private void remplirDataGridView()
        {
            try
            {
                selectionner_DataGridView.DataSource = pieces;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recherche_Button_Click(object sender, EventArgs e)
        {
            string recherche = numeroPiece_TextBox.Text;
            FiltrerRechercheComboBox(recherche);
        }
    }
}

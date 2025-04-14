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
        List<RechercherPieceParNumeroIndustrieResult> pieces;
        List<RechercherProjetsParNumeroIndustrieResult> projets;

        public ImputationDePiece()
        {
            InitializeComponent();
        }

        private async void FiltrerRechercheComboBox(string recherche)
        {
            var managerPiece = new ManagerPiece();
            pieces = await managerPiece.ListerPiece(recherche);
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
            selectionner_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            selectionner_DataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);

        }

        private void RemplirProjetComboBox()
        {
            choisirUnProjet_ComboBox.DataSource = projets;
            choisirUnProjet_ComboBox.DisplayMember = "nom_projet";
            choisirUnProjet_ComboBox.ValueMember = "id_projet";
            choisirUnProjet_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            choisirUnProjet_ComboBox.SelectedValue = "";
        }

        private async void selectionner_DataGridView_Click(object sender, EventArgs e)
        {
            ManagerPiece managerPiece = new ManagerPiece();
            string noPiece = (string)selectionner_DataGridView[0, selectionner_DataGridView.CurrentRow.Index].Value;
            projets = await managerPiece.ListerProjet(noPiece);
            RemplirProjetComboBox();
        }

        private void choisirEmployer_Button_Click(object sender, EventArgs e)
        {
            List<TblEmployee> employeSelectionne = new List<TblEmployee>();
            var maForme = new RechercherModifierEmploye();
            var result = maForme.ShowDialog();
            employeSelectionne.Add(maForme.ListeDEmployee());

            choisirUnEmployer_ComboBox.DataSource = employeSelectionne;
            choisirUnEmployer_ComboBox.DisplayMember = "NomComplet";
            choisirUnEmployer_ComboBox.ValueMember = "idemployee";
            choisirUnEmployer_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            choisirUnEmployer_ComboBox.SelectedValue = "";

        }

        private void ajouterImputation_Button_Click(object sender, EventArgs e)
        {

        }
    }
}

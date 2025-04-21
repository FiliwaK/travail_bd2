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
            try
            {
                // Vérification de tous les champs requis
                if (choisirUnEmployer_ComboBox.SelectedItem == null ||
                    choisirUnProjet_ComboBox.SelectedItem == null ||
                    selectionner_DataGridView.CurrentRow == null ||
                    string.IsNullOrWhiteSpace(quantite_TextBox.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs avant d'ajouter l'imputation.");
                    return;
                }

                int noEmploye = (int)choisirUnEmployer_ComboBox.SelectedValue;
                int noProjet = (int)choisirUnProjet_ComboBox.SelectedValue;
                int noPiece = (int)selectionner_DataGridView[1, selectionner_DataGridView.CurrentRow.Index].Value; // colonne id interne
                int quantiteImputee = int.Parse(quantite_TextBox.Text);
                DateTime dateImputation = DateTime.Today;

                // Appel du manager
                var managerPiece = new ManagerPiece();
                await managerPiece.AjouterImputation(noEmploye, noProjet, noPiece, quantiteImputee, dateImputation);

                MessageBox.Show("Imputation effectuée avec succès.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Quantité invalide. Veuillez entrer un nombre entier.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'imputation : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Travail_2_BD.Manager;
using Travail_2_BD.Models;

namespace Travail_2_BD
{
    public partial class ChangerQuantiteForm : Form
    {
        List<TblProjet> projets;
        TblProjet projetSelectionne;
        ManagerProjet managerProjet = new ManagerProjet();

        public ChangerQuantiteForm()
        {
            InitializeComponent();
        }

        private void RemplirComboBoxProjet()
        {
            projets = managerProjet.ListerProjetEagerLoading();
            nomProjetComboBox.DataSource = projets;
            nomProjetComboBox.ValueMember = "IdProjet";
            nomProjetComboBox.DisplayMember = "Nom";
            nomProjetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            nomProjetComboBox.SelectedValue = "";
        }

        private void nomProjetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChangerQuantiteForm_Load(object sender, EventArgs e)
        {
            RemplirComboBoxProjet();

        }

        private void remplirDataGridView()
        {
            pieceDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pieceDataGridView.Columns["IdStock"].Visible = false;
            pieceDataGridView.Columns["IdProjet"].Visible = false;
            pieceDataGridView.Columns["NomProjet"].Visible = false;
            pieceDataGridView.Columns["IdPiece"].Visible = false;
        }

        private void nomProjetComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int noProjet = (int)nomProjetComboBox.SelectedValue;
            projetSelectionne = projets.FirstOrDefault(p => p.IdProjet == noProjet);
            pieceDataGridView.DataSource = managerProjet.ListerPieces(noProjet);
            remplirDataGridView();
        }

        private void pieceDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int nombreLigneAffectee = managerProjet.EnregistrerChangementDeQuantite();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void supprimerProjetButton_Click(object sender, EventArgs e)
        {
            var messageDeSuppression = MessageBox.Show("Etes-Vous sure de vouloir supprimer ce projet ?", "Supprimer projet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageDeSuppression == DialogResult.Yes)
            {
                try
                {
                    int noProjet = (int)nomProjetComboBox.SelectedValue;
                    int nombreDeligneAffectee = await managerProjet.SupprimerProjetEtRestaurerInventaireAsync(noProjet);
                    if (nombreDeligneAffectee > 0) 
                    {
                        MessageBox.Show("Suppression du projet réussi");
                        RemplirComboBoxProjet();

                    }

                }
                catch (Exception)
                {

                    throw;
                }


            }

        }
    }
}

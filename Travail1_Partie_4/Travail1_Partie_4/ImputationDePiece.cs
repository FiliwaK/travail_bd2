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
    }
}

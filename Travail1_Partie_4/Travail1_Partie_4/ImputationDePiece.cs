using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travail1_Partie_4
{
    public partial class ImputationDePiece : Form
    {
        public ImputationDePiece()
        {
            InitializeComponent();
        }
        private void RechercherPiece()
        {

        }

        private void recherche_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numeroPiece_TextBox.Text))
            {
                MessageBox.Show("Veuillez entrer un numéro de pièce ou une partie de celui-ci.");
                return;
            }
            RechercherPiece();
        }
    }
}

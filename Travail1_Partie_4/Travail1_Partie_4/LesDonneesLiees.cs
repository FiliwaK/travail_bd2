using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Travail1_Partie_4.Models;

namespace Travail1_Partie_4
{
    public partial class LesDonneesLiees : Form
    {
        List<TblCompagnie> compagnies;
        Bd_ReseauContext context1;
        public LesDonneesLiees()
        {
            InitializeComponent();
        }
        private void DesactiverLesColonnesenTrop(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dataGridView.Columns["Compagnies"].Visible = false;
        }

        private void button_Recherchee_Click(object sender, EventArgs e)
        {
            using (var context = new Bd_ReseauContext())
            {
                compagnies = context.TblCompagnies
                    .Include(c => c.TblProjets)
                    .ToList();

                eagleLoading_DataGridView.DataSource = compagnies;

                DesactiverLesColonnesenTrop(eagleLoadingCompagnie_DataGridView);
                eagleLoading_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                eagleLoading_DataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                //PrendreLaColonneChoisir(e);

            }
        }


        private void LesDonneesLiees_Load(object sender, EventArgs e)
        {

        }
       private int PrendreLaPieceChoisir(DataGridView dataGridView)
        {
            return (int)dataGridView[0, dataGridView.CurrentRow.Index].Value;
        }

        private void eagleLoading_DataGridView_Click(object sender, EventArgs e)
        {
            int noCompagnie = PrendreLaPieceChoisir(eagleLoading_DataGridView);
            var pieceRechercher = compagnies.FirstOrDefault(p=> p.IdCompagnie == noCompagnie);
            eagleLoadingCompagnie_DataGridView.DataSource = pieceRechercher.TblProjets;

        }
    }
}

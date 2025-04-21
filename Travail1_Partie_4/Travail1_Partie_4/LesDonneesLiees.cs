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
        private ManagerRechercheCompagnie _managerRechercheCompagnie;
        private List<TblCompagnie> compagnies;
        public LesDonneesLiees()
        {
            InitializeComponent();
            _managerRechercheCompagnie = new ManagerRechercheCompagnie();
        }
        private void DesactiverLesColonnesenTrop(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["TblProjets"].Visible = false;
           // dataGridView.Columns[""].Visible = false ;
        }

        private void button_Recherchee_Click(object sender, EventArgs e)
        {
            compagnies = _managerRechercheCompagnie.ObtenirToutesLesCompagnies();
            eagleLoading_DataGridView.DataSource = compagnies;
            DesactiverLesColonnesenTrop(eagleLoading_DataGridView);
            eagleLoading_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            eagleLoading_DataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            DesactiverLesColonnesenTrop(eagleLoading_DataGridView);
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
            try
            {
                int noCompagnie = PrendreLaPieceChoisir(eagleLoading_DataGridView);

                var projets = _managerRechercheCompagnie.ObtenirProjetsDeLaCompagnie(noCompagnie);

                eagleLoadingCompagnie_DataGridView.DataSource = projets;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

        }

        private void button_Rechercher_Click(object sender, EventArgs e)
        {
            var compagniesSansProjets = _managerRechercheCompagnie.ObtenirToutesLesCompagniesSansProjets();
            explicytLoadingRecherche_DataGridView.DataSource = compagniesSansProjets;

            DesactiverLesColonnesenTrop(explicytLoadingRecherche_DataGridView);
            explicytLoadingRecherche_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            explicytLoadingRecherche_DataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            explicytLoadingRecherche_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            explicytLoadingRecherche_DataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);

        }

        private void explicytLoading_DataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                int noCompagnie = PrendreLaPieceChoisir(explicytLoadingRecherche_DataGridView);

                var projets = _managerRechercheCompagnie.ChargerLesProjetsPourCompagnie(noCompagnie);

                explicytLoadingDataGridView.DataSource = projets;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            explicytLoadingDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            explicytLoadingDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }
    }
}

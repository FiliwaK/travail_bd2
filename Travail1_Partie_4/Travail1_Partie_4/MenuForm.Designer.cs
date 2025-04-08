namespace Travail1_Partie_4
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            rechercherModifierToolStripMenuItem = new ToolStripMenuItem();
            imputationDePieceToolStripMenuItem = new ToolStripMenuItem();
            lesDonneesLieesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { rechercherModifierToolStripMenuItem, imputationDePieceToolStripMenuItem, lesDonneesLieesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // rechercherModifierToolStripMenuItem
            // 
            rechercherModifierToolStripMenuItem.Name = "rechercherModifierToolStripMenuItem";
            rechercherModifierToolStripMenuItem.Size = new Size(128, 20);
            rechercherModifierToolStripMenuItem.Text = "Rechercher/Modifier";
            rechercherModifierToolStripMenuItem.Click += rechercherModifierToolStripMenuItem_Click;
            // 
            // imputationDePieceToolStripMenuItem
            // 
            imputationDePieceToolStripMenuItem.Name = "imputationDePieceToolStripMenuItem";
            imputationDePieceToolStripMenuItem.Size = new Size(130, 20);
            imputationDePieceToolStripMenuItem.Text = "Imputation_De_Piece";
            imputationDePieceToolStripMenuItem.Click += imputationDePieceToolStripMenuItem_Click;
            // 
            // lesDonneesLieesToolStripMenuItem
            // 
            lesDonneesLieesToolStripMenuItem.Name = "lesDonneesLieesToolStripMenuItem";
            lesDonneesLieesToolStripMenuItem.Size = new Size(118, 20);
            lesDonneesLieesToolStripMenuItem.Text = "Les_Donnees_Liees";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuForm";
            Text = "MenuForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem rechercherModifierToolStripMenuItem;
        private ToolStripMenuItem imputationDePieceToolStripMenuItem;
        private ToolStripMenuItem lesDonneesLieesToolStripMenuItem;
    }
}
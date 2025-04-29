namespace Travail_2_BD
{
    partial class ChangerQuantiteForm
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
            groupBox1 = new GroupBox();
            nomProjetComboBox = new ComboBox();
            label1 = new Label();
            pieceDataGridView = new DataGridView();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pieceDataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nomProjetComboBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(77, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(635, 84);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rechercher Un Projet";
            // 
            // nomProjetComboBox
            // 
            nomProjetComboBox.FormattingEnabled = true;
            nomProjetComboBox.Location = new Point(138, 33);
            nomProjetComboBox.Name = "nomProjetComboBox";
            nomProjetComboBox.Size = new Size(470, 23);
            nomProjetComboBox.TabIndex = 1;
            nomProjetComboBox.SelectionChangeCommitted += nomProjetComboBox_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 36);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Nom du projet";
            // 
            // pieceDataGridView
            // 
            pieceDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pieceDataGridView.Location = new Point(37, 153);
            pieceDataGridView.Name = "pieceDataGridView";
            pieceDataGridView.Size = new Size(718, 275);
            pieceDataGridView.TabIndex = 1;
            pieceDataGridView.CellEndEdit += pieceDataGridView_CellEndEdit;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 135);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "Pieces";
            // 
            // ChangerQuantiteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(pieceDataGridView);
            Controls.Add(groupBox1);
            Name = "ChangerQuantiteForm";
            Text = "ChangerQuantiteForm";
            Load += ChangerQuantiteForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pieceDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox nomProjetComboBox;
        private Label label1;
        private DataGridView pieceDataGridView;
        private Label label2;
    }
}
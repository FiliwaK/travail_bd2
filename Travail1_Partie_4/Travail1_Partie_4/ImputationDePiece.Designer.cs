namespace Travail1_Partie_4
{
    partial class ImputationDePiece
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
            recherche_Button = new Button();
            numeroPiece_TextBox = new TextBox();
            selectionner_DataGridView = new DataGridView();
            label1 = new Label();
            numero_Label = new Label();
            groupBox3 = new GroupBox();
            choisirEmployer_Button = new Button();
            choisirUnEmployer_ComboBox = new ComboBox();
            label3 = new Label();
            projet_GroupBox = new GroupBox();
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            choisrUnProjet_omboBox = new ComboBox();
            label_projet = new Label();
            ajouterEmputation_Button = new Button();
            quantite_NumericUpDown = new NumericUpDown();
            label4 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)selectionner_DataGridView).BeginInit();
            groupBox3.SuspendLayout();
            projet_GroupBox.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quantite_NumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(recherche_Button);
            groupBox1.Controls.Add(numeroPiece_TextBox);
            groupBox1.Controls.Add(selectionner_DataGridView);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numero_Label);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(877, 193);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Recherche une piece avec ou sans scanner";
            // 
            // recherche_Button
            // 
            recherche_Button.Location = new Point(599, 20);
            recherche_Button.Name = "recherche_Button";
            recherche_Button.Size = new Size(149, 34);
            recherche_Button.TabIndex = 6;
            recherche_Button.Text = "Recherche";
            recherche_Button.UseVisualStyleBackColor = true;
            recherche_Button.Click += recherche_Button_Click;
            // 
            // numeroPiece_TextBox
            // 
            numeroPiece_TextBox.Location = new Point(295, 31);
            numeroPiece_TextBox.Name = "numeroPiece_TextBox";
            numeroPiece_TextBox.Size = new Size(169, 23);
            numeroPiece_TextBox.TabIndex = 5;
            // 
            // selectionner_DataGridView
            // 
            selectionner_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            selectionner_DataGridView.Location = new Point(176, 107);
            selectionner_DataGridView.Name = "selectionner_DataGridView";
            selectionner_DataGridView.Size = new Size(443, 71);
            selectionner_DataGridView.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(215, 78);
            label1.Name = "label1";
            label1.Size = new Size(209, 15);
            label1.TabIndex = 2;
            label1.Text = "Numero de piece ou partie de numero";
            // 
            // numero_Label
            // 
            numero_Label.AutoSize = true;
            numero_Label.Location = new Point(36, 35);
            numero_Label.Name = "numero_Label";
            numero_Label.Size = new Size(209, 15);
            numero_Label.TabIndex = 1;
            numero_Label.Text = "Numero de piece ou partie de numero";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(choisirEmployer_Button);
            groupBox3.Controls.Add(choisirUnEmployer_ComboBox);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(23, 335);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(849, 71);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Employe";
            // 
            // choisirEmployer_Button
            // 
            choisirEmployer_Button.Location = new Point(676, 31);
            choisirEmployer_Button.Name = "choisirEmployer_Button";
            choisirEmployer_Button.Size = new Size(142, 27);
            choisirEmployer_Button.TabIndex = 7;
            choisirEmployer_Button.Text = "Choisr un employer";
            choisirEmployer_Button.UseVisualStyleBackColor = true;
            // 
            // choisirUnEmployer_ComboBox
            // 
            choisirUnEmployer_ComboBox.FormattingEnabled = true;
            choisirUnEmployer_ComboBox.Location = new Point(237, 31);
            choisirUnEmployer_ComboBox.Name = "choisirUnEmployer_ComboBox";
            choisirUnEmployer_ComboBox.Size = new Size(317, 23);
            choisirUnEmployer_ComboBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 28);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 5;
            label3.Text = "Choisir un employe";
            // 
            // projet_GroupBox
            // 
            projet_GroupBox.Controls.Add(groupBox2);
            projet_GroupBox.Controls.Add(choisrUnProjet_omboBox);
            projet_GroupBox.Controls.Add(label_projet);
            projet_GroupBox.Location = new Point(23, 252);
            projet_GroupBox.Name = "projet_GroupBox";
            projet_GroupBox.Size = new Size(849, 67);
            projet_GroupBox.TabIndex = 4;
            projet_GroupBox.TabStop = false;
            projet_GroupBox.Text = "Projet";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(6, 83);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(925, 99);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Projet";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(237, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(317, 23);
            comboBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 28);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 5;
            label2.Text = "Choisir un projet";
            // 
            // choisrUnProjet_omboBox
            // 
            choisrUnProjet_omboBox.FormattingEnabled = true;
            choisrUnProjet_omboBox.Location = new Point(237, 31);
            choisrUnProjet_omboBox.Name = "choisrUnProjet_omboBox";
            choisrUnProjet_omboBox.Size = new Size(317, 23);
            choisrUnProjet_omboBox.TabIndex = 6;
            // 
            // label_projet
            // 
            label_projet.AutoSize = true;
            label_projet.Location = new Point(25, 28);
            label_projet.Name = "label_projet";
            label_projet.Size = new Size(95, 15);
            label_projet.TabIndex = 5;
            label_projet.Text = "Choisir un projet";
            // 
            // ajouterEmputation_Button
            // 
            ajouterEmputation_Button.Location = new Point(227, 497);
            ajouterEmputation_Button.Name = "ajouterEmputation_Button";
            ajouterEmputation_Button.Size = new Size(142, 27);
            ajouterEmputation_Button.TabIndex = 9;
            ajouterEmputation_Button.Text = "Ajouter une emputation";
            ajouterEmputation_Button.UseVisualStyleBackColor = true;
            // 
            // quantite_NumericUpDown
            // 
            quantite_NumericUpDown.Location = new Point(230, 456);
            quantite_NumericUpDown.Name = "quantite_NumericUpDown";
            quantite_NumericUpDown.Size = new Size(178, 23);
            quantite_NumericUpDown.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 454);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 10;
            label4.Text = "Quantitee";
            // 
            // ImputationDePiece
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 554);
            Controls.Add(quantite_NumericUpDown);
            Controls.Add(ajouterEmputation_Button);
            Controls.Add(label4);
            Controls.Add(groupBox3);
            Controls.Add(projet_GroupBox);
            Controls.Add(groupBox1);
            Name = "ImputationDePiece";
            Text = "ImputationDePiece";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)selectionner_DataGridView).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            projet_GroupBox.ResumeLayout(false);
            projet_GroupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)quantite_NumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button recherche_Button;
        private TextBox numeroPiece_TextBox;
        private DataGridView selectionner_DataGridView;
        private Label label1;
        private Label numero_Label;
        private GroupBox groupBox3;
        private Button choisirEmployer_Button;
        private ComboBox choisirUnEmployer_ComboBox;
        private Label label3;
        private GroupBox projet_GroupBox;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox choisrUnProjet_omboBox;
        private Label label_projet;
        private Button ajouterEmputation_Button;
        private NumericUpDown quantite_NumericUpDown;
        private Label label4;
    }
}
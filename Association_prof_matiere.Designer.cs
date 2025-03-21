namespace Application_Examen
{
    partial class Association_prof_matiere
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonModif = new System.Windows.Forms.Button();
            this.buttonSupp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulaire d\'association d\'un professeur a une matiere";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Matieres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Professeurs";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(172, 191);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 4;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(12, 270);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(82, 31);
            this.buttonAjouter.TabIndex = 5;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(196, 270);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(81, 31);
            this.buttonAnnuler.TabIndex = 6;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(463, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(695, 220);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonModif
            // 
            this.buttonModif.Location = new System.Drawing.Point(502, 366);
            this.buttonModif.Name = "buttonModif";
            this.buttonModif.Size = new System.Drawing.Size(94, 38);
            this.buttonModif.TabIndex = 8;
            this.buttonModif.Text = "Modifier";
            this.buttonModif.UseVisualStyleBackColor = true;
            this.buttonModif.Click += new System.EventHandler(this.buttonModif_Click);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(746, 366);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(100, 38);
            this.buttonSupp.TabIndex = 9;
            this.buttonSupp.Text = "Supprimer";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // Association_prof_matiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 696);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonModif);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Association_prof_matiere";
            this.Text = "Association_prof_matiere";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonModif;
        private System.Windows.Forms.Button buttonSupp;
    }
}
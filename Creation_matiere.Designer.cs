namespace Application_Examen
{
    partial class Creation_matiere
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
            this.textNom = new System.Windows.Forms.TextBox();
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
            this.label1.Location = new System.Drawing.Point(192, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulaire de creation d\'une matiere";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom de la matiere";
            // 
            // textNom
            // 
            this.textNom.Location = new System.Drawing.Point(225, 96);
            this.textNom.Multiline = true;
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(143, 26);
            this.textNom.TabIndex = 2;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(75, 182);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(99, 36);
            this.buttonAjouter.TabIndex = 3;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(225, 182);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(99, 36);
            this.buttonAnnuler.TabIndex = 4;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(572, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(592, 191);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonModif
            // 
            this.buttonModif.Location = new System.Drawing.Point(601, 307);
            this.buttonModif.Name = "buttonModif";
            this.buttonModif.Size = new System.Drawing.Size(113, 43);
            this.buttonModif.TabIndex = 6;
            this.buttonModif.Text = "Modifier";
            this.buttonModif.UseVisualStyleBackColor = true;
            this.buttonModif.Click += new System.EventHandler(this.buttonModif_Click);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(831, 307);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(109, 43);
            this.buttonSupp.TabIndex = 7;
            this.buttonSupp.Text = "Supprimer";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // Creation_matiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 450);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonModif);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.textNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Creation_matiere";
            this.Text = "Creation_matiere";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonModif;
        private System.Windows.Forms.Button buttonSupp;
    }
}
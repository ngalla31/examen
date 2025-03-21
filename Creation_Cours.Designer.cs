namespace Application_Examen
{
    partial class Creation_Cours
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textNom = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.buttonAjout = new System.Windows.Forms.Button();
            this.buttonAnnul = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(467, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulaire de creation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nom";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textNom
            // 
            this.textNom.Location = new System.Drawing.Point(130, 127);
            this.textNom.Multiline = true;
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(142, 26);
            this.textNom.TabIndex = 4;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(130, 219);
            this.textDesc.Multiline = true;
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(142, 26);
            this.textDesc.TabIndex = 5;
            // 
            // buttonAjout
            // 
            this.buttonAjout.Location = new System.Drawing.Point(38, 315);
            this.buttonAjout.Name = "buttonAjout";
            this.buttonAjout.Size = new System.Drawing.Size(109, 47);
            this.buttonAjout.TabIndex = 6;
            this.buttonAjout.Text = "Ajouter";
            this.buttonAjout.UseVisualStyleBackColor = true;
            this.buttonAjout.Click += new System.EventHandler(this.buttonAjout_Click);
            // 
            // buttonAnnul
            // 
            this.buttonAnnul.Location = new System.Drawing.Point(200, 315);
            this.buttonAnnul.Name = "buttonAnnul";
            this.buttonAnnul.Size = new System.Drawing.Size(109, 47);
            this.buttonAnnul.TabIndex = 7;
            this.buttonAnnul.Text = "Annuler";
            this.buttonAnnul.UseVisualStyleBackColor = true;
            this.buttonAnnul.Click += new System.EventHandler(this.buttonAnnul_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(472, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(615, 320);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonModif
            // 
            this.buttonModif.Location = new System.Drawing.Point(501, 439);
            this.buttonModif.Name = "buttonModif";
            this.buttonModif.Size = new System.Drawing.Size(112, 37);
            this.buttonModif.TabIndex = 9;
            this.buttonModif.Text = "Modifier";
            this.buttonModif.UseVisualStyleBackColor = true;
            this.buttonModif.Click += new System.EventHandler(this.buttonModif_Click);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(704, 439);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(131, 37);
            this.buttonSupp.TabIndex = 10;
            this.buttonSupp.Text = "Supprimer";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // Creation_Cours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 594);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonModif);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnnul);
            this.Controls.Add(this.buttonAjout);
            this.Controls.Add(this.textDesc);
            this.Controls.Add(this.textNom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Creation_Cours";
            this.Text = "Creation d\'un cours";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.Button buttonAjout;
        private System.Windows.Forms.Button buttonAnnul;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonModif;
        private System.Windows.Forms.Button buttonSupp;
    }
}
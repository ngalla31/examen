namespace Application_Examen
{
    partial class Crud_prof
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textNom = new System.Windows.Forms.TextBox();
            this.textTel = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPrenom = new System.Windows.Forms.TextBox();
            this.buttonAjout = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(72, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulaire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Telephone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prenom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nom";
            // 
            // textNom
            // 
            this.textNom.Location = new System.Drawing.Point(106, 99);
            this.textNom.Multiline = true;
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(129, 26);
            this.textNom.TabIndex = 5;
            // 
            // textTel
            // 
            this.textTel.Location = new System.Drawing.Point(121, 358);
            this.textTel.Multiline = true;
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(129, 26);
            this.textTel.TabIndex = 6;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(106, 277);
            this.textEmail.Multiline = true;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(129, 26);
            this.textEmail.TabIndex = 7;
            // 
            // textPrenom
            // 
            this.textPrenom.Location = new System.Drawing.Point(106, 186);
            this.textPrenom.Multiline = true;
            this.textPrenom.Name = "textPrenom";
            this.textPrenom.Size = new System.Drawing.Size(129, 26);
            this.textPrenom.TabIndex = 8;
            // 
            // buttonAjout
            // 
            this.buttonAjout.Location = new System.Drawing.Point(12, 451);
            this.buttonAjout.Name = "buttonAjout";
            this.buttonAjout.Size = new System.Drawing.Size(103, 47);
            this.buttonAjout.TabIndex = 9;
            this.buttonAjout.Text = "Ajouter";
            this.buttonAjout.UseVisualStyleBackColor = true;
            this.buttonAjout.Click += new System.EventHandler(this.buttonAjout_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(190, 451);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(103, 47);
            this.buttonAnnuler.TabIndex = 10;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(415, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(741, 303);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonModif
            // 
            this.buttonModif.Location = new System.Drawing.Point(533, 327);
            this.buttonModif.Name = "buttonModif";
            this.buttonModif.Size = new System.Drawing.Size(103, 47);
            this.buttonModif.TabIndex = 12;
            this.buttonModif.Text = "Modifier";
            this.buttonModif.UseVisualStyleBackColor = true;
            this.buttonModif.Click += new System.EventHandler(this.buttonModif_Click);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(796, 327);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(103, 47);
            this.buttonSupp.TabIndex = 13;
            this.buttonSupp.Text = "Supprimer";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // Crud_prof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 700);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonModif);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonAjout);
            this.Controls.Add(this.textPrenom);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textTel);
            this.Controls.Add(this.textNom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Crud_prof";
            this.Text = "Formulaire de creation d\'un prof";
            this.Load += new System.EventHandler(this.Crud_prof_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textPrenom;
        private System.Windows.Forms.Button buttonAjout;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonModif;
        private System.Windows.Forms.Button buttonSupp;
    }
}
namespace Application_Examen
{
    partial class Etudiant_crud
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textNom = new System.Windows.Forms.TextBox();
            this.textPrenom = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioHomme = new System.Windows.Forms.RadioButton();
            this.radioFemme = new System.Windows.Forms.RadioButton();
            this.textAdresse = new System.Windows.Forms.TextBox();
            this.textTel = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonAjout = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonModif = new System.Windows.Forms.Button();
            this.buttonSupp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formulaire_creation_etudiant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adresse";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sexe";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date_naiss";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Prenom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Telephone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 521);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Classe";
            // 
            // textNom
            // 
            this.textNom.Location = new System.Drawing.Point(165, 100);
            this.textNom.Multiline = true;
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(136, 26);
            this.textNom.TabIndex = 8;
            // 
            // textPrenom
            // 
            this.textPrenom.Location = new System.Drawing.Point(165, 172);
            this.textPrenom.Multiline = true;
            this.textPrenom.Name = "textPrenom";
            this.textPrenom.Size = new System.Drawing.Size(136, 26);
            this.textPrenom.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(165, 235);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 26);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // radioHomme
            // 
            this.radioHomme.AutoSize = true;
            this.radioHomme.Location = new System.Drawing.Point(151, 295);
            this.radioHomme.Name = "radioHomme";
            this.radioHomme.Size = new System.Drawing.Size(90, 24);
            this.radioHomme.TabIndex = 11;
            this.radioHomme.TabStop = true;
            this.radioHomme.Text = "Homme";
            this.radioHomme.UseVisualStyleBackColor = true;
            // 
            // radioFemme
            // 
            this.radioFemme.AutoSize = true;
            this.radioFemme.Location = new System.Drawing.Point(260, 295);
            this.radioFemme.Name = "radioFemme";
            this.radioFemme.Size = new System.Drawing.Size(88, 24);
            this.radioFemme.TabIndex = 12;
            this.radioFemme.TabStop = true;
            this.radioFemme.Text = "Femme";
            this.radioFemme.UseVisualStyleBackColor = true;
            this.radioFemme.CheckedChanged += new System.EventHandler(this.radioFemme_CheckedChanged);
            // 
            // textAdresse
            // 
            this.textAdresse.Location = new System.Drawing.Point(165, 347);
            this.textAdresse.Multiline = true;
            this.textAdresse.Name = "textAdresse";
            this.textAdresse.Size = new System.Drawing.Size(136, 26);
            this.textAdresse.TabIndex = 13;
            this.textAdresse.TextChanged += new System.EventHandler(this.textAdresse_TextChanged);
            // 
            // textTel
            // 
            this.textTel.Location = new System.Drawing.Point(165, 458);
            this.textTel.Multiline = true;
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(136, 26);
            this.textTel.TabIndex = 14;
            this.textTel.TextChanged += new System.EventHandler(this.textTel_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(165, 521);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 28);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonAjout
            // 
            this.buttonAjout.Location = new System.Drawing.Point(63, 590);
            this.buttonAjout.Name = "buttonAjout";
            this.buttonAjout.Size = new System.Drawing.Size(93, 33);
            this.buttonAjout.TabIndex = 16;
            this.buttonAjout.Text = "Ajouter";
            this.buttonAjout.UseVisualStyleBackColor = true;
            this.buttonAjout.Click += new System.EventHandler(this.buttonAjout_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(208, 590);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(93, 33);
            this.buttonAnnuler.TabIndex = 17;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(413, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(791, 420);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonModif
            // 
            this.buttonModif.Location = new System.Drawing.Point(494, 482);
            this.buttonModif.Name = "buttonModif";
            this.buttonModif.Size = new System.Drawing.Size(102, 47);
            this.buttonModif.TabIndex = 19;
            this.buttonModif.Text = "Modifier";
            this.buttonModif.UseVisualStyleBackColor = true;
            this.buttonModif.Click += new System.EventHandler(this.buttonModif_Click);
            // 
            // buttonSupp
            // 
            this.buttonSupp.Location = new System.Drawing.Point(725, 482);
            this.buttonSupp.Name = "buttonSupp";
            this.buttonSupp.Size = new System.Drawing.Size(102, 47);
            this.buttonSupp.TabIndex = 20;
            this.buttonSupp.Text = "Supprimer";
            this.buttonSupp.UseVisualStyleBackColor = true;
            this.buttonSupp.Click += new System.EventHandler(this.buttonSupp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Email";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(165, 408);
            this.textEmail.Multiline = true;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(136, 26);
            this.textEmail.TabIndex = 22;
            // 
            // Etudiant_crud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 703);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonSupp);
            this.Controls.Add(this.buttonModif);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonAjout);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textTel);
            this.Controls.Add(this.textAdresse);
            this.Controls.Add(this.radioFemme);
            this.Controls.Add(this.radioHomme);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textPrenom);
            this.Controls.Add(this.textNom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Etudiant_crud";
            this.Text = "Formalites";
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.TextBox textPrenom;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioHomme;
        private System.Windows.Forms.RadioButton radioFemme;
        private System.Windows.Forms.TextBox textAdresse;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonAjout;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonModif;
        private System.Windows.Forms.Button buttonSupp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textEmail;
    }
}
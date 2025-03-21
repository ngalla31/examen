using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Application_Examen
{
    public partial class Liste_des_etudiants_classe : Form
    {
        public Liste_des_etudiants_classe()
        {
            InitializeComponent();
            chargerClasses();
        }

        private void Liste_des_etudiants_classe_Load(object sender, EventArgs e)
        {
            
        }
        public void chargerClasses()
        {
            using (var db = new DBcontextApp())
            {
                comboBox1.DataSource=db.Classe.ToList();
                comboBox1.DisplayMember = "nomClasse";
                comboBox1.ValueMember = "id";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedValue != null)
            {
                // int selectedClasseId = comboBox1.SelectedValue;
                int selectedClasseId = ((Classe)comboBox1.SelectedItem).id;


                using (var db= new DBcontextApp()) // Remplacez par votre DbContext
                {
                    var etudiants = db.Etudiants
               .Where(et => et.idClasse == selectedClasseId)  // Filtre par l'ID de la classe sélectionnée
                .Select(et => new
     {
                  et.matricule,
                  et.nom,              // Nom de l'étudiant
                  et.prenom,           // Prénom de l'étudiant
                   et.sexe,             // Sexe de l'étudiant
                  et.adresse,          // Adresse de l'étudiant
                  et.dateNaiss,    // Date de naissance de l'étudiant
                   et.tel         // Téléphone de l'étudiant
                 })
                 .ToList();  // Récupère la liste filtrée avec seulement les informations nécessaires


                    // Lier les données des élèves au DataGridView
                    dataGridView1.DataSource = etudiants;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers PDF (*.pdf)|*.pdf",
                Title = "Enregistrer la liste de la classe",
                FileName = "Liste de la classe.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("Nom de fichier invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Aucune donnée à exporter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Créer un document PDF
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = "Liste de la classe";

                    // Ajouter une page au document
                    PdfPage page = pdf.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont font = new XFont("Times New Roman", 12);
                    XFont headerFont = new XFont("Times New Roman", 12);

                    double margin = 40;
                    double yPoint = margin;

                    // Créer un tableau pour les en-têtes de colonnes
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Visible)
                        {
                            gfx.DrawString(column.HeaderText, headerFont, XBrushes.Black, new XPoint(margin, yPoint));
                            margin += 100;  // Espacer les colonnes (ajuster selon la largeur des colonnes)
                        }
                    }

                    // Réinitialiser la marge horizontale
                    margin = 40;
                    yPoint += 20; // Ajouter un peu d'espace sous les en-têtes

                    // Ajouter les lignes de données
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.Visible)
                                {
                                    gfx.DrawString(cell.Value?.ToString() ?? "", font, XBrushes.Black, new XPoint(margin, yPoint));
                                    margin += 100;  // Espacer les colonnes (ajuster selon la largeur des colonnes)
                                }
                            }
                            yPoint += 20;
                            margin = 40;  // Réinitialiser la marge horizontale après chaque ligne
                        }
                    }

                    // Sauvegarder le fichier PDF
                    pdf.Save(filePath);

                    MessageBox.Show("Relevé généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la génération du PDF : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

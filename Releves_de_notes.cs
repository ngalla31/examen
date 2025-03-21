using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Application_Examen
{
    public partial class Releves_de_notes : Form
    {
        public Releves_de_notes()
        {
            InitializeComponent();
            chargerClasses();
        }

        private void Releves_de_notes_Load(object sender, EventArgs e)
        {

        }
        public void ChargerMoyennes1(int idEtudiant)
        {
            using (var db = new DBcontextApp())
            {
                var calculMoyenne = new CalculMoyennes(db);

                // 🔹 Charger les moyennes par matière
                var moyennes = calculMoyenne.CalculerMoyenneParMatiere(idEtudiant);
                dataGridView1.DataSource = moyennes;

                // 🔹 Calculer et afficher la moyenne générale
                double moyenneGenerale = calculMoyenne.CalculerMoyenneGenerale(idEtudiant);
                labelMoyenneGenerale.Text = "Moyenne Générale : " + moyenneGenerale.ToString("0.00");
            }
        }

        private void comboClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboClasse.SelectedValue != null)
            {
                var selectedClasse = comboClasse.SelectedItem as Classe;
                int idClasse = selectedClasse.id;
                chargerEtudiants(idClasse);
            }
        }

        public void chargerEtudiants(int idClasse)
        {
            using (var db = new DBcontextApp())
            {
                comboEtudiant.DataSource = db.Etudiants
                    .Where(e => e.idClasse == idClasse) // Filtrer les étudiants par classe
                    .Select(e => new { e.id, NomComplet = e.nom + " " + e.prenom })
                    .ToList();

                comboEtudiant.DisplayMember = "NomComplet";
                comboEtudiant.ValueMember = "Id";
            }
        }
        public void chargerClasses()
        {
            using (var db = new DBcontextApp())
            {
                comboClasse.DataSource = db.Classe.ToList();
                comboClasse.DisplayMember = "nomClasse";
                comboClasse.ValueMember = "id";
            }

        }

        private void comboEtudiant_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (comboEtudiant.SelectedValue != null)
            {
                int idEtudiant = Convert.ToInt32(comboEtudiant.SelectedValue);
                //int idEtudiant = Convert.ToInt32(comboEtudiant.SelectedValue.ToString());

                ChargerMoyennes(idEtudiant);
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ChargerMoyennes(int idEtudiant)
        {
            using (var db = new DBcontextApp())
            {
                // Création de la liste pour stocker les moyennes par matière
                var moyennes = db.Notes
                    .Where(n => n.idEtudiant == idEtudiant)
                    .GroupBy(n => n.idMatiere)
                    .Select(g => new NoteMoyenne
                    {
                        // Récupérer le nom de la matière à partir de l'ID
                        NomMatiere = db.Matieres.Where(m => m.id == g.Key).Select(m => m.nomMatiere).FirstOrDefault(),
                        // Calculer la moyenne des notes pour cette matière
                        Moyenne = g.Average(n => n.note)
                    })
                    .ToList();

                // Affecter la liste des moyennes au DataGridView
                dataGridView1.DataSource = moyennes;

                // Calcul de la moyenne générale pour cet étudiant
                float moyenneGenerale = db.Notes
                .Where(n => n.idEtudiant == idEtudiant)
                 .Select(n => n.note)  // On sélectionne les notes
                .DefaultIfEmpty(0)  // Remplacer les nulls par 0 (si nécessaire)
                .Average();  // Calcul de la moyenne

                // Affichage de la moyenne générale dans un label
                labelMoyenneGenerale.Text =   moyenneGenerale.ToString("0.00");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idEtudiant = Convert.ToInt32(comboEtudiant.SelectedValue);
            ChargerMoyennes(idEtudiant);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void genererPDF_Click(object sender, EventArgs e)
        {
            // Ouvrir la boîte de dialogue pour sauvegarder le fichier PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers PDF (*.pdf)|*.pdf",
                Title = "Enregistrer le relevé de notes",
                FileName = "Releve_De_Notes.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Vérifier que le fichier est valide
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("Nom de fichier invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier si le DataGridView est vide
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Aucune donnée à exporter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier si le fichier est déjà ouvert
                if (File.Exists(filePath))
                {
                    try
                    {
                        using (FileStream testStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None)) { }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Le fichier PDF est déjà ouvert. Fermez-le et réessayez.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                try
                {
                    // Créer un nouveau document PDF
                    PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                    document.Info.Title = "Relevé de Notes";

                    // Ajouter une page au document
                    PdfSharp.Pdf.PdfPage page = document.AddPage();

                    // Créer un objet graphique pour dessiner sur la page
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont titleFont = new XFont("Times New Roman", 18);
                    XFont regularFont = new XFont("Times New Roman", 12);

                    // Ajouter le titre
                    gfx.DrawString("Relevé de Notes", titleFont, XBrushes.Black, new XPoint(page.Width / 2, 50), XStringFormats.Center);

                    // Ajouter un saut de ligne
                    gfx.DrawString("\n", regularFont, XBrushes.Black, new XPoint(50, 100));

                    // Position de départ pour les données du tableau
                    double yPosition = 130;

                    // Créer les en-têtes de colonne
                    double xPosition = 50;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Visible)
                        {
                            gfx.DrawString(column.HeaderText, regularFont, XBrushes.Black, new XPoint(xPosition, yPosition));
                            xPosition += 100; // Espacer les colonnes
                        }
                    }

                    // Ajouter les données du DataGridView
                    yPosition += 20; // Sauter une ligne pour commencer à ajouter les données

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            xPosition = 50;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.OwningColumn.Visible)
                                {
                                    gfx.DrawString(cell.Value?.ToString() ?? "", regularFont, XBrushes.Black, new XPoint(xPosition, yPosition));
                                    xPosition += 100; // Espacer les colonnes
                                }
                            }
                            yPosition += 20; // Sauter une ligne pour la prochaine ligne de données
                        }
                    }

                    // Ajouter la moyenne générale en bas du tableau
                    string moyenneText = string.IsNullOrEmpty(labelMoyenneGenerale.Text) ? "N/A" : labelMoyenneGenerale.Text;
                    gfx.DrawString("Moyenne Générale : " + moyenneText, regularFont, XBrushes.Black, new XPoint(page.Width - 150, yPosition));

                    // Sauvegarder le fichier PDF
                    document.Save(filePath);

                    MessageBox.Show("Relevé généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Gérer l'erreur et afficher un message
                    string errorMessage = "Erreur lors de la génération du PDF : " + ex.Message + "\n";
                    errorMessage += "Stack Trace: " + ex.StackTrace;

                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Log l'erreur dans un fichier texte pour un débogage ultérieur
                    File.AppendAllText("error_log.txt", DateTime.Now.ToString() + " - " + errorMessage + Environment.NewLine);
                }
            }

        }





    }



    }


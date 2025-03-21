using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Examen
{
    public partial class Creation_matiere : Form
    {
        public Creation_matiere()
        {
            InitializeComponent();
            refreshTab();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (!VerifierSaisie())
            {
                return; 
            }
            using(var db =new DBcontextApp()) 
            {
                var matiere = new Matieres();
                matiere.nomMatiere=textNom.Text;
                db.Matieres.Add(matiere);
                db.SaveChanges();
                textNom.Text =string.Empty;
                refreshTab();
            }
        }
        public bool VerifierSaisie()
        {
            // Vérifier Nom (lettres + espaces autorisés, obligatoire)
            if (string.IsNullOrWhiteSpace(textNom.Text) || !Regex.IsMatch(textNom.Text, @"^[A-Za-zÀ-ÿ\s-]+$"))
            {
                MessageBox.Show("Le nom ne doit contenir que des lettres et des espaces.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           

            return true; // Tout est valide
        }
        public void refreshTab()
        {
            using (var db = new DBcontextApp())
            {
                dataGridView1.DataSource = db.Matieres.ToList();

            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            textNom.Text = string.Empty;
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Afficher une boîte de dialogue pour confirmer la suppression
                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cet utilisateur ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,  // Deux boutons : Oui ou Non
                    MessageBoxIcon.Question); // Icône de question

                // Si l'utilisateur clique sur Oui
                if (result == DialogResult.Yes)
                {
                    // Obtenir l'index de la ligne sélectionnée
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    // Récupérer l'objet Utilisateur correspondant à la ligne sélectionnée
                    var selectedItem = (Matieres)dataGridView1.Rows[rowIndex].DataBoundItem;

                    using (var db = new DBcontextApp()) // Utilisation d'Entity Framework
                    {
                        // Trouver l'utilisateur à supprimer dans la base de données par son ID
                        var utilisateurToDelete = db.Matieres.FirstOrDefault(u => u.id == selectedItem.id);

                        if (utilisateurToDelete != null)
                        {
                            // Supprimer l'utilisateur de la base de données
                            db.Matieres.Remove(utilisateurToDelete);
                            db.SaveChanges();
                            refreshTab();// Sauvegarder les modifications dans la base de données
                        }
                    }



                    MessageBox.Show("L'utilisateur a été supprimé avec succès !");
                }
                else
                {
                    // Si l'utilisateur clique sur Non, annuler la suppression
                    MessageBox.Show("Suppression annulée.");
                }
            }
            else
            {
                // Si aucune ligne n'est sélectionnée dans le DataGridView
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.");
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Vérifier si une ligne est sélectionnée
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer les données de la ligne sélectionnée
                var selectedRow = dataGridView1.SelectedRows[0];

                // Récupérer l'ID de l'étudiant à partir de la colonne "Id" (ou la colonne correspondante)
                int idCours = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var db = new DBcontextApp())
                {
                    // Récupérer l'étudiant avec l'ID sélectionné
                    var matieres = db.Matieres.FirstOrDefault(item => item.id == idCours);

                    if (matieres != null)
                    {
                        // Remplir le formulaire avec les données de l'étudiant
                        textNom.Text = matieres.nomMatiere;
                        
                    }
                }
            }
        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne est sélectionnée et si les champs sont valides
            if (VerifierSaisie())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Récupérer l'ID de l'étudiant à partir de la ligne sélectionnée
                    int idMatieres = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    using (var db = new DBcontextApp())
                    {
                        // Récupérer l'étudiant avec l'ID sélectionné
                        var matieres = db.Matieres.FirstOrDefault(item => item.id == idMatieres);

                        if (matieres != null)
                        {
                            // Mettre à jour les propriétés de l'étudiant avec les nouvelles valeurs du formulaire
                            matieres.nomMatiere = textNom.Text;
                            // Sauvegarder les modifications dans la base de données
                            db.SaveChanges();
                            MessageBox.Show("Les informations de l'étudiant ont été mises à jour.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Rafraîchir le DataGridView (optionnel si tu veux que les données se mettent à jour immédiatement)
                            refreshTab();
                        }
                        else
                        {
                            MessageBox.Show("Étudiant non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }
    }
}

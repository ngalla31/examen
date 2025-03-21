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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Application_Examen
{
    public partial class Crud_prof : Form
    {
        public Crud_prof()
        {
            InitializeComponent();
            refreshTab();
        }

        private void Crud_prof_Load(object sender, EventArgs e)
        {

        }

        private void buttonAjout_Click(object sender, EventArgs e)
        {
            if (!VerifierSaisie())
            {
                return;  
            }
            using (var db = new DBcontextApp()) 
            {
                var prof = new Professeurs();
                prof.nom=textNom.Text;
                prof.prenom=textPrenom.Text;
                prof.email=textEmail.Text;
                prof.tel=textTel.Text;
                db.Profsseurs.Add(prof);
                db.SaveChanges();
                clear();
                refreshTab();
            }

        }
        public bool VerifierSaisie()
        {
            // Vérifier Nom et Prénom (lettres uniquement, obligatoire)
            if (string.IsNullOrWhiteSpace(textNom.Text) || !Regex.IsMatch(textNom.Text, @"^[A-Za-zÀ-ÿ-]+$"))
            {
                MessageBox.Show("Nom invalide. Seules les lettres sont autorisées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textPrenom.Text) || !Regex.IsMatch(textPrenom.Text, @"^[A-Za-zÀ-ÿ-]+$"))
            {
                MessageBox.Show("Prénom invalide. Seules les lettres sont autorisées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Vérifier l'adresse e-mail
            if (string.IsNullOrWhiteSpace(textEmail.Text) || !Regex.IsMatch(textEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Vérifier le numéro de téléphone (9 chiffres)
            if (!Regex.IsMatch(textTel.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Le numéro de téléphone doit contenir exactement 9 chiffres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true; // Si tout est bon, retourner vrai
        }

        public void clear() 
        {
         textNom.Clear();
         textPrenom.Clear();
         textEmail.Clear();
         textTel.Clear();
        
        }
        public void refreshTab() 
        {
          using(var db=new DBcontextApp()) 
            { 
              dataGridView1.DataSource = db.Profsseurs.ToList();
            }
        
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne est sélectionnée
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné (en supposant que l'ID est dans la colonne "Id")
                int idProf = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Confirmer la suppression
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet étudiant ?", "Confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new DBcontextApp())
                        {
                            // Rechercher l'étudiant dans la base de données
                            var prof = db.Profsseurs.FirstOrDefault(item => item.id == idProf);

                            if (prof != null)
                            {
                                // Supprimer l'étudiant de la base de données
                                db.Profsseurs.Remove(prof);
                                db.SaveChanges(); // Sauvegarder les changements
                            }
                            else
                            {
                                MessageBox.Show("Le prof avec cet ID n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }



                        // Afficher un message de confirmation
                        MessageBox.Show("Prof supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshTab();
                    }
                    catch (Exception ex)
                    {
                        // Gérer les erreurs de suppression (par exemple, si une erreur se produit lors de la suppression)
                        MessageBox.Show("Une erreur est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int idProf = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var db = new DBcontextApp())
                {
                    // Récupérer l'étudiant avec l'ID sélectionné
                    var prof = db.Profsseurs.FirstOrDefault(item => item.id == idProf);

                    if (prof != null)
                    {
                        // Remplir le formulaire avec les données de l'étudiant
                        textNom.Text = prof.nom;
                        textPrenom.Text = prof.prenom;
                        textEmail.Text = prof.email;
                        textTel.Text = prof.tel;
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
                    int idProf = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    using (var db = new DBcontextApp())
                    {
                        // Récupérer l'étudiant avec l'ID sélectionné
                        var prof = db.Profsseurs.FirstOrDefault(item => item.id == idProf);

                        if (prof != null)
                        {
                            // Mettre à jour les propriétés de l'étudiant avec les nouvelles valeurs du formulaire
                            prof.nom = textNom.Text;
                            prof.prenom = textPrenom.Text;
                            prof.email = textEmail.Text;
                            prof.tel = textTel.Text;
                            // Sauvegarder les modifications dans la base de données
                            db.SaveChanges();
                            MessageBox.Show("Les informations du professeur ont été mises à jour.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Rafraîchir le DataGridView (optionnel si tu veux que les données se mettent à jour immédiatement)
                            refreshTab();
                        }
                        else
                        {
                            MessageBox.Show("Prof non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }
    }
}

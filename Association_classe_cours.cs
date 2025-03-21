using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Examen
{
    public partial class Association_classe_cours : Form
    {
        public Association_classe_cours()
        {
            InitializeComponent();
            chargerCours();
            chargerClasse();
            ChargerClasseAvecCours();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void chargerCours() 
        {
            using (var db = new DBcontextApp())
            {
                comboBox1.DataSource = db.Cours.ToList();
                comboBox1.DisplayMember = "nomCours";
                comboBox1.ValueMember = "id";
            }

        }
        public void chargerClasse()
        {
            using (var db = new DBcontextApp())
            {
                comboBox2.DataSource = db.Classe.ToList();
                comboBox2.DisplayMember = "nomClasse";
                comboBox2.ValueMember = "id";
            }

        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {

            if (VerifierSaisie())
            {
                using (var db = new DBcontextApp())
                {
                    var classeCours = new ClasseCours();

                    // Récupérer l'ID du cours sélectionné (pas l'index)
                    classeCours.idClasse = Convert.ToInt32(comboBox1.SelectedValue);

                    // Récupérer l'ID de la matière sélectionnée (pas l'index)
                    classeCours.idCours = Convert.ToInt32(comboBox2.SelectedValue);

                    // Ajouter l'association Cours-Matière à la base de données
                    db.ClasseCours.Add(classeCours);

                    // Sauvegarder les modifications dans la base de données
                    db.SaveChanges();
                    ChargerClasseAvecCours();
                }
            }

        }
        public bool VerifierSaisie()
        {
            // Vérifier que l'utilisateur a sélectionné une classe
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un cours.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Vérifier que l'utilisateur a sélectionné une classe
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une matiere.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si tout est bon, retourner vrai
        }

        public void ChargerClasseAvecCours()
        {
            using (var db = new DBcontextApp())
            {
                var query = from cc in db.ClasseCours // Table de liaison
                            join cl in db.Classe on cc.idClasse equals cl.id
                            join c in db.Cours on cc.idCours equals c.id
                            select new
                            {
                                cc.id,
                                ID_Classe = cl.id,
                                Nom_Classe = cl.nomClasse,
                                ID_Cours = c.id,
                                Nom_Cours = c.nomCours
                            };

                dataGridView1.DataSource = query.ToList(); // Remplir le DataGridView
            }

        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné (en supposant que l'ID est dans la colonne "Id")
                int idClasseCours = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Confirmer la suppression
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet étudiant ?", "Confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new DBcontextApp())
                        {
                            // Rechercher l'étudiant dans la base de données
                            var classeCours = db.ClasseCours.FirstOrDefault(item => item.id == idClasseCours);

                            if (classeCours != null)
                            {
                                // Supprimer l'étudiant de la base de données
                                db.ClasseCours.Remove(classeCours);
                                db.SaveChanges(); // Sauvegarder les changements
                            }
                            else
                            {
                                MessageBox.Show("L'étudiant avec cet ID n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }



                        // Afficher un message de confirmation
                        MessageBox.Show("Étudiant supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerClasseAvecCours();
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
            // Récupérer la ligne sélectionnée dans le DataGridView
            var selectedRow = dataGridView1.Rows[e.RowIndex];

            // Récupérer les valeurs des colonnes de la ligne sélectionnée
            int idClasse = Convert.ToInt32(selectedRow.Cells["ID_Classe"].Value);
            string nomCours = selectedRow.Cells["Nom_Cours"].Value.ToString();
            int idCours = Convert.ToInt32(selectedRow.Cells["ID_Cours"].Value);
            string nomClasse = selectedRow.Cells["Nom_Classe"].Value.ToString();

            // Mettre à jour les ComboBox
            comboBox1.SelectedValue = idCours;    // Sélectionner l'ID du cours dans comboBox1
            comboBox2.SelectedValue = idClasse;  // Sélectionner l'ID de la matière dans comboBox2

            // Facultatif : Mettre à jour les DisplayMember si tu veux afficher les noms
            comboBox1.DisplayMember = "nomCours"; // Afficher le nom du cours
            comboBox1.ValueMember = "id";         // Utiliser l'ID comme valeur pour comboBox1

            comboBox2.DisplayMember = "nomClasse"; // Afficher le nom de la matière
            comboBox2.ValueMember = "id";
        }

        private void buttonModif_Click(object sender, EventArgs e)
        {

            if (!VerifierSaisie())
            {
                return;
            }

            // Vérifier si une ligne est sélectionnée dans le DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer l'ancienne association depuis la ligne sélectionnée
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idCoursAncien = Convert.ToInt32(selectedRow.Cells["ID_Cours"].Value);
            int idClasseAncien = Convert.ToInt32(selectedRow.Cells["ID_Classe"].Value);

            Console.WriteLine($"Ancienne association → idCours: {idCoursAncien}, idClasse: {idClasseAncien}");

            DialogResult confirmation = MessageBox.Show(
                "Voulez-vous vraiment modifier cette association Classe - Cours ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation == DialogResult.Yes)
            {
                using (var db = new DBcontextApp())
                {
                    // Récupérer les nouvelles valeurs sélectionnées
                    if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
                    {
                        MessageBox.Show("Veuillez sélectionner une classe et un cours valides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int idCoursNouveau = Convert.ToInt32(comboBox1.SelectedValue);
                    int idClasseNouveau = Convert.ToInt32(comboBox2.SelectedValue);

                    Console.WriteLine($"Nouvelle association → idCours: {idCoursNouveau}, idClasse: {idClasseNouveau}");

                    // Chercher l'ancienne association dans la base
                    var classeCours = db.ClasseCours.FirstOrDefault(cc => cc.idCours == idCoursAncien && cc.idClasse == idClasseAncien);

                    if (classeCours != null) // Si l'association existe
                    {
                        // Mise à jour avec les nouvelles valeurs
                        classeCours.idCours = idCoursNouveau;
                        classeCours.idClasse = idClasseNouveau;

                        // Sauvegarder les modifications
                        db.SaveChanges();
                        ChargerClasseAvecCours(); // Rafraîchir l'affichage après modification
                        MessageBox.Show("Modification enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Association Classe - Cours non trouvée dans la base de données !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }



}

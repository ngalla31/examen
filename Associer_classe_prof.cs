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
    public partial class Associer_classe_prof : Form
    {
        public Associer_classe_prof()
        {
            InitializeComponent();
            chargerClasses();
            chargerProfs();
            ChargerClasseAvecProfesseurs();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void chargerClasses() 
        {
            using (var db = new DBcontextApp())
            {
                comboBox1.DataSource = db.Classe.ToList();
                comboBox1.DisplayMember = "nomClasse";
                comboBox1.ValueMember = "id";

            }
        }
        public void chargerProfs()
        {
            using (var db = new DBcontextApp())
            {
                comboBox2.DataSource = db.Profsseurs.ToList();
                comboBox2.DisplayMember = "nom";
                comboBox2.ValueMember = "id";

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonAjout_Click(object sender, EventArgs e)
        {


            if (VerifierSaisie())
            {
                using (var db = new DBcontextApp())
                {
                    var classeProf = new ClasseProfs();

                    // Récupérer l'ID du cours sélectionné (pas l'index)
                    classeProf.idClasse = Convert.ToInt32(comboBox1.SelectedValue);

                    // Récupérer l'ID de la matière sélectionnée (pas l'index)
                    classeProf.idProf = Convert.ToInt32(comboBox2.SelectedValue);

                    // Ajouter l'association Cours-Matière à la base de données
                    db.ClasseProfs.Add(classeProf);

                    // Sauvegarder les modifications dans la base de données
                    db.SaveChanges();
                    ChargerClasseAvecProfesseurs();
                }
            }



        }
        public bool VerifierSaisie()
        {
            // Vérifier que l'utilisateur a sélectionné une classe
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une classe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Vérifier que l'utilisateur a sélectionné une classe
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un prof.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si tout est bon, retourner vrai
        }
        public void ChargerClasseAvecProfesseurs()
        {
            using (var db = new DBcontextApp())
            {
                var query = from cp in db.ClasseProfs // Table de liaison
                            join cl in db.Classe on cp.idClasse equals cl.id
                            join p in db.Profsseurs on cp.idProf equals p.id
                            select new
                            {
                                cp.id,
                                ID_Classe = cl.id,
                                Nom_Classe = cl.nomClasse,
                                ID_Professeur = p.id,
                                Nom_Professeur = p.nom
                            };

                dataGridView1.DataSource = query.ToList(); // Remplir le DataGridView
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ChargerClasseAvecProfesseurs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné (en supposant que l'ID est dans la colonne "Id")
                int idClasseProf = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Confirmer la suppression
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette association ?", "Confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new DBcontextApp())
                        {
                            // Rechercher l'étudiant dans la base de données
                            var classeProf = db.ClasseProfs.FirstOrDefault(item => item.id == idClasseProf);

                            if (classeProf != null)
                            {
                                // Supprimer l'étudiant de la base de données
                                db.ClasseProfs.Remove(classeProf);
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
                        ChargerClasseAvecProfesseurs();
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
            int idClasseAncien = Convert.ToInt32(selectedRow.Cells["ID_Classe"].Value);
            int idProfAncien = Convert.ToInt32(selectedRow.Cells["ID_Professeur"].Value);

            Console.WriteLine($"Ancienne association → idCours: {idClasseAncien}, idClasse: {idProfAncien}");

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

                    int idClasseNouveau = Convert.ToInt32(comboBox1.SelectedValue);
                    int idProfNouveau = Convert.ToInt32(comboBox2.SelectedValue);

                    Console.WriteLine($"Nouvelle association → idClasse: {idClasseNouveau}, idProf: {idProfNouveau}");

                    // Chercher l'ancienne association dans la base
                    var classeProf = db.ClasseProfs.FirstOrDefault(cc => cc.idClasse == idClasseAncien && cc.idProf == idClasseAncien);

                    if (classeProf != null) // Si l'association existe
                    {
                        // Mise à jour avec les nouvelles valeurs
                        classeProf.idClasse = idClasseNouveau;
                        classeProf.idClasse = idProfNouveau;

                        // Sauvegarder les modifications
                        db.SaveChanges();
                        ChargerClasseAvecProfesseurs(); // Rafraîchir l'affichage après modification
                        MessageBox.Show("Modification enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Association Classe - Cours non trouvée dans la base de données !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }






        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Récupérer la ligne sélectionnée dans le DataGridView
            var selectedRow = dataGridView1.Rows[e.RowIndex];

            // Récupérer les valeurs des colonnes de la ligne sélectionnée
            int idClasse = Convert.ToInt32(selectedRow.Cells["ID_Classe"].Value);
            string nomProf = selectedRow.Cells["Nom_Professeur"].Value.ToString();
            int idProf = Convert.ToInt32(selectedRow.Cells["ID_Professeur"].Value);
            string nomClasse = selectedRow.Cells["Nom_Classe"].Value.ToString();

            // Mettre à jour les ComboBox
            comboBox1.SelectedValue = idClasse;    // Sélectionner l'ID du cours dans comboBox1
            comboBox2.SelectedValue = idProf;  // Sélectionner l'ID de la matière dans comboBox2

            // Facultatif : Mettre à jour les DisplayMember si tu veux afficher les noms
            comboBox1.DisplayMember = "nomClasse"; // Afficher le nom du cours
            comboBox1.ValueMember = "id";         // Utiliser l'ID comme valeur pour comboBox1

            comboBox2.DisplayMember = "nomProf"; // Afficher le nom de la matière
            comboBox2.ValueMember = "id";
        }
    }
}
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
    public partial class Association_prof_matiere : Form
    {
        public Association_prof_matiere()
        {
            InitializeComponent();
            chargerProfs();
            chargerMatieres();
            ChargerProfsAvecMatieres();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void chargerProfs()
        {
            using (var db = new DBcontextApp())
            {
                comboBox1.DataSource = db.Profsseurs.ToList();
                comboBox1.DisplayMember = "nom";
                comboBox1.ValueMember = "id";

            }
        }
        public void chargerMatieres()
        {
            using (var db = new DBcontextApp())
            {
                comboBox2.DataSource = db.Matieres.ToList();
                comboBox2.DisplayMember = "nomMatiere";
                comboBox2.ValueMember = "id";

            }
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (VerifierSaisie())
            {
                using (var db = new DBcontextApp())
                {
                    var profMatiere = new ProfesseursMatieres();

                    // Récupérer l'ID du cours sélectionné (pas l'index)
                    profMatiere.idProf = Convert.ToInt32(comboBox1.SelectedValue);

                    // Récupérer l'ID de la matière sélectionnée (pas l'index)
                    profMatiere.idMatieres = Convert.ToInt32(comboBox2.SelectedValue);

                    // Ajouter l'association Cours-Matière à la base de données
                    db.professeursMatieres.Add(profMatiere);

                    // Sauvegarder les modifications dans la base de données
                    db.SaveChanges();
                    ChargerProfsAvecMatieres();
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
        public void ChargerProfsAvecMatieres()
        {
            using (var db = new DBcontextApp())
            {
                var query = from pm in db.professeursMatieres // Table de liaison
                            join p in db.Profsseurs on pm.idProf equals p.id
                            join m in db.Matieres on pm.idMatieres equals m.id
                            select new
                            {
                                pm.id,
                                ID_Professeur = p.id,
                                Nom_Professeur = p.nom,
                                ID_Matiere = m.id,
                                Nom_Matiere = m.nomMatiere
                            };

                dataGridView1.DataSource = query.ToList(); // Remplir le DataGridView
            }
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné (en supposant que l'ID est dans la colonne "Id")
                int idProfMatiere = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Confirmer la suppression
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette association ?", "Confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new DBcontextApp())
                        {
                            // Rechercher l'étudiant dans la base de données
                            var profMatiere = db.professeursMatieres.FirstOrDefault(item => item.id == idProfMatiere);

                            if (profMatiere != null)
                            {
                                // Supprimer l'étudiant de la base de données
                                db.professeursMatieres.Remove(profMatiere);
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
                        ChargerProfsAvecMatieres();
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
            int idProf = Convert.ToInt32(selectedRow.Cells["ID_Professeur"].Value);
            string nomProf = selectedRow.Cells["Nom_Professeur"].Value.ToString();
            int idMatiere = Convert.ToInt32(selectedRow.Cells["ID_Matiere"].Value);
            string nomMatiere = selectedRow.Cells["Nom_Matiere"].Value.ToString();

            // Mettre à jour les ComboBox
            comboBox1.SelectedValue = idProf;    // Sélectionner l'ID du cours dans comboBox1
            comboBox2.SelectedValue = idMatiere;  // Sélectionner l'ID de la matière dans comboBox2

            // Facultatif : Mettre à jour les DisplayMember si tu veux afficher les noms
            comboBox1.DisplayMember = "nom"; // Afficher le nom du cours
            comboBox1.ValueMember = "id";         // Utiliser l'ID comme valeur pour comboBox1

            comboBox2.DisplayMember = "nomMatiere"; // Afficher le nom de la matière
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
            int idProfAncien = Convert.ToInt32(selectedRow.Cells["ID_Professeur"].Value);
            int idMatiereAncien = Convert.ToInt32(selectedRow.Cells["ID_Matiere"].Value);

            Console.WriteLine($"Ancienne association → idProf: {idProfAncien}, idMatiere: {idMatiereAncien}");

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

                    int idProfNouveau = Convert.ToInt32(comboBox1.SelectedValue);
                    int idMatiereNouveau = Convert.ToInt32(comboBox2.SelectedValue);

                    Console.WriteLine($"Nouvelle association → idProf: {idProfNouveau}, idMatiere: {idMatiereNouveau}");

                    // Chercher l'ancienne association dans la base
                    var profMatiere = db.professeursMatieres
    .FirstOrDefault(pm => pm.idProf == idProfAncien && pm.idMatieres == idMatiereAncien);


                    if (profMatiere != null) // Si l'association existe
                    {
                        // Mise à jour avec les nouvelles valeurs
                        profMatiere.idProf = idProfNouveau;
                        profMatiere.idMatieres = idMatiereNouveau;

                        // Sauvegarder les modifications
                        db.SaveChanges();
                        ChargerProfsAvecMatieres(); // Rafraîchir l'affichage après modification
                        MessageBox.Show("Modification enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Association Classe - Cours non trouvée dans la base de données !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



        }



    }


    }


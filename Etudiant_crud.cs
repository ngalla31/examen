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
    public partial class Etudiant_crud : Form
    {
        public Etudiant_crud()
        {
            InitializeComponent();
            ChargerClasses();
            refreshTab();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioFemme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonAjout_Click(object sender, EventArgs e)
        {
            if (!VerifierSaisie())
            {
                return; // Si la saisie n'est pas valide, arrête l'exécution de la méthode
            }
            using (var db = new DBcontextApp())
            {
                Etudiants etudiants = new Etudiants();
                etudiants.nom = textNom.Text;
                etudiants.prenom = textPrenom.Text;
                etudiants.dateNaiss = dateTimePicker1.Value;
                if (radioHomme.Checked)
                {
                    etudiants.sexe = "Homme";
                }
                else
                {
                    etudiants.sexe = "Femme";
                }
                etudiants.adresse = textAdresse.Text;
                etudiants.email = textEmail.Text;
                etudiants.tel = textTel.Text;
                etudiants.idClasse = (int)(comboBox1.SelectedValue);
                string matricule = GenererMatricule(textNom.Text, dateTimePicker1.Value);
                etudiants.matricule = matricule;
                db.Etudiants.Add(etudiants);
                db.SaveChanges();
                refresh();
                refreshTab();
            }

        }
        //fonction de controle des saisies
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

            // Vérifier la date (avec DateTimePicker, la date est toujours valide)
            DateTime dateNaissance = dateTimePicker1.Value;
            if (dateNaissance > DateTime.Now) // Empêcher une date future
            {
                MessageBox.Show("La date de naissance ne peut pas être dans le futur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Vérifier si un bouton radio (sexe) est sélectionné
            if (!radioHomme.Checked && !radioFemme.Checked)
            {
                MessageBox.Show("Veuillez sélectionner un sexe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Vérifier l'adresse (obligatoire et au moins 5 caractères)
            if (string.IsNullOrWhiteSpace(textAdresse.Text) || textAdresse.Text.Length < 5)
            {
                MessageBox.Show("Veuillez entrer une adresse valide (au moins 5 caractères).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Vérifier que l'utilisateur a sélectionné une classe
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une classe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si tout est bon, retourner vrai
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChargerClasses();
        }

        public void ChargerClasses()
        {
            using (var db = new DBcontextApp()) // Remplace par ton DbContext
            {
                var classes = db.Classe.ToList(); // Récupère toutes les classes depuis la base
                comboBox1.DataSource = classes;
                comboBox1.DisplayMember = "nomClasse";
                comboBox1.ValueMember = "id";
            }
        }
        public void refresh()
        {
            textNom.Text = string.Empty;
            textPrenom.Text = string.Empty;
            textTel.Text = string.Empty;
            textAdresse.Text = string.Empty;
        }

        public void refreshTab()
        {
            using (var db = new DBcontextApp())
            {
                //dataGridView1.DataSource = db.Etudiants.ToList();
                ChargerEtudiants();

            }

        }
        private string GenererMatricule(string nom, DateTime dateNaissance)
        {
            Random random = new Random();

            // Récupérer les 3 premières lettres du nom (ou "XXX" si trop court)
            string nomPart = nom.Length >= 3 ? nom.Substring(0, 3).ToUpper() : nom.ToUpper().PadRight(3, 'X');

            // Convertir la date de naissance en format ddMMyy
            string datePart = dateNaissance.ToString("ddMMyy");

            // Générer un nombre aléatoire entre 100 et 999
            int randomNum = random.Next(100, 999);

            // Construire le matricule final
            return $"{nomPart}{datePart}{randomNum}";
        }


        private void textAdresse_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void ChargerEtudiants()
        {
            using (var db = new DBcontextApp())
            {
                var listeEtudiants = db.Etudiants
                    .Select(e => new
                    {
                        e.id,
                        e.matricule,
                        e.nom,
                        e.prenom,
                        e.dateNaiss,
                        e.sexe,
                        e.adresse,
                        e.email,
                        e.tel,
                       
                    })
                    .ToList();

                dataGridView1.DataSource = listeEtudiants;
            }
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne est sélectionnée
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de l'étudiant sélectionné (en supposant que l'ID est dans la colonne "Id")
                int idEtudiant = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Confirmer la suppression
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet étudiant ?", "Confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new DBcontextApp())
                        {
                            // Rechercher l'étudiant dans la base de données
                            var etudiant = db.Etudiants.FirstOrDefault(item => item.id == idEtudiant);

                            if (etudiant != null)
                            {
                                // Supprimer l'étudiant de la base de données
                                db.Etudiants.Remove(etudiant);
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
                int idEtudiant = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var db = new DBcontextApp())
                {
                    // Récupérer l'étudiant avec l'ID sélectionné
                    var etudiant = db.Etudiants.FirstOrDefault(item => item.id == idEtudiant);

                    if (etudiant != null)
                    {
                        // Remplir le formulaire avec les données de l'étudiant
                        textNom.Text = etudiant.nom;
                        textPrenom.Text = etudiant.prenom;
                        dateTimePicker1.Value = etudiant.dateNaiss;
                        if (etudiant.sexe == "Homme")
                        {
                            radioHomme.Checked = true;
                        }
                        else
                        {
                            radioFemme.Checked = true;
                        }
                        textAdresse.Text = etudiant.adresse;
                        textEmail.Text = etudiant.email;
                        textTel.Text = etudiant.tel;
                        comboBox1.SelectedValue = etudiant.idClasse;  // Assure-toi que les valeurs correspondent
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
                    int idEtudiant = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    using (var db = new DBcontextApp())
                    {
                        // Récupérer l'étudiant avec l'ID sélectionné
                        var etudiant = db.Etudiants.FirstOrDefault(item => item.id == idEtudiant);

                        if (etudiant != null)
                        {
                            // Mettre à jour les propriétés de l'étudiant avec les nouvelles valeurs du formulaire
                            etudiant.nom = textNom.Text;
                            etudiant.prenom = textPrenom.Text;
                            etudiant.dateNaiss = dateTimePicker1.Value;
                            etudiant.sexe = radioHomme.Checked ? "Homme" : "Femme";
                            etudiant.adresse = textAdresse.Text;
                            etudiant.email = textEmail.Text;
                            etudiant.tel = textTel.Text;
                            etudiant.idClasse = Convert.ToInt32(comboBox1.SelectedValue); // ID de la classe

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

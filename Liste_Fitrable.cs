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
    public partial class Liste_Fitrable : Form
    {
        public Liste_Fitrable()
        {
            InitializeComponent();
            ChargerClasses();
        }

        private void buttonRechercher_Click(object sender, EventArgs e)
        {
            if (!VerifierSaisie())
            {
                return;  
            }
            using (var db = new DBcontextApp())
            {
                int? idClasseRecherche = comboBox1.SelectedIndex == -1 ? (int?)null : (int?)comboBox1.SelectedValue;

                // Recherche avec jointure entre Etudiants et Classe
                var etudiantsRecherche = from etudiant in db.Etudiants
                                         join classe in db.Classe on etudiant.idClasse equals classe.id
                                         where (string.IsNullOrEmpty(textPrenom.Text) || etudiant.prenom.Contains(textPrenom.Text)) &&
                                               (string.IsNullOrEmpty(textNom.Text) || etudiant.nom.Contains(textNom.Text)) &&
                                               (!idClasseRecherche.HasValue || etudiant.idClasse == idClasseRecherche.Value)
                                         select new
                                         {
                                             etudiant.id,
                                             etudiant.prenom,
                                             etudiant.nom,
                                             etudiant.dateNaiss,
                                             etudiant.sexe,
                                             etudiant.adresse,
                                             etudiant.tel,
                                             Classe = classe.nomClasse,  // Affichage du nom de la classe
                                             Matricule = etudiant.matricule
                                         };

                // Exécution de la requête et conversion en liste
                var resultat = etudiantsRecherche.ToList();

                // Si des étudiants sont trouvés
                if (resultat.Any())
                {
                    // Affichage des résultats dans le DataGridView
                    dataGridView1.DataSource = resultat;
                }
                else
                {
                    MessageBox.Show("Aucun étudiant trouvé avec ces critères.", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }




        }
        public bool VerifierSaisie()
        {
            int? idClasseRecherche = comboBox1.SelectedIndex == -1 ? (int?)null : (int?)comboBox1.SelectedValue;

            // Vérifier le prénom : Obligatoire et doit contenir uniquement des lettres
            if (string.IsNullOrWhiteSpace(textPrenom.Text) || !Regex.IsMatch(textPrenom.Text, @"^[A-Za-zÀ-ÿ\-]+$"))
            {
                MessageBox.Show("Le prénom est invalide. Seules les lettres et les traits d'union sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Vérifier le nom : Obligatoire et doit contenir uniquement des lettres
            if (string.IsNullOrWhiteSpace(textNom.Text) || !Regex.IsMatch(textNom.Text, @"^[A-Za-zÀ-ÿ\-]+$"))
            {
                MessageBox.Show("Le nom est invalide. Seules les lettres et les traits d'union sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Vérifier que la classe a été sélectionnée dans le ComboBox
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une classe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Si toutes les vérifications passent, retourner vrai
            return true;
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

    }
}

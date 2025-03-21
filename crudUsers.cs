using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Application_Examen
{
    public partial class crudUsers : Form
    {
        private int selectedId = 0;
        public crudUsers()
        {
            InitializeComponent();
            refreshTab();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //controle des saisies
            if (string.IsNullOrEmpty(textUser.Text))
            {
                MessageBox.Show("Le champ Nom ne peut pas être vide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!textUser.Text.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Le champ Nom doit contenir uniquement des lettres et des espaces.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textPwd.Text))
            {
                MessageBox.Show("Le champ Mot de passe ne peut pas être vide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textPwd.Text.Length < 6) // Exemple : minimum 6 caractères
            {
                MessageBox.Show("Le mot de passe doit comporter au moins 6 caractères.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!textPwd.Text.Any(Char.IsDigit)) // Vérifier la présence d'un chiffre
            {
                MessageBox.Show("Le mot de passe doit contenir au moins un chiffre.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validation pour le champ "Rôle"
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un rôle.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validation pour le champ "Téléphone"
            if (string.IsNullOrEmpty(textTel.Text))
            {
                MessageBox.Show("Le champ Téléphone ne peut pas être vide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsValidPhoneNumber(textTel.Text)) // Vérifier le format du numéro de téléphone
            {
                MessageBox.Show("Veuillez entrer un numéro de téléphone valide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string nom = textUser.Text;
            string pass = textPwd.Text;
            string role = comboBox1.SelectedItem.ToString();
            string tel = textTel.Text;
            using (var db = new DBcontextApp())
            {
                Utilisateurs utilisateurs = new Utilisateurs();
                utilisateurs.nomUser = nom;
                utilisateurs.motPasse = pass;
                utilisateurs.role = role;
                utilisateurs.telephone = tel;
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();
                //Controler les saisies

                //Rafraichir les champs
                refresh();
                refreshTab();
            }

        }

        //fonction de verification des numeros de tel

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Expression régulière pour vérifier les numéros du Sénégal
            string pattern = @"^(?:\+221|0)?(70|75|76|77|78)\d{7}$";

            // Vérifier avec Regex
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        //fonction de verification des numeros de tel
        public void refresh()
        {
            textUser.Text =" ";
            textPwd.Text =" ";
            textTel.Text =" ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        public void refreshTab()
        {
            using (var db = new DBcontextApp())
            {
                dataGridView1.DataSource = db.Utilisateurs.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                    var selectedItem = (Utilisateurs)dataGridView1.Rows[rowIndex].DataBoundItem;

                    using (var db = new DBcontextApp()) // Utilisation d'Entity Framework
                    {
                        // Trouver l'utilisateur à supprimer dans la base de données par son ID
                        var utilisateurToDelete = db.Utilisateurs.FirstOrDefault(u => u.id == selectedItem.id);

                        if (utilisateurToDelete != null)
                        {
                            // Supprimer l'utilisateur de la base de données
                            db.Utilisateurs.Remove(utilisateurToDelete);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupérer la ligne sélectionnée
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                 selectedId = Convert.ToInt32(row.Cells["id"].Value);
                // Remplir les champs du formulaire avec les valeurs de la ligne sélectionnée
                //txtId.Text = row.Cells["Id"].Value.ToString();
                textUser.Text = row.Cells["nomUser"].Value.ToString();
                textPwd.Text = row.Cells["motPasse"].Value.ToString();
                comboBox1.Text = row.Cells["role"].Value.ToString();
                textTel.Text= row.Cells["telephone"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DBcontextApp db = new DBcontextApp()) 
            {
                if (selectedId>0)
                {
                    var user = db.Utilisateurs.Find(selectedId);
                    if (user != null)
                    {
                        // Mettre à jour les valeurs
                        user.nomUser = textUser.Text;
                        user.motPasse = textPwd.Text;
                        user.role = comboBox1.SelectedItem.ToString();
                        user.telephone = textTel.Text;
                        db.SaveChanges(); // Sauvegarder les modifications
                        MessageBox.Show("Modification réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Rafraîchir le DataGridView
                        refreshTab();
                        refresh();
                    }



                }


            }
        }
    }





}

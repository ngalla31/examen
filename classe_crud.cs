using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Application_Examen
{
    public partial class classe_crud : Form
    {
        private int selectedId = 0;
        public classe_crud()
        {
            InitializeComponent();
            refreshTab();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            string nomClasse = textNom.Text.Trim();
            if (string.IsNullOrWhiteSpace(nomClasse) || !Regex.IsMatch(nomClasse, @"^[A-Za-z_][A-Za-z0-9_]*$"))
            {
                MessageBox.Show("Nom de classe invalide !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            using (var db = new DBcontextApp()) 
            {
                Classe classe = new Classe();
                classe.nomClasse = textNom.Text;
                db.Classe.Add(classe);
                db.SaveChanges();
                refreshTab();
            
            }
        }


        public void refreshTab() 
        {
            using (var db = new DBcontextApp()) 
            {
              dataGridView1.DataSource = db.Classe.ToList();
            }
          
        }
        public void refresh()
        {
            textNom.Text = "";

        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void buttonSupp_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0) // Vérifie si une ligne est sélectionnée
            {
                try
                {
                    using (var db = new DBcontextApp())
                    {
                        // Récupère l'ID de la classe sélectionnée
                        int idClasse = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                        // Recherche la classe à supprimer dans la base
                        var classeASupprimer = db.Classe.Find(idClasse);

                        if (classeASupprimer != null)
                        {
                            db.Classe.Remove(classeASupprimer);
                            db.SaveChanges(); // Supprime dans la base

                            MessageBox.Show("Classe supprimée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            refreshTab(); // Rafraîchir le tableau après suppression
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
            // Vérifie si une ligne est bien sélectionnée et évite le clic sur l'en-tête
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                // Remplir les champs du formulaire avec les valeurs de la ligne sélectionnée
                textNom.Text = row.Cells["nomClasse"].Value.ToString();
            }
        }

        private void buttonModif_Click(object sender, EventArgs e)
        {
            using (DBcontextApp db = new DBcontextApp())
     

            {
                if (selectedId > 0)
                {
                    var classe = db.Classe.Find(selectedId);
                    if (classe != null)
                    {
                        // Mettre à jour les valeurs
                        classe.nomClasse = textNom.Text;
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

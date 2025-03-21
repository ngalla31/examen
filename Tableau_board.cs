using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Examen
{
    public partial class Tableau_board : Form
    {
        private Utilisateurs utilisateurConnecte;
        public Tableau_board(Utilisateurs utilisateurConnecte1)
        {
            InitializeComponent();
            this.utilisateurConnecte = utilisateurConnecte1;
            AppliquerRestrictionsMenu();
        }

        private void cRUDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            crudUsers crudEtudiant = new crudUsers();
            this.Hide();
            crudEtudiant.ShowDialog();
            this.Show();
        }

        private void Tableau_board_Load(object sender, EventArgs e)
        {

        }
        public void AppliquerRestrictionsMenu()
        {
            // Tout masquer par défaut
            etudiantsToolStripMenuItem.Visible = false;
            classesToolStripMenuItem.Visible = false;
            coursToolStripMenuItem.Visible = false;
            professeursToolStripMenuItem.Visible = false;
            notesToolStripMenuItem.Visible = false;
           rapportsToolStripMenuItem.Visible = false;
           utilisateursToolStripMenuItem.Visible = false;


            // Afficher les menus selon le rôle
            switch (utilisateurConnecte.role)
            {
                case "Administrateur":
                    etudiantsToolStripMenuItem.Visible = true;
                    classesToolStripMenuItem.Visible = true;
                    coursToolStripMenuItem.Visible = true;
                    professeursToolStripMenuItem.Visible = true;
                    notesToolStripMenuItem.Visible = true;
                    rapportsToolStripMenuItem.Visible = true;
                    utilisateursToolStripMenuItem.Visible = true;
                    break;

                case "Directeur des etudes":
                    etudiantsToolStripMenuItem.Visible = true;
                    classesToolStripMenuItem.Visible = true;
                    coursToolStripMenuItem.Visible = true;
                    professeursToolStripMenuItem.Visible = true;
                    notesToolStripMenuItem.Visible = true;
                    rapportsToolStripMenuItem.Visible = true;
                    utilisateursToolStripMenuItem.Visible = false;
                    break;

                case "Agent":
                    etudiantsToolStripMenuItem.Visible = true;
                    classesToolStripMenuItem.Visible = false;
                    coursToolStripMenuItem.Visible = false;
                    professeursToolStripMenuItem.Visible = false;
                    notesToolStripMenuItem.Visible = true;
                    rapportsToolStripMenuItem.Visible = true;
                    utilisateursToolStripMenuItem.Visible = false;
                    break;
                case "Professeur":
                    etudiantsToolStripMenuItem.Visible = true;
                    classesToolStripMenuItem.Visible = true;
                    coursToolStripMenuItem.Visible = true;
                    professeursToolStripMenuItem.Visible = false;
                    notesToolStripMenuItem.Visible = true;
                    rapportsToolStripMenuItem.Visible = false;
                    utilisateursToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void crudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classe_crud classe_Crud = new classe_crud();
            this.Hide();
            classe_Crud.ShowDialog();
            this.Show();
        }

        private void formulaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Etudiant_crud etudiant_Crud = new Etudiant_crud();
            this.Hide();
            etudiant_Crud.ShowDialog();
            this.Show();
        }

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liste_Fitrable liste_Fitrable = new Liste_Fitrable();
            this.Hide();
            liste_Fitrable.ShowDialog();
            this.Show();
        }

        private void creationCoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creation_Cours creation_Cours = new Creation_Cours();
            this.Hide();
            creation_Cours.ShowDialog();
            this.Show();
        }

        private void associerUnCoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creation_matiere creation_Matiere=new Creation_matiere();
            this.Hide();
            creation_Matiere.ShowDialog();
            this.Show();
        }

        private void aSSOCIERCOURSETMATIERESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Associer_cours_matieres associer_Cours_Matieres=new Associer_cours_matieres();
            this.Hide();
            associer_Cours_Matieres.ShowDialog();
            this.Show();
        }

        private void associerUnProfesseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Association_prof_matiere association_Prof_Matiere = new Association_prof_matiere();
            this.Hide();
            association_Prof_Matiere.ShowDialog(); 
            this.Show();
        }

        private void cRUDProfesseursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Crud_prof crud_Prof=new Crud_prof();
            this.Hide();
            crud_Prof.ShowDialog();
            this.Show();
        }

        private void associerUneClasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Association_classe_cours association_Classe_Cours=new Association_classe_cours();
            this.Hide();
            association_Classe_Cours.ShowDialog();
            this.Show();
        }

        private void associationClasseprofsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Associer_classe_prof associer_Classe_Prof=new Associer_classe_prof();
            this.Hide();
            associer_Classe_Prof.ShowDialog();
            this.Show();
        }

        private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attributionDeNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attribution_de_notes attribution_de_Notes = new Attribution_de_notes();
            attribution_de_Notes.ShowDialog();
            this.Show();
        }

        private void relevesDeNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Releves_de_notes releves_de_notes=new Releves_de_notes();
            this.Hide();
            releves_de_notes.ShowDialog();
            this.Show();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void releveDeNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Releves_de_notes releves_de_notes = new Releves_de_notes();
            this.Hide();
            releves_de_notes.ShowDialog();
            this.Show();
        }

        private void listeDesEtudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liste_des_etudiants_classe liste_Des_Etudiants_Classe=new Liste_des_etudiants_classe();
            this.Hide();
            liste_Des_Etudiants_Classe.ShowDialog();
            this.Show();
        }
    }
}

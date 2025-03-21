using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class Etudiants
    {
        public int id {  get; set; }
        public string matricule { get; set; }
        public string nom { get; set; }
        public string prenom {  get; set; }
        public DateTime dateNaiss { get; set; }
        public string sexe { get; set; }
        public string adresse { get; set; }
        public string tel {  get; set; }
        public string email { get; set; }
        public int idClasse { get; set; }
        //prop de navigation
        public Classe classe { get; set; }
        public string NomComplet => $"{prenom} {nom}";
    }
}

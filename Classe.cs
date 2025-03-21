using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class Classe
    {
        public int id {  get; set; }
        public string nomClasse { get; set; }
        //prop de navigation
        public List<Etudiants> etudiants { get; set; }
        public List<ClasseCours> ClasseCours { get; set; }
        public List<ClasseProfs> ClasseProfs { get; set; }
    }
}

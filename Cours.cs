using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class Cours
    {
        public int id {  get; set; }
        public string nomCours { get; set; }
        public string description { get; set; }
        public List<CoursMatieres> coursMatieres { get; set; }
        public List<ClasseCours> ClasseCours { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class Matieres
    {
        public int id {  get; set; }
        public string nomMatiere { get; set; }
        public List<CoursMatieres> coursMatieres { get; set; }
    }
}

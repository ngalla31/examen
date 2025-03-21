using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class CoursMatieres
    {
        public int id {  get; set; }
        public int idCours {  get; set; }
        public Cours Cours { get; set; }
        public int idMatieres { get; set; }
        public Matieres matieres { get; set; }
    }
}

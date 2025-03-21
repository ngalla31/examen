using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    public class OTP_codes
    {
        public int id {  get; set; }
        public int idUtilisateur { get; set; }
        public string code { get; set; }
        public DateTime dateExpiration { get; set; }
        //prop de navigation
        //public List<Utilisateurs> utilisateurs { get; set; }
        public Utilisateurs utilisateur { get; set; }
    }
}

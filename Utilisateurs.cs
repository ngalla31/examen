using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    public class Utilisateurs
    {
        public int id {  get; set; }
        public string nomUser { get; set; }
        public string motPasse { get; set; }
        public string role { get; set; }
        public string telephone { get; set; }
        //prop de navigation
        //private OTP_codes oTP_Codes { get; set; }   
        public List<OTP_codes> oTP_Codes { get; set; }
    } 
}

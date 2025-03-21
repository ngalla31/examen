using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class DBcontextApp:DbContext
    {
        public DBcontextApp() : base("examenConnect") { }
        public DbSet<Etudiants> Etudiants { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<CoursMatieres> CoursMatieres { get; set; }
        public DbSet<Matieres> Matieres { get; set; }
        public DbSet<Professeurs> Profsseurs { get; set; }
        public DbSet<ProfesseursMatieres> professeursMatieres { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Utilisateurs> Utilisateurs { get;set; }
        public DbSet<OTP_codes> OTP_codes { get; set; }
        public DbSet<ClasseCours> ClasseCours { get; set; }
        public DbSet<ClasseProfs> ClasseProfs { get; set; }
    }
}

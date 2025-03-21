using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Examen
{
    internal class CalculMoyennes
    {
        private readonly DBcontextApp _context;

        public CalculMoyennes(DBcontextApp context)
        {
            _context = context;
        }

        // 🔹 Moyenne des notes par matière pour un étudiant
        public List<NoteMoyenne> CalculerMoyenneParMatiere(int idEtudiant)
        {
            var result = _context.Notes
                .Where(n => n.idEtudiant == idEtudiant)
                .GroupBy(n => n.idMatiere)
                .Select(g => new NoteMoyenne
                {
                    NomMatiere = _context.Matieres
                        .Where(m => m.id == g.Key)
                        .Select(m => m.nomMatiere)
                        .FirstOrDefault(),
                    Moyenne = g.Average(n => n.note)
                })
                .ToList();

            return result;
        }

        // 🔹 Moyenne générale de toutes les matières pour un étudiant
        public double CalculerMoyenneGenerale(int idEtudiant)
        {
            return _context.Notes
                .Where(n => n.idEtudiant == idEtudiant)
                .Average(n => n.note);
        }


    }
}

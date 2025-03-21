using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Application_Examen
{
    internal class OtpServices
    {
        private readonly DBcontextApp _context;

        public OtpServices(DBcontextApp context)
        {
            _context = context;
        }

        // Générer un code OTP et l'enregistrer dans la base de données
        public string GenerateAndStoreOtp(int userId)
        {
            // Génération d'un code OTP aléatoire (6 chiffres)
            Random rand = new Random();
            string otpCode = rand.Next(100000, 999999).ToString();

            // Définir la date d'expiration (par exemple, 10 minutes)
            DateTime expirationDate = DateTime.Now.AddMinutes(10);

            // Enregistrer le code OTP dans la base de données
            var OTP_codes = new OTP_codes()
            {
                idUtilisateur = userId,
                code = otpCode,
                dateExpiration = expirationDate
            };

            _context.OTP_codes.Add(OTP_codes);
            _context.SaveChanges();

            return otpCode; // Retourner le code OTP généré
        }

        // Vérifier le code OTP
        public bool VerifyOtp(int userId, string otpEntered)
        {
            // Rechercher le dernier OTP pour cet utilisateur
            var otp = _context.OTP_codes
                .Where(o => o.idUtilisateur == userId)
                .OrderByDescending(o => o.dateExpiration) // Récupérer le dernier OTP
                .FirstOrDefault();

            // Vérifier si le code OTP est valide
            if (otp != null && otp.code == otpEntered && otp.dateExpiration > DateTime.Now)
            {
                return true; // Code OTP valide
            }

            return false; // Code OTP invalide ou expiré
        }

    }
}

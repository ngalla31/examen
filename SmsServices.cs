using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Application_Examen
{
    internal class SmsServices
    {
        // Méthode pour envoyer un SMS via Twilio
        public static void SendSms(string phoneNumber, string message)
        {
            // Remplacez par vos informations Twilio
            const string accountSid = "AC2bf2e1450c0841f51ab25dc2f70219d8"; // Votre SID de compte Twilio
            const string authToken = "f7ecf43845472bec4e67b50bc0d45f19"; // Votre token d'authentification Twilio
            const string fromPhoneNumber = "+1 903 776 3006"; // Votre numéro Twilio (ou un numéro vérifié)

            // Initialisation de Twilio avec votre SID et Auth Token
            TwilioClient.Init(accountSid, authToken);

            // Création et envoi du message SMS
            var messageSent = MessageResource.Create(
                body: message, // Contenu du message
                from: new PhoneNumber(fromPhoneNumber), // Le numéro qui envoie le SMS
                to: new PhoneNumber(phoneNumber) // Le numéro du destinataire
            );

            // Affichage de la réponse
            Console.WriteLine($"Message envoyé avec SID : {messageSent.Sid}");
        }
    }
}

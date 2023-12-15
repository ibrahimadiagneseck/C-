using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Lab2
    {
        private Dictionary<string, int> numerosClientsParType = new Dictionary<string, int>
        {
            { "versement", 1 },
            { "retrait", 1 },
            { "informations", 1 }
        };

        private string ObtenirNumeroTicket(string typeOperation)
        {
            int numeroClient = numerosClientsParType[typeOperation];
            numerosClientsParType[typeOperation]++;

            string lettreType;
            switch (typeOperation.ToLower())
            {
                case "versement":
                    lettreType = "V";
                    break;
                case "retrait":
                    lettreType = "R";
                    break;
                case "informations":
                    lettreType = "I";
                    break;
                default:
                    lettreType = "U"; // U pour opération inconnue
                    break;
            }

            string numeroTicket = $"{lettreType}-{numeroClient}";
            return numeroTicket;
        }

        public void Executer()
        {
            while (true)
            {
                Console.Write("Quel type d'opération souhaitez-vous effectuer (Versement/Retrait/Informations) ou (q/quitter) ?\n");
                Console.Write("===> ");
                string typeOperation = Console.ReadLine().ToLower();

                if (typeOperation.ToLower() == "q" || typeOperation.ToLower() == "quitter")
                {
                    break;
                }

                if (!numerosClientsParType.ContainsKey(typeOperation))
                {
                    Console.Clear();
                    Console.WriteLine("Opération inconnue. Veuillez choisir parmi Versement, Retrait ou Informations.");
                    continue;
                }

                int clientsEnAttente = numerosClientsParType[typeOperation] - 1;
                string numeroTicket = ObtenirNumeroTicket(typeOperation);

                Console.WriteLine($"Votre numéro est {numeroTicket}, et il y a {clientsEnAttente} personnes qui attendent avant vous.");

                recommence:
                Console.Write("Voulez-vous prendre un autre numéro de ticket ? (Oui/Non) \n");
                Console.Write("===> ");
                string continuer = Console.ReadLine().ToLower();
                
                if (continuer == "non")
                {
                    Console.Clear();
                    Console.WriteLine("Merci de votre visite. Au revoir!");
                    break;
                }

                if (continuer == "oui")
                {
                    Console.Clear();
                    continue;
                }

                if (continuer != "oui" && continuer != "non")
                {
                    Console.Clear();
                    Console.WriteLine("Mauvaise réponse!");
                    goto recommence;
                }
            }
        }
    }
}

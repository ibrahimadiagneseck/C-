using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Distributeur
{
    internal class Lab
    {
        private Dictionary<string, int> numerosClientsParType = new Dictionary<string, int>
        {
            { "versement", 1 },
            { "retrait", 1 },
            { "informations", 1 }
        };

        private const string FilePath = @"C:\Users\ibrah\source\repos\fnumeros.txt"; 

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
            // Charger les numéros existants depuis le fichier, s'il existe
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int number))
                    {
                        numerosClientsParType[parts[0]] = number;
                    }
                }
            }

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

        private void SaveNumbersToFile()
        {
            List<string> lines = new List<string>();
            foreach (var entry in numerosClientsParType)
            {
                lines.Add($"{entry.Key}={entry.Value}");
            }
            File.WriteAllLines(FilePath, lines);
        }
    }
}

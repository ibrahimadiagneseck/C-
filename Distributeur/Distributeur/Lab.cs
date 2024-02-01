using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Distributeur
{
    internal class Lab
    {
        private const string DirectoryPath = @"C:\Temp";
        private const string FileName = "fnumeros.txt";
        private const string FilePath = DirectoryPath + "\\" + FileName;

        private Dictionary<string, int> numerosClientsParType = new Dictionary<string, int>
        {
            { "versement", 1 },
            { "retrait", 1 },
            { "informations", 1 }
        };

        private Dictionary<string, List<string>> clientsInfoParType = new Dictionary<string, List<string>>();

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
            // Réinitialiser le contenu du fichier au lancement du programme
            ResetFileContent();

            // Charger les numéros existants depuis le fichier, s'il existe
            LoadNumbersFromFile();

            bool continuerProgramme = true;

            while (continuerProgramme)
            {
                
                Console.Write("Quel type d'opération souhaitez-vous effectuer (Versement/Retrait/Informations) ou (q/quitter) ?\n");
                Console.Write("===> ");
                string operationType = Console.ReadLine().ToLower();

                switch (operationType)
                {
                    case "q":
                    case "quitter":
                        // Sauvegarder les numéros dans le fichier avant de quitter
                        SaveNumbersToFile();
                        // Rappeler la liste à la fin de l'exécution
                        LoadNumbersFromFile();
                        continuerProgramme = false;
                        break;

                    default:
                        if (!numerosClientsParType.ContainsKey(operationType))
                        {
                            Console.Clear();
                            Console.WriteLine("Opération inconnue. Veuillez choisir parmi Versement, Retrait ou Informations.");
                            continue;
                        }

                        int clientsWaiting = numerosClientsParType[operationType] - 1;

                        bool isValidAccountNumber;

                        Console.Write("Entrez votre numéro de compte (ou tapez 'q' pour quitter): ");
                    accountNumber:
                        string accountNumberInput = Console.ReadLine();

                        if (accountNumberInput.ToLower() == "q")
                        {
                            Console.Clear();
                            break;
                        }

                        if (!int.TryParse(accountNumberInput, out int accountNumber) || accountNumber <= 0)
                        {
                            Console.WriteLine("Veuillez entrer un numéro de compte valide et positif.");
                            goto accountNumber;
                        }

                        // Demander le prénom
                        string firstName;
                        do
                        {
                            Console.Write("Entrez votre prénom (ou tapez 'q' pour quitter): ");
                            firstName = Console.ReadLine();

                            if (firstName.ToLower() == "q")
                            {
                                Console.Clear();
                                // return;
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(firstName) || ContainsDigits(firstName))
                            {
                                Console.WriteLine("Le prénom ne peut pas être vide et ne doit pas contenir de chiffres.");
                            }

                        } while (string.IsNullOrWhiteSpace(firstName) || ContainsDigits(firstName));

                        // Demander le nom
                        string lastName;
                        do
                        {
                            Console.Write("Entrez votre nom (ou tapez 'q' pour quitter): ");
                            lastName = Console.ReadLine();

                            if (lastName.ToLower() == "q")
                            {
                                Console.Clear();
                                // return;
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(lastName) || ContainsDigits(lastName))
                            {
                                Console.WriteLine("Le nom ne peut pas être vide et ne doit pas contenir de chiffres.");
                            }

                        } while (string.IsNullOrWhiteSpace(lastName) || ContainsDigits(lastName));

                        // Obtenir le numéro de ticket
                        string ticketNumber = ObtenirNumeroTicket(operationType);

                        // Enregistrer les informations du client
                        SaveClientInfo(operationType, firstName, lastName, accountNumber.ToString(), ticketNumber);

                        Console.WriteLine($"Bonjour {firstName} {lastName}, votre numéro de compte est {accountNumber}, votre numéro de ticket est {ticketNumber}, et il y a {clientsWaiting} personnes qui attendent avant vous.");

                        // Demander si l'utilisateur veut prendre un autre numéro de ticket
                        bool reessayer = true;

                        while (reessayer)
                        {
                            Console.Write("Voulez-vous prendre un autre numéro de ticket ? (Oui/Non) \n");
                            Console.Write("===> ");
                            string continueResponse = Console.ReadLine().ToLower();

                            switch (continueResponse)
                            {
                                case "non":
                                    Console.Clear();
                                    Console.WriteLine("Merci de votre visite. Au revoir!");
                                    // Sauvegarder les numéros dans le fichier avant de quitter
                                    SaveNumbersToFile();
                                    // Rappeler la liste à la fin de l'exécution
                                    LoadNumbersFromFile();
                                    continuerProgramme = false;
                                    reessayer = false;
                                    break;

                                case "oui":
                                    Console.Clear();
                                    reessayer = false;
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Mauvaise réponse!");
                                    break;
                            }
                        }
                        break;
                }
            }
        }


        /*public void Executer()
        {
            // Réinitialiser le contenu du fichier au lancement du programme
            ResetFileContent();

            // Charger les numéros existants depuis le fichier, s'il existe
            LoadNumbersFromFile();

            bool continuerProgramme = true;

            while (continuerProgramme)
            {
                Console.Clear();
            recommence:
                Console.Write("Quel type d'opération souhaitez-vous effectuer (Versement/Retrait/Informations) ou (q/quitter) ?\n");
                Console.Write("===> ");
                string operationType = Console.ReadLine().ToLower();

                switch (operationType)
                {
                    case "q":
                    case "quitter":
                        // Sauvegarder les numéros dans le fichier avant de quitter
                        SaveNumbersToFile();
                        // Rappeler la liste à la fin de l'exécution
                        LoadNumbersFromFile();
                        continuerProgramme = false;
                        break;

                    default:
                        if (!numerosClientsParType.ContainsKey(operationType))
                        {
                            Console.Clear();
                            Console.WriteLine("Opération inconnue. Veuillez choisir parmi Versement, Retrait ou Informations.");
                            goto recommence;
                        }

                        int clientsWaiting = numerosClientsParType[operationType] - 1;

                        Console.Write("Entrez votre numéro de compte (ou tapez 'q' pour quitter): ");
                    accountNumber:
                        string accountNumberInput = Console.ReadLine();

                        if (accountNumberInput.ToLower() == "q")
                        {
                            break;
                        }

                        if (!int.TryParse(accountNumberInput, out int accountNumber) || accountNumber <= 0)
                        {
                            Console.WriteLine("Veuillez entrer un numéro de compte valide et positif.");
                            goto accountNumber;
                        }

                        Console.Write("Entrez votre prénom (ou tapez 'q' pour quitter): ");
                    firstName:
                        string firstName = Console.ReadLine();

                        if (firstName.ToLower() == "q")
                        {
                            break;
                        }

                        
                        if (string.IsNullOrWhiteSpace(firstName) || ContainsDigits(firstName))
                        {
                            Console.WriteLine("Le prénom ne peut pas être vide.");
                            goto firstName;
                        }

                        Console.Write("Entrez votre nom (ou tapez 'q' pour quitter): ");
                    lastName:
                        string lastName = Console.ReadLine();

                        if (lastName.ToLower() == "q")
                        {
                            break;
                        }

                        
                        if (string.IsNullOrWhiteSpace(lastName) || ContainsDigits(lastName))
                        {
                            Console.WriteLine("Le nom ne peut pas être vide.");
                            goto lastName;
                        }



                        string ticketNumber = ObtenirNumeroTicket(operationType);

                        // Enregistrer les informations du client
                        SaveClientInfo(operationType, firstName, lastName, accountNumber.ToString(), ticketNumber);

                        Console.WriteLine($"Bonjour {firstName} {lastName}, votre numéro de compte est {accountNumber}, votre numéro de ticket est {ticketNumber}, et il y a {clientsWaiting} personnes qui attendent avant vous.");

                        bool reessayer = true;

                        while (reessayer)
                        {
                            Console.Write("Voulez-vous prendre un autre numéro de ticket ? (Oui/Non) \n");
                            Console.Write("===> ");
                            string continueResponse = Console.ReadLine().ToLower();

                            switch (continueResponse)
                            {
                                case "non":
                                    Console.Clear();
                                    Console.WriteLine("Merci de votre visite. Au revoir!");
                                    // Sauvegarder les numéros dans le fichier avant de quitter
                                    SaveNumbersToFile();
                                    // Rappeler la liste à la fin de l'exécution
                                    LoadNumbersFromFile();
                                    continuerProgramme = false;
                                    reessayer = false;
                                    break;

                                case "oui":
                                    Console.Clear();
                                    reessayer = false;
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Mauvaise réponse!");
                                    break;
                            }
                        }
                        break;
                }
            }
        }*/

        private void ResetFileContent()
        {
            try
            {
                // Vérifier si le répertoire existe, sinon le créer
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                // Réinitialiser le contenu du fichier en le vidant
                File.WriteAllText(FilePath, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la réinitialisation du fichier : {ex.Message}");
            }
        }

        private void LoadNumbersFromFile()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = File.OpenText(FilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier : {ex.Message}");
            }
        }

        private void SaveNumbersToFile()
        {
            try
            {
                // Vérifier si le répertoire existe, sinon le créer
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                List<string> lines = new List<string>();
                foreach (var entry in clientsInfoParType)
                {
                    lines.AddRange(entry.Value);
                }
                File.WriteAllLines(FilePath, lines);

                // Vérifier si le fichier a été créé
                if (File.Exists(FilePath))
                {
                    Console.WriteLine($"Les numéros ont été sauvegardés dans le fichier : {FilePath}");
                }
                else
                {
                    Console.WriteLine("Erreur : Le fichier n'a pas été créé correctement.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement dans le fichier : {ex.Message}");
            }
        }

        private void SaveClientInfo(string operationType, string firstName, string lastName, string accountNumber, string ticketNumber)
        {
            try
            {
                // Vérifier si le répertoire existe, sinon le créer
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                // Enregistrer les informations du client dans le fichier
                string clientInfo = $"Type d'opération: {operationType}, Prénom: {firstName}, Nom: {lastName}, Numéro de compte: {accountNumber}, Numéro de ticket: {ticketNumber}";
                if (!clientsInfoParType.ContainsKey(operationType))
                {
                    clientsInfoParType[operationType] = new List<string>();
                }
                clientsInfoParType[operationType].Add(clientInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement des informations du client : {ex.Message}");
            }
        }

        static bool ContainsDigits(string input)
        {
            // Vérifier si la chaîne contient des chiffres
            return Regex.IsMatch(input, @"\d");
        }
    }
}

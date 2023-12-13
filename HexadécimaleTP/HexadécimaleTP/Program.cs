using System;

namespace HexadécimaleTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Entrez un entier : ");
            int entier = Convert.ToInt32(Console.ReadLine());

            string chaineHex = ConvertirEnHexadecimal(entier);

            Console.WriteLine($"La chaîne hexadécimale correspondante est : {chaineHex}");*/

            while (true)
            {
                Console.Write("Entrez un entier positif (ou tapez 'fin' pour terminer) : ");
                string input = Console.ReadLine();

                // Vérifier si l'utilisateur souhaite terminer
                if (input.ToLower() == "fin")
                {
                    break;
                }

                // Convertir l'entrée en entier
                if (int.TryParse(input, out int entier) && entier >= 0)
                {
                    // Appeler la fonction de conversion et afficher le résultat
                    string chaineHex = ConvertirEnHexadecimal(entier);
                    Console.WriteLine($"La chaîne hexadécimale correspondante est : {chaineHex}");
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un entier positif valide.");
                }
            }
        }

        static string ConvertirEnHexadecimal(int nombre)
        {
        
            if (nombre == 0)
            {
                return "0";
            }

     
            string chaineHexadecimale = "";

            // Boucle de conversion
            while (nombre > 0)
            {
                // Obtention du reste après la division par 16
                int reste = nombre % 16;

                // Conversion du reste en caractère hexadécimal
                char chiffreHexadecimal = (reste < 10) ? (char)(reste + '0') : (char)(reste - 10 + 'A');

                // Ajout du chiffre hexadécimal à la chaîne (au début)
                chaineHexadecimale = chiffreHexadecimal + chaineHexadecimale;

                // Division par 16 pour la prochaine itération
                nombre /= 16;
            }

            return chaineHexadecimale;
        }
    }
}
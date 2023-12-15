using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes
{
    internal class Exercice1
    {
        public static void ExecuterExercice1()
        {
            Console.WriteLine("Exercice1: ");

            while (true)
            {
                Console.WriteLine("Entrez trois entiers (ou tapez 'q' pour quitter): ");

                Valeur1:
                Console.Write("Entier 1: ");
                String entier1 = Console.ReadLine();

                if (entier1.ToUpper() == "Q")
                {
                    Console.WriteLine("Exercice1 terminé.");
                    break;
                }

                if (!int.TryParse(entier1, out int nombre1))
                {
                    Console.WriteLine("Veuillez saisir un entier valide.");
                    goto Valeur1;
                }

                

                Valeur2:
                Console.Write("Entier 2: ");
                String entier2 = Console.ReadLine();


                if (entier2.ToUpper() == "Q")
                {
                    Console.WriteLine("Exercice1 terminé.");
                    break;
                }

                if (!int.TryParse(entier2, out int nombre2))
                {
                    Console.WriteLine("Veuillez saisir un entier valide.");
                    goto Valeur2;
                }


                Valeur3:
                Console.Write("Entier 3: ");
                String entier3 = Console.ReadLine();

                if (entier3.ToUpper() == "Q")
                {
                    Console.WriteLine("Exercice1 terminé.");
                    break;
                }

                if (!int.TryParse(entier3, out int nombre3))
                {
                    Console.WriteLine("Veuillez saisir un entier valide.");
                    goto Valeur3;
                }

                

                int resultat = Renvoie_distincts(int.Parse(entier1), int.Parse(entier2), int.Parse(entier3));

                Console.WriteLine(resultat);
                Console.WriteLine();
            }
        }

        public static int Renvoie_distincts(int a, int b, int c)
        {
            int somme = a + b + c;

            if (somme > 15)
            {
                Console.Write("La valeur le plus élévé: ");
                return Math.Max(a, Math.Max(b, c));
            }
            else if (somme < 10)
            {
                Console.Write("La valeur le plus bas: ");
                return Math.Min(a, Math.Min(b, c));
            }
            else
            {
                Console.Write("La valeur intermédiaire: ");
                int intermediaire = somme - Math.Max(a, Math.Max(b, c)) - Math.Min(a, Math.Min(b, c));
                return intermediaire;
            }
        }
    }

}

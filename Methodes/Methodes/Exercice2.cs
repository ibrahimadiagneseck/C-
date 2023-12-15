using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodes
{
    internal class Exercice2
    {

        
        public static void ExecuterExercice2()
        {
            Console.WriteLine("Exercice2: ");

            char choix;

            do
            {
                Console.WriteLine("Choisissez une option :");
                Console.WriteLine("1. Calculer le PGCD avec l'algorithme d'Euclide");
                Console.WriteLine("2. Calculer le PGCD avec l'algorithme de Stein");
                Console.WriteLine("3. Comparer l'algorithme d'Euclide et l'algorithme de Stein");
                Console.WriteLine("q. Quitter");

                choix = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (choix)
                {
                    case '1':
                        CalculerPGCDEuclide();
                        break;

                    case '2':
                        CalculerPGCDStein();
                        break;

                    case '3':
                        ComparerAlgorithme();
                        break;

                    case 'Q':
                        Console.WriteLine("Exercice2 quitté.");
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Option non valide. Veuillez réessayer.");
                        Console.WriteLine();
                        break;
                }

            } while (choix != 'Q');
        }

        public static void CalculerPGCDEuclide()
        {
            while (true)
            {
                Console.WriteLine("Entrez deux entiers positifs (ou tapez 'q' pour quitter): ");

                Console.Write("Entier 1: ");
                string input1 = Console.ReadLine();

                if (input1.ToLower() == "q")
                {
                    break;
                }

                if (!int.TryParse(input1, out int nombre1) || nombre1 < 0)
                {
                    Console.WriteLine("Veuillez saisir un entier positif valide.");
                    continue;
                }

                Console.Write("Entier 2: ");
                string input2 = Console.ReadLine();

                if (input2.ToLower() == "q")
                {
                    break;
                }

                if (!int.TryParse(input2, out int nombre2) || nombre2 < 0)
                {
                    Console.WriteLine("Veuillez saisir un entier positif valide.");
                    continue;
                }    

                int quotient, reste;

                quotient = nombre1 / nombre2;
                reste = nombre1 % nombre2;

                /*Console.WriteLine($"{nombre1} = ({nombre2} * {quotient}) + {reste}");*/

                /*Stopwatch chronometre = new Stopwatch();
                chronometre.Start();*/

                while (nombre2 != 0)
                {
                    nombre1 = nombre2;
                    nombre2 = reste;

                    if (nombre2 != 0)
                    {
                        quotient = nombre1 / nombre2;
                        reste = nombre1 % nombre2;

                        /*Console.WriteLine($"{nombre1} = ({nombre2} * {quotient}) + {reste}");*/
                    }
                }

                /*chronometre.Stop();
                TimeSpan tempsExecution = chronometre.Elapsed;*/

                /*Console.Write($"Temps d'exécution : {tempsExecution.TotalMilliseconds} millisecondes !! et ");*/
                Console.WriteLine($"Le PGCD est {nombre1}");
            }
        }


        public static void CalculerPGCDStein()
        {
            while (true)
            {
                Console.WriteLine("Entrez deux entiers positifs (ou tapez 'q' pour quitter): ");

                Console.Write("Entier 1: ");
                string input1 = Console.ReadLine();

                if (input1.ToLower() == "q")
                {
                    break;
                }

                if (!int.TryParse(input1, out int nombre1) || nombre1 < 0)
                {
                    Console.WriteLine("Veuillez saisir un entier positif valide.");
                    continue;
                }

                Console.Write("Entier 2: ");
                string input2 = Console.ReadLine();

                if (input2.ToLower() == "q")
                {
                    break;
                }

                if (!int.TryParse(input2, out int nombre2) || nombre2 < 0)
                {
                    Console.WriteLine("Veuillez saisir un entier positif valide.");
                    continue;
                }

                /*Stopwatch chronometre = new Stopwatch();
                chronometre.Start();*/

                int pgcd = CalculerPGCDSteinAlgo(nombre1, nombre2);

                /*chronometre.Stop();
                TimeSpan tempsExecution = chronometre.Elapsed;*/

                /*Console.Write($"Temps d'exécution : {tempsExecution.TotalMilliseconds} millisecondes !! et ");*/
                Console.WriteLine($"Le PGCD est {pgcd}");
            }
        }

        public static int CalculerPGCDSteinAlgo(int u, int v)
        {
            int k;

            if (u == 0 || v == 0)
                return u | v;

            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
                u >>= 1;

            do
            {
                while ((v & 1) == 0)
                    v >>= 1;

                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;

            } while (v != 0);

            u <<= k;

            return u;
        }

        public static void ComparerAlgorithme()
        {
            while (true)
            {
                
                Console.WriteLine("Entrez deux entiers positifs (ou tapez 'q' pour quitter): ");

                Console.Write("Entier 1: ");
                string input1 = Console.ReadLine();

                if (input1.ToLower() == "q")
                {
                    break;
                }

                if (!int.TryParse(input1, out int nombre1) || nombre1 < 0)
                {
                    Console.WriteLine("Veuillez saisir un entier positif valide.");
                    continue;
                }

                Console.Write("Entier 2: ");
                string input2 = Console.ReadLine();

                if (input2.ToLower() == "q")
                {
                    break;
                }

                if (!int.TryParse(input2, out int nombre2) || nombre2 < 0)
                {
                    Console.WriteLine("Veuillez saisir un entier positif valide.");
                    continue;
                }


                Stopwatch chronometre1 = new Stopwatch();
                chronometre1.Start();

                Console.WriteLine("Euclide ");
                int quotient, reste;

                quotient = nombre1 / nombre2;
                reste = nombre1 % nombre2;

                /*Console.WriteLine($"{nombre1} = ({nombre2} * {quotient}) + {reste}");*/

                /*Stopwatch chronometre = new Stopwatch();
                chronometre.Start();*/

                while (nombre2 != 0)
                {
                    nombre1 = nombre2;
                    nombre2 = reste;

                    if (nombre2 != 0)
                    {
                        quotient = nombre1 / nombre2;
                        reste = nombre1 % nombre2;

                        /*Console.WriteLine($"{nombre1} = ({nombre2} * {quotient}) + {reste}");*/
                    }
                }

                /*chronometre.Stop();
                TimeSpan tempsExecution = chronometre.Elapsed;*/

                /*Console.Write($"Temps d'exécution : {tempsExecution.TotalMilliseconds} millisecondes !! et ");*/
                Console.WriteLine($"Le PGCD est {nombre1}");

                chronometre1.Stop();
                TimeSpan tempsExecution1 = chronometre1.Elapsed;


                Stopwatch chronometre2 = new Stopwatch();
                chronometre2.Start();

                Console.WriteLine("Stein ");
                int pgcd = CalculerPGCDSteinAlgo(nombre1, nombre2);
                Console.WriteLine($"Le PGCD est {pgcd}");

                chronometre2.Stop();
                TimeSpan tempsExecution2 = chronometre1.Elapsed;



                TimeSpan differenceDeTemps = tempsExecution2 - tempsExecution1;

                Console.WriteLine($"Temps d'exécution pour Euclide : {tempsExecution1}");
                Console.WriteLine($"Temps d'exécution pour Stein : {tempsExecution2}");

                if (differenceDeTemps > TimeSpan.Zero)
                {
                    Console.WriteLine("La méthode Euclide est plus rapide.");
                }
                else if (differenceDeTemps < TimeSpan.Zero)
                {
                    Console.WriteLine("La méthode de Stein est plus rapide.");
                }
                else
                {
                    Console.WriteLine("La méthode de Stein est plus rapide.");
                }

            }
        }
        







    }

    
}

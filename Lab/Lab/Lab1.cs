using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Lab1
    {

        private static List<int> choixFaits = new List<int>();

        public static void ExecuterLab1()
        {
            Console.WriteLine("\nLab1: ");

            bool recommencer = true;

            while (recommencer)
            {

                int borneInferieure = DemanderBornes("Entrez la borne inférieure: ");

                if (borneInferieure == -1)
                {
                    recommencer = false;
                    Console.Clear();
                    Console.WriteLine("Lab1 terminé!\n");
                    break;
                }

                recommencer:
                int borneSuperieure = DemanderBornes("Entrez la borne supérieure: ");

                if (borneSuperieure == -1)
                {
                    recommencer = false;
                    Console.Clear();
                    Console.WriteLine("Lab1 terminé!\n");
                    break;
                }

                if (borneSuperieure < borneInferieure)
                {
                    Console.WriteLine("La borne supérieure doit être plus grand que la borne inférieure : {0}.", borneInferieure);
                    goto recommencer;
                }

                int nombreATrouver = GenererNombreAleatoire(borneInferieure, borneSuperieure);
                /*Console.WriteLine("nombreATrouver " + nombreATrouver);*/

                int nombreDePossibilites = CalculerNombreDePossibilites(borneInferieure, borneSuperieure);
                int nombreDeTentatives = 0;

                

                int choix = ChoisirNombre(borneInferieure, borneSuperieure);

                if (choix == -1)
                {
                    recommencer = false;
                    Console.Clear();
                    Console.WriteLine("Lab1 terminé!\n");
                    break;
                } 
                else if (choix == nombreATrouver)
                {
                    Console.WriteLine("Vous avez gagné!\n");
                }
                else
                {
                    /*Console.WriteLine("Vous avez perdu. Ce n'est pas {0}.", choix);*/
                    Console.WriteLine("Vous avez perdu.\n");
                }

                /*Console.WriteLine("Voulez-vous jouer à nouveau ? (Oui/Non)");
                string jouer = Console.ReadLine();
                recommencer = jouer.Equals("Oui", StringComparison.OrdinalIgnoreCase);

                Console.Clear();*/
            }
        }

        public static int GenererNombreAleatoire(int borneInferieure, int borneSuperieure)
        {
            Random random = new Random();
            return random.Next(borneInferieure, borneSuperieure + 1);
        }


        static int CalculerNombreDePossibilites(int borneInferieure, int borneSuperieure)
        {
            return borneSuperieure - borneInferieure + 1;
        }


        public static int ChoisirNombre(int minimum, int maximum)
        {
            int choix = -1;
            string entree;
            bool check = true;

            Console.WriteLine($"Choisissez un nombre entre {minimum} et {maximum}: ");
            Console.WriteLine("tapez 'q' pour quitter:");

            while (check)
            {
                try
                {
                    
                    entree = Console.ReadLine();

                    if (entree.ToLower() == "q")
                    {
                        check = false;
                        choix = -1;
                        continue;
                    }


                    if (!int.TryParse(entree, out choix) && entree.ToLower() != "q")
                    {
                        throw new FormatException("Erreur de format. Veuillez entrer un nombre valide.");

                    }


                    if ((choix < minimum || choix > maximum) && entree.ToLower() != "q")
                    {
                        throw new ArgumentOutOfRangeException(null, "Le nombre doit être dans la plage spécifiée.");
                    }

                    check = false;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            return choix;
        }





        public static int DemanderBornes(string message)
        {
            int borne = -1;
            bool check = true;

            while (check)
            {
                try
                {
                    Console.WriteLine(message);

                    string choix = Console.ReadLine();

                    if (choix.ToLower() == "q")
                    {
                        check = false;
                        borne = -1;
                        continue;
                        
                    }

                    /*borne = int.Parse(choix);*/

                    if (!int.TryParse(choix, out borne))
                    {
                        throw new FormatException("Erreur de format. Veuillez entrer un entier valide.");
                    }

                    if (borne < 0)
                    {
                        throw new FormatException("Erreur de format. Veuillez entrer un entier positif.");
                    }

                    break;
                   
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("La valeur entrée est trop grande. Veuillez entrer une valeur plus petite.");
                }
            }

            return borne;

        }








    }
}

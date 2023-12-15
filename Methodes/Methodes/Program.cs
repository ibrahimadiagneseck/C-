namespace Methodes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            while (true)
            {
                Console.WriteLine("Choisissez l'exercice à exécuter (1, 2) ou tapez 'q' pour quitter:");
                Console.WriteLine("Tapez 1 pour l'Exercice 1 :  Renvoie_distincts() qui reçoit 3 entiers en paramètres.");
                Console.WriteLine("Tapez 2 pour l'Exercice 2 :  PGCD de deux entiers, algorithme d'Euclide et de Stein.");

                string choixUtilisateur = Console.ReadLine();

                if (choixUtilisateur.ToLower() == "q")
                {
                    Console.WriteLine("Programme terminé.");
                    break;
                }


                switch (choixUtilisateur.ToLower())
                {

                    case "1":
                        Exercice1.ExecuterExercice1();
                        break;

                    case "2":
                        Exercice2.ExecuterExercice2();
                        break;

                    default:
                        Console.WriteLine("Choix invalide. Veuillez saisir 1, 2 ou 'q' pour quitter.");
                        break;
                }
            }


        }


    }
}
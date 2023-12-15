namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Choisissez l'exercice à exécuter (1, 2) ou tapez 'q' pour quitter:");
                Console.WriteLine("Tapez 1 pour l'Exercice Lab1 : Demander \"choisissez le nombre entre x et y\".");
                Console.WriteLine("Tapez 2 pour l'Exercice Lab2 :  Distributeur de tickets.");
                
                Console.Write("===> ");
                string choixUtilisateur = Console.ReadLine();
                

                if (choixUtilisateur.ToLower() == "q")
                {
                    Console.WriteLine("Programme terminé.");
                    break;
                }


                switch (choixUtilisateur.ToLower())
                {

                    case "1":
                        Lab1.ExecuterLab1();
                        break;

                    case "2":
                        Lab2 lab2 = new Lab2();
                        lab2.Executer();
                        break;

                    default:
                        Console.WriteLine("Choix invalide. Veuillez saisir 1, 2 ou 'q' pour quitter.");
                        break;
                }
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection
{
    public class Étudiant
    {
        public string Nom { get; set; }
        public int Age { get; set; }
        public float NoteCC { get; set; }
        public float NoteDevoir { get; set; }

        public Étudiant() { }

        public Étudiant(string nom, int age, float noteCC, float noteDevoir)
        {
            this.Nom = nom;
            this.Age = age;
            this.NoteCC = noteCC;
            this.NoteDevoir = noteDevoir;
        }

        public static List<Étudiant> LireDonneesEtudiants()
        {

            List<Étudiant> collectionEtudiants = new List<Étudiant>();

            Console.WriteLine("Saisissez les données des étudiants. Pour arrêter, entrez 'exit' comme nom.");

            while (true)
            {
                Console.Write("Nom de l'étudiant: ");
                string nom = Console.ReadLine();

                if (nom.ToLower() == "exit")
                {
                    break;
                }

                Console.Write("Age de l'étudiant: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Note CC de l'étudiant: ");
                float noteCC = float.Parse(Console.ReadLine());

                Console.Write("Note devoir de l'étudiant: ");
                float noteDevoir = float.Parse(Console.ReadLine());

                Étudiant nouvelEtudiant = new Étudiant
                {
                    Nom = nom,
                    Age = age,
                    NoteCC = noteCC,
                    NoteDevoir = noteDevoir
                };

                collectionEtudiants.Add(nouvelEtudiant);
            }

            return collectionEtudiants;
        }

        public static void AfficheDonneesEtudiant(Étudiant etudiant)
        {

            Console.WriteLine("Affichage des données de l'étudiant:");

            Console.WriteLine($"Nom: {etudiant.Nom}");
            Console.WriteLine($"Note CC: {etudiant.NoteCC}");
            Console.WriteLine($"Note devoir: {etudiant.NoteDevoir}");

            float moyenne = (etudiant.NoteCC * 0.33f) + (etudiant.NoteDevoir * 0.67f);
            Console.WriteLine($"Moyenne: {moyenne}");
        }

        public static void AfficheDonneesEtudiants(List<Étudiant> collectionEtudiants)
        {

            Console.WriteLine("Affichage des données des étudiants:");

            foreach (Étudiant etudiant in collectionEtudiants)
            {
                AfficheDonneesEtudiant(etudiant);
            }
        }

    }
}

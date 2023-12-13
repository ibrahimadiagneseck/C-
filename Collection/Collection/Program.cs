using System;
using System.Collections;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Étudiant> etudiants = new List<Étudiant>();

            etudiants = Étudiant.LireDonneesEtudiants();

            Étudiant.AfficheDonneesEtudiants(etudiants);*/


            Étudiant etudiant = new Étudiant();

            Console.Write("Nom de l'étudiant: ");
            string nom = Console.ReadLine();

            Console.Write("Age de l'étudiant: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Note CC de l'étudiant: ");
            float noteCC = float.Parse(Console.ReadLine());

            Console.Write("Note devoir de l'étudiant: ");
            float noteDevoir = float.Parse(Console.ReadLine());

            etudiant = new Étudiant
            {
                Nom = nom,
                Age = age,
                NoteCC = noteCC,
                NoteDevoir = noteDevoir
            };

            Étudiant.AfficheDonneesEtudiant(etudiant);


            /*SortedList lstEmployé = new SortedList();
            lstEmployé.Add("Diankha" , new Employé { Nom = "Oumar Diankha", 
                Age= 32 });
            Employé ehod = new Employé()
            {
                Nom = "ElHadji Ousmane Diallo",
                Age = 69
            };
            lstEmployé.Add("Diallo", ehod);
            Employé unEmployé = (Employé)lstEmployé["Diankha"];

            if (unEmployé != null)
            {
                Console.WriteLine($"Nom: {unEmployé.Nom}, Age:" +
                    $" {unEmployé.Age.ToString()}");
            }

            Console.ReadLine();

            foreach (DictionaryEntry employé in lstEmployé)
            {
                Employé autreEmployé = (Employé)employé.Value;
                Console.WriteLine($"Nom: {autreEmployé.Nom}, Age: {autreEmployé.Age.ToString()}");
            }
            Console.ReadLine();*/
        }
    }
}

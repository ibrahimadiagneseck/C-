namespace AccesMembresClasse
{
    internal class Program
    {
        public class Ter
        {
            // Propriétés
            private string nom;
            private int nombrePlaces;
            private bool electrique;

            // Constructeur
            public Ter(string nom, int nombrePlaces)
            {
                this.nom = nom;
                this.nombrePlaces = nombrePlaces;
            }

            // Méthode pour indiquer si le train est électrique
            public void SetElectrique(bool isElectrique)
            {
                electrique = isElectrique;
            }

            // Méthode pour calculer le coût de maintenance
            public decimal CalculerCoutMaintenance()
            {
                // Logique de calcul du coût de maintenance ici
                return 0; // Remplacer par la logique appropriée
            }
        }


        static void Main(string[] args)
        {
            // Créer un objet de type Ter
            Ter unTrain = new Ter("Sénégal émergent", 500);

            // Afficher un champ pour indiquer la source d'énergie.
            unTrain.SetElectrique(true);

            // Appel de la méthode pour calculer le coût de maintenance.
            decimal coutMaintenance = unTrain.CalculerCoutMaintenance();

            // Affichage du résultat
            Console.WriteLine($"Le coût de maintenance du train est de : {coutMaintenance}");
        }
    }
}
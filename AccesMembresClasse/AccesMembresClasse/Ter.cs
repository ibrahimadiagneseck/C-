using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesMembresClasse
{
    public class Ter
    {
        // Creer un objet de type Ter(nom, nombrePlaces);
        Ter unTrain = new Ter("Sénégal émergent", 500);

        // Afficher un champ pour indiquer source d'énergie.
        unTrain.isElectrique() = true;

        // Appel méthode pour calculer coût maintenance.
        decimal coutMaintenance = unTrain.CalculerCoutM;
    }
}

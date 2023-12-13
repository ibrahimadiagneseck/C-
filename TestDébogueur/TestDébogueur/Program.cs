
using System;
using System.Collections.Generic;

namespace TestDébogueur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nom Ordinateur \t\t\t Ram\t\t Type.");
            AfficherListeOrdinateurs();
            Console.ReadKey();
        }
        private static void AfficherListeOrdinateurs()
        {
            var lesOrdinateurs = new List<Ordinateur>
            {
                new Ordinateur() { Nom="Lenovo", RAM=4, TypeOrdinateur=new TypeOrdi('P')},
                new Ordinateur() { Nom="Asus", RAM=16, TypeOrdinateur=new TypeOrdi ('P')},
                new Ordinateur() { Nom="Surface", RAM=32, TypeOrdinateur=new TypeOrdi('P')},
                new Ordinateur() { Nom="HP Pro ", RAM=16, TypeOrdinateur=new TypeOrdi('S')},
                new Ordinateur() { Nom="Sony", RAM=8, TypeOrdinateur=new TypeOrdi('D')},
                new Ordinateur() { Nom="IBM 370", RAM=16, TypeOrdinateur=new TypeOrdi('M')},
                new Ordinateur() { Nom="Iphone", RAM=32, TypeOrdinateur=new TypeOrdi('I')}
            }; // error

            foreach (Ordinateur unOrdinateur in lesOrdinateurs)
            {
                Console.WriteLine(unOrdinateur.Nom + "\t\t\t\t" + unOrdinateur.RAM + ",\t\t" + unOrdinateur.TypeOrdinateur.LeType);
            }
        }
    }

    public class Ordinateur
    {
        public string Nom { get; set; }
        public double RAM { get; set; }
        public TypeOrdi TypeOrdinateur { get; set; }
    }
    public class TypeOrdi
    {
        public TypeOrdi(char type)
        {
            switch (type)
            {
                case 'S':
                    LeType = Type.Serveur;
                    break;
                case 'I':
                    LeType = Type.Mobile;
                    break;
                case 'M':
                    LeType = Type.Mainframe;
                    break;
                case 'D':
                    LeType = Type.Desktop;
                    break;
                case 'P':
                    LeType = Type.Portable;
                    break;
                default:
                    break;
            }
        }

        public object LeType { get; set; }
        private enum Type { Serveur, Mainframe, Desktop, Portable, Mobile }
    }
}

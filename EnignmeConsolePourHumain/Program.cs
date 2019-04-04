using System;
using EnigmeDeLaPorte;

namespace EnignmeConsolePourHumain
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Jeu jeu = new Jeu();
            jeu.init();
            jeu.premierChoixDePorteHumain();
            jeu.afficherPorteVide();
            jeu.secondChoixDePorteHumain();
            jeu.resultat();
            Console.ReadLine();
            */

            
            Jeu jeu = new Jeu();
            int nbIteration = 100000;
            for (int i=0; i < nbIteration; i++)
            {
                
                jeu.init();
                jeu.premierChoixDePorteBot();
                jeu.afficherPorteVide();
                jeu.secondChoixDePorteBot();
                jeu.resultat();
            }

            Console.WriteLine(jeu.getGain());
            //Console.WriteLine("Proba de gain : " + (jeu.getGain()/nbIteration));
            Console.ReadLine();
            
        }
    }
}

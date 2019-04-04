using System;

namespace EnigmeDeLaPorte
{
    public class Jeu
    {
        static Random rnd = new Random();
        private Porte[] portes;
        private int gain;
        private int gainDuTour;
        private int numPorte;

        public Jeu()
        {
            portes = new Porte[3];
            gain = 0;
            gainDuTour = 0;
        }
        
        //etape -1 initialisation
        public void init()
        {
            portes[0] = new Porte();
            portes[1] = new Porte();
            portes[2] = new Porte();
            int numGagnante = rnd.Next(0, 3);
            //setGagnate
            portes[numGagnante].setGagnante();
            gainDuTour = 0;
        }
        //choix de la porte de base
        public void premierChoixDePorteHumain()
        {
            do
            {
                Console.WriteLine("Choisir une porte (1, 2, 3)");
                string str = Console.ReadLine();
                numPorte = int.Parse(str);
            } while (numPorte != 1 && numPorte != 2 && numPorte != 3);
            numPorte--;
            portes[numPorte].setChoix(true);
        }
        public void premierChoixDePorteBot()
        {
            numPorte = rnd.Next(0, 3);
            portes[numPorte].setChoix(true);
            Console.WriteLine("Vous avez choisi la porte " + (numPorte + 1));
        }
        //recherche d'une porte perdante
        public void afficherPorteVide()
        {
            for(int i=0; i< 3; i++)
            {
                if (portes[i].getChoix() == false && portes[i].getGagante() == false)
                {
                    Console.WriteLine("La porte " + (i+1) + " est vide");
                    portes[i].setOpen();
                    i = 4; //comme ca on force a quitter le for
                }
            }
        }
        public void secondChoixDePorteHumain()
        {
            do
            {
                Console.WriteLine("Choisir une porte (1, 2, 3)");
                string str = Console.ReadLine();
                numPorte = int.Parse(str);
            } while (numPorte != 1 && numPorte != 2 && numPorte != 3);
            numPorte--;
            portes[numPorte].setChoix(true);
        }
        public void secondChoixDePorteBot()
        {
            for(int i = 0; i < 3; i++)
            {
                if(portes[i].getOpenned() == false && portes[i].getChoix() == false)
                {
                    numPorte = i;
                }
                else
                {
                    portes[i].setChoix(false);
                }
            }
            portes[numPorte].setChoix(true);
        }
        public void resultat()
        {
            gainDuTour = portes[numPorte].getMontant();
            Console.WriteLine("Vous avez gagné " + gainDuTour + "€");
            gain += gainDuTour;
        }


        public int getGain() { return gain; }

    }

    public class Porte
    {
        private Boolean gagnante;
        private int gain;
        private Boolean choosen;
        private Boolean openned;
        //builder
        public Porte()
        {
            gagnante = false;
            gain = 0;
            choosen = false;
            openned = false;
        }
        
        //getters
        public Boolean getGagante() { return gagnante; }
        public void setGagnante() { gagnante = true; gain = 1; }
        public void setPerdante() { gagnante = false; gain = 0; }
        public int getMontant() { return gain; }
        public void setChoix(Boolean choix) { choosen = choix; }
        public Boolean getChoix() { return choosen; }
        public void setOpen() { openned = true; }
        public Boolean getOpenned() { return openned; }
    }
}

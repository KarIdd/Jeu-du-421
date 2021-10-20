using System;
using System.Collections.Generic;

namespace Jeu_du_421
{
    public class Jeu
    {
        public int NbManches { get; private set; }
        public int NbDes { get; private set; }
        public int NbDesTruques { get; private set; }

        public List<De> listeDe = new List<De>();

        public Jeu()
        {
            NbManches = 5;
            NbDes = 5;
        }

        public Jeu(int NbManches, int NbDes)
        {
            this.NbManches = NbManches;
            this.NbDes = NbDes;
        }

        public Jeu(int NbManches, int NbDes, int NbDesTruques)
        {
            this.NbManches = NbManches;
            this.NbDes = NbDes;
            this.NbDesTruques = NbDesTruques;
        }

        public void Relancer(int position)
        {
            listeDe[position - 1].Lancer();
        }

        public int Score()
        {
            int score = 0;
            foreach (De de in listeDe)
            {
                score += de.Face;
            }
            return score;
        }

        public void Run()
        {
            for (int i = 0; i < NbDes; i++)
            {
                De de = new De();
                listeDe.Add(de);
                
            }

            for (int i = 0; i < NbDesTruques; i++)
            {
                De_truque de = new De_truque();
                listeDe.Add(de);
            }

            for (int i = 0; i < listeDe.Count; i++)
            {
                Relancer(i+1);
            }

            int NbTours = NbManches;
            while (NbTours > 0)
            {
                AfficheDe();
                Console.Write("Selectionner la position des dés que vous souhaitez relancer : ");
                string relance = Console.ReadLine();
                string[] relancede = relance.Split(",");
                foreach (string de in relancede)
                {
                    Relancer(int.Parse(de));
                }
                NbTours -= 1;
            }
            AfficheDe();
            Console.WriteLine("Bravo, vous avez fait {0} points", Score());
        }

        public void AfficheDe()
        {
            foreach (De de in listeDe)
            {
                Console.Write("+---+ ");
            }
            Console.WriteLine();
            foreach (De de in listeDe)
            {
                Console.Write("| {0} | ", de.Face);
            }
            Console.WriteLine();
            foreach (De de in listeDe)
            {
                Console.Write("+---+ ");
            }
            Console.WriteLine();
        }
    }
}

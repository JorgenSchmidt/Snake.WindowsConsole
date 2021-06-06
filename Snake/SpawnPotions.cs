using System;
using System.Collections.Generic;

namespace Snake
{

    public class SpawnPotions
    {
        private int length;
        private int heigth;
        private List<Point> potionsList = new List<Point>();
        private Random rnd = new Random();

        public SpawnPotions (int _length, int _heigth)
        {
            length = _length;
            heigth = _heigth;
        }

        public void decisionToAddPotion()
        {
            int occurrencePotionProbality = rnd.Next(0, 12);
            if (occurrencePotionProbality == 1)
            {
                Point point = potionSpawn();
                potionsList.Add(point);
                point.getPoint();
            }
        }

        public Point potionSpawn()
        {
            rnd = new Random();
            // If param "what to add" == 1 we add DeathPotion (D), which immediately kills the snake
            // If param "what to add" == 2 we add TimeSubstractPotion (T), which substract time from main timer (2 sec)
            // For other values for the "what to add" param we add more time (A) we will add 2 sec
            int whatToAdd = rnd.Next(0, 4);
            if (whatToAdd == 1)
            {
                int x = rnd.Next(2, (length - 1));
                int y = rnd.Next(2 + Wall.getStartPosition(), (heigth - 1));
                return new Point(x, y, 'D', true);
            }
            else if (whatToAdd == 2)
            {
                int x = rnd.Next(2, (length - 1));
                int y = rnd.Next(2 + Wall.getStartPosition(), (heigth - 1));
                return new Point(x, y, 'T', true);
            }
            else
            {
                int x = rnd.Next(2, (length - 1));
                int y = rnd.Next(2 + Wall.getStartPosition(), (heigth - 1));
                return new Point(x, y, 'A', true);
            }
        }

        public List<Point> getPotionsList()
        {
            return potionsList;
        }

    }

}
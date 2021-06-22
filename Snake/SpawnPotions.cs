using System;
using System.Collections.Generic;

namespace Snake
{

    public class SpawnPotions
    {
        private int gameFiledLength;
        private int gameFiledHeigth;
        private List<Point> potionsList = new List<Point>();
        private Random randomObject = new Random();

        public SpawnPotions (int _length, int _heigth)
        {
            gameFiledLength = _length;
            gameFiledHeigth = _heigth;
        }

        public void decisionToAddPotion()
        {
            int occurrencePotionProbality = randomObject.Next(0, 12);
            if (occurrencePotionProbality == 1)
            {
                Point point = potionSpawn();
                potionsList.Add(point);
                point.getPoint();
            }
        }

        public Point potionSpawn()
        {
            randomObject = new Random();
            // If param "what to add" == 1 we add DeathPotion (D), which immediately kills the snake
            // If param "what to add" == 2 we add TimeSubstractPotion (T), which substract time from main timer (2 sec)
            // For other values for the "what to add" param we add more time (A) we will add 2 sec
            int whatToAdd = randomObject.Next(0, 4);
            if (whatToAdd == 1)
            {
                int x = randomObject.Next(2, (gameFiledLength - 1));
                int y = randomObject.Next(2 + Wall.getStartPosition(), (gameFiledHeigth - 1));
                return new Point(x, y, 'D', true);
            }
            else if (whatToAdd == 2)
            {
                int x = randomObject.Next(2, (gameFiledLength - 1));
                int y = randomObject.Next(2 + Wall.getStartPosition(), (gameFiledHeigth - 1));
                return new Point(x, y, 'T', true);
            }
            else
            {
                int x = randomObject.Next(2, (gameFiledLength - 1));
                int y = randomObject.Next(2 + Wall.getStartPosition(), (gameFiledHeigth - 1));
                return new Point(x, y, 'A', true);
            }
        }

        public List<Point> getPotionsList()
        {
            return potionsList;
        }

        public void deactivatingPotion(int _potionNumber)
        {
            potionsList[_potionNumber].pointDeactivate();
        }

    }

}
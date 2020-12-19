using System;
using System.Diagnostics.SymbolStore;
using System.Threading;

namespace Snake {

    class Program {

        private static int height;
        private static int length;
        private static int speed;
        private static int changeSpeedAfterEat;

        static void Main(string[] args) {

            firstMode();

        }

        private static void secondDualMode()
        {

            height = 21;
            length = 75;
            speed = 80;
            changeSpeedAfterEat = 3;


            Wall wall = new Wall(length, height);

            GetInformationPanel.inputTheGameInformation(length, height);

            Point p = new Point(2, 2 + Wall.getStartPosition(), '*');
            Snake s = new Snake(p, 4, Direction.right);
            s.getLine();

            SpawnFood foodspawner = new SpawnFood(length, height + 1 + Wall.getStartPosition(), '$');
            Point food = foodspawner.foodSP();
            food.getPoint();

            while (true)
            {

                if (wall.isHit(s) || s.isHitTail())
                {
                    break;
                }

                if (s.eat(food))
                {
                    food = foodspawner.foodSP();
                    food.getPoint();
                    if (speed > 10) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else
                {
                    s.toDir();
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s.handleKey(key.Key);

                    //Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= height + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }
            }

            GameOver.gameOver(length, height + Wall.getStartPosition());

        }

        private static void firstMode () {

            height = 21;
            length = 75;
            speed = 80;
            changeSpeedAfterEat = 3;


            Wall wall = new Wall(length, height);

            GetInformationPanel.inputTheGameInformation(length, height);

            Point p = new Point(2, 2 + Wall.getStartPosition(), '*');
            Snake s = new Snake(p, 4, Direction.right);
            s.getLine();

            SpawnFood foodspawner = new SpawnFood(length, height + 1 + Wall.getStartPosition(), '$');
            Point food = foodspawner.foodSP();
            food.getPoint();

            while (true)
            {

                if (wall.isHit(s) || s.isHitTail())
                {
                    break;
                }

                if (s.eat(food))
                {
                    food = foodspawner.foodSP();
                    food.getPoint();
                    if (speed > 10) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else
                {
                    s.toDir();
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s.handleKey(key.Key);

                    //Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= height + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }
            }

            GameOver.gameOver(length, height + Wall.getStartPosition());

        }

    } 
} 
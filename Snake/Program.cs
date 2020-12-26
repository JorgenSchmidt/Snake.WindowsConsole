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

            while (true)
            {
                GameMenu.gameMenu();
                Console.Clear();
                switch (GameMenu.getGameMode())
                {

                    case 1: firstMode(); break;
                    case 2: secondMode(); break;
                    default: Console.WriteLine("Error. Introduced a non-existent game mode."); break;

                }
                Console.Clear();
                GameMenu.confirmationOfTheContinuation();
                if (GameMenu.getConfirmation() == 'Y' || GameMenu.getConfirmation() == 'y') { }
                else if (GameMenu.getConfirmation() == 'N' || GameMenu.getConfirmation() == 'n') { break; }
                else break;

                GetInformationPanel.scoreToZero();
                Console.Clear();
            }

        }

        private static void secondMode() {

            height = 27;
            length = 115;
            speed = 90;
            changeSpeedAfterEat = 2;

            Wall wall = new Wall(length, height);

            GetInformationPanel.inputTheGameInformation(length, height);

            Point p1 = new Point(2, 2 + Wall.getStartPosition(), '*');
            Snake s1 = new Snake(p1, 4, Direction.right);
            s1.getLine();
            Point p2 = new Point(length - 2, height - 2 + Wall.getStartPosition(), '#');
            Snake s2 = new Snake(p2, 4, Direction.left);
            s2.getLine();

            SpawnFood foodspawner = new SpawnFood(length, height + 1 + Wall.getStartPosition(), '$');
            Point firstFood = foodspawner.foodSP();
            firstFood.getPoint();
            Point secondFood = foodspawner.foodSP();
            secondFood.getPoint();

            while (true)
            {

                if (wall.isHit(s1) || s1.isHitTail() || wall.isHit(s2) || s2.isHitTail() || s1.IsHit(s2) || s2.IsHit(s1))
                {
                    break;
                }

                //for first snake
                if (s1.eat(firstFood))
                {
                    firstFood.getPoint('*');
                    firstFood = foodspawner.foodSP();
                    firstFood.getPoint();
                    if (speed > 10) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else if (s1.eat(secondFood))
                {
                    secondFood.getPoint('*');
                    secondFood = foodspawner.foodSP();
                    secondFood.getPoint();
                    if (speed > 10) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else
                {
                    s1.toDir();
                }

                //for second snake
                if (s2.eat(firstFood))
                {
                    firstFood.getPoint('#');
                    firstFood = foodspawner.foodSP();
                    firstFood.getPoint();
                    if (speed > 10) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else if (s2.eat(secondFood))
                {
                    secondFood.getPoint('#');
                    secondFood = foodspawner.foodSP();
                    secondFood.getPoint();
                    if (speed > 10) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else
                {
                    s2.toDir();
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s1.handleKeyArrow(key.Key);
                    s2.handleKeyWASD(key.Key);

                    //Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= height + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }

                // RESPAWN BLOCK!
                firstFood.getPoint();
                secondFood.getPoint();

            }

            GameOver.gameOver(length, height + Wall.getStartPosition());

        }

        private static void firstMode () {

            Random rnd = new Random();
            height = 25;
            length = 75;
            speed = 80;
            changeSpeedAfterEat = 3;
            int deltaChangeSpeedAfterEat = 0;


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
                    food.getPoint('*');
                    food = foodspawner.foodSP();
                    food.getPoint();
                    deltaChangeSpeedAfterEat = rnd.Next(0,2);
                    if (speed > 10) { speed -= (changeSpeedAfterEat - deltaChangeSpeedAfterEat); }
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
                    s.handleKeyArrow(key.Key);

                    //Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= height + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }

                // RESPAWN BLOCK!
                food.getPoint();

            }

            GameOver.gameOver(length, height + Wall.getStartPosition());

        }

    } 
} 
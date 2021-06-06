using System;
using System.Collections.Generic;
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
                    case 4: fourthMode(); break;
                    case 5: fifthMode(); break;
                    default: Console.WriteLine("Error. Introduced a non-existent game mode."); break;

                }
                Console.Clear();
                GameMenu.confirmationOfTheContinuation();
                if (GameMenu.getConfirmation() == 'Y' || GameMenu.getConfirmation() == 'y' || GameMenu.getConfirmation() == 'Н' || GameMenu.getConfirmation() == 'н') { }
                else if (GameMenu.getConfirmation() == 'N' || GameMenu.getConfirmation() == 'n') { break; }
                else break;

                GetInformationPanel.resetScoreToZero();
                Console.Clear();
            }

        }

        private static void fifthMode()
        {

            Random rnd = new Random();
            TimeCountDown firstTimer = new TimeCountDown(0, 12);

            height = 27;
            length = 115;
            speed = 90;
            changeSpeedAfterEat = 2;

            Wall wall = new Wall(length, height);

            GetInformationPanel.inputTheGameInformation(length, height);

            Point p1 = new Point(2, 2 + Wall.getStartPosition(), '*');
            TSnake s1 = new TSnake(p1, 4, Direction.right);
            s1.getLine();
            Point p2 = new Point(length - 2, height - 2 + Wall.getStartPosition(), '#');
            TSnake s2 = new TSnake(p2, 4, Direction.left);
            s2.getLine();

            SpawnFood foodspawner = new SpawnFood(length, height + 1 + Wall.getStartPosition(), '$');
            Point firstFood = foodspawner.foodSP();
            firstFood.getPoint();
            Point secondFood = foodspawner.foodSP();
            secondFood.getPoint();

            DateTime beginTime = DateTime.Now;
            DateTime currentTime = new DateTime();

            SpawnPotions potions = new SpawnPotions(length, height);
            TimerCallback whenPotionGeneration = new TimerCallback(x => { potions.decisionToAddPotion(); });
            Timer potionTimer = new Timer(whenPotionGeneration, null, 0, 1000);
            char warnDataLeakBecauseOfPotion;

            while (true)
            {

                currentTime = DateTime.Now;
                Int32 time = Convert.ToInt32((beginTime - currentTime).TotalSeconds);

                if (s1.isHitPotion(potions) || s2.isHitPotion(potions))
                {
                    warnDataLeakBecauseOfPotion = TSnake.getPotionSymbol();
                    if (warnDataLeakBecauseOfPotion == 'D') { break; }
                    else if (warnDataLeakBecauseOfPotion == 'T') { firstTimer.addSeconds(-2); }
                    else if (warnDataLeakBecauseOfPotion == 'A') { firstTimer.addSeconds(2); }
                }

                if (wall.isHit(s1) || wall.isHit(s2) || s1.isHitTail() || s2.isHitTail() || s1.IsHit(s2) || s2.IsHit(s1) || time + firstTimer.getSeconds() <= 0)
                {
                    potionTimer.Dispose();
                    if (time + firstTimer.getSeconds() <= 0)
                    {
                        firstTimer.writeCountDown(65, 2);
                    }
                    break;
                }

                // RESPAWN BLOCK!
                firstFood.getPoint();
                secondFood.getPoint();

                // for first snake
                if (s1.eat(firstFood))
                {
                    firstFood.getPoint('*'); 
                    if (speed > 85)
                    {
                        firstFood = foodspawner.foodSP(50, 10);
                    }
                    else
                    {
                        firstFood = foodspawner.foodSP();
                    }
                    firstFood = foodspawner.foodSP();
                    firstFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                    if (speed < 50) firstTimer.addSeconds(speed / 10);
                    else if (speed < 70 && speed >= 50) firstTimer.addSeconds(speed / 10 - 2);
                    else if (speed < 100 && speed >= 70) firstTimer.addSeconds(speed / 10 - 4);
                    else firstTimer.addSeconds(speed / 10);
                }
                else if (s1.eat(secondFood))
                {
                    secondFood.getPoint('*');
                    if (speed > 85)
                    {
                        secondFood = foodspawner.foodSP(50, 10);
                    }
                    else
                    {
                        secondFood = foodspawner.foodSP();
                    }
                    secondFood = foodspawner.foodSP();
                    secondFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                    if (speed < 50) firstTimer.addSeconds(speed / 10);
                    else if (speed < 70 && speed >= 50) firstTimer.addSeconds(speed / 10 - 2);
                    else if (speed < 100 && speed >= 70) firstTimer.addSeconds(speed / 10 - 4);
                    else firstTimer.addSeconds(speed / 10);
                }
                else
                {
                    s1.toDir();
                }

                // for second snake
                if (s2.eat(firstFood))
                {
                    firstFood.getPoint('#');
                    if (speed > 85)
                    {
                        firstFood = foodspawner.foodSP(10, length, height);
                    }
                    else
                    {
                        firstFood = foodspawner.foodSP();
                    }
                    firstFood = foodspawner.foodSP();
                    firstFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                    if (speed < 50) firstTimer.addSeconds(speed / 10);
                    else if (speed < 70 && speed >= 50) firstTimer.addSeconds(speed / 10 - 2);
                    else if (speed < 100 && speed >= 70) firstTimer.addSeconds(speed / 10 - 4);
                    else firstTimer.addSeconds(speed / 10);
                }
                else if (s2.eat(secondFood))
                {
                    secondFood.getPoint('#');
                    if (speed > 85)
                    {
                        secondFood = foodspawner.foodSP(10, length, height);
                    }
                    else
                    {
                        secondFood = foodspawner.foodSP();
                    }
                    secondFood = foodspawner.foodSP();
                    secondFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                    if (speed < 50) firstTimer.addSeconds(speed / 10);
                    else if (speed < 70 && speed >= 50) firstTimer.addSeconds(speed / 10 - 2);
                    else if (speed < 100 && speed >= 70) firstTimer.addSeconds(speed / 10 - 4);
                    else firstTimer.addSeconds(speed / 10);
                }
                else
                {
                    s2.toDir();
                }

                lock (potionTimer)
                {
                    Thread.Sleep(speed);
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s1.handleKeyArrow(key.Key);
                    s2.handleKeyWASD(key.Key);

                    // Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= height + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }

                // Time block
                firstTimer.writeCountDown(length / 5, 2, Convert.ToInt32(time));

            }

            TSnake.potionSymbolOfTSnakeClassToZero();
            GameOver.gameOver(length, height + Wall.getStartPosition());

        }

        private static void fourthMode()
        {
            Random rnd = new Random();
            TimeCountDown firstTimer = new TimeCountDown(0, 6);

            height = 24;
            length = 75;
            speed = 80;
            changeSpeedAfterEat = 4;

            int deltaChangeSpeedAfterEat = 2;
            int initialSpeed = speed;

            Wall wall = new Wall(length, height);

            GetInformationPanel.inputTheGameInformation(length, height);

            Point p = new Point(2, 2 + Wall.getStartPosition(), '*');
            TSnake s = new TSnake(p, 4, Direction.right);

            s.getLine();

            SpawnFood foodspawner = new SpawnFood(length , height + 1 + Wall.getStartPosition() , '$');
            Point food = foodspawner.foodSP(30, 10);
            food.getPoint();

            DateTime beginTime = DateTime.Now;
            DateTime currentTime = new DateTime();

            SpawnPotions potions = new SpawnPotions(length, height);
            TimerCallback whenPotionGeneration = new TimerCallback(x => { potions.decisionToAddPotion(); });
            Timer potionTimer = new Timer(whenPotionGeneration, null, 0, 1000);
            char warnDataLeakBecauseOfPotion;

            while (true)
            {
                currentTime = DateTime.Now;
                Int32 time = Convert.ToInt32((beginTime - currentTime).TotalSeconds);

                if (s.isHitPotion(potions))
                {
                    warnDataLeakBecauseOfPotion = TSnake.getPotionSymbol();
                    if (warnDataLeakBecauseOfPotion == 'D') { break; }
                    else if (warnDataLeakBecauseOfPotion == 'T') { firstTimer.addSeconds(-2); }
                    else if (warnDataLeakBecauseOfPotion == 'A') { firstTimer.addSeconds( 2); }
                }

                if (s.eat(food))
                {
                    // food logic
                    food.getPoint('*');
                    if (speed > 72)
                    {
                        food = foodspawner.foodSP(30, 10);
                    }
                    else
                    {
                        food = foodspawner.foodSP();
                    }
                    food.getPoint();
                    deltaChangeSpeedAfterEat = rnd.Next(0, 2);
                    if (speed > 25) { speed -= (changeSpeedAfterEat - deltaChangeSpeedAfterEat); }
                    GetInformationPanel.inputTheGameInformation(length, height);

                    // changeTime logic
                    if (speed < 50) firstTimer.addSeconds(speed / 10);
                    else if (speed < 70 && speed >= 50) firstTimer.addSeconds(speed / 10 - 2);
                    else if (speed < 100 && speed >= 70) firstTimer.addSeconds(speed / 10 - 4);
                    else firstTimer.addSeconds(speed / 10);

                }
                else
                {
                    s.toDir();
                }

                // Time block
                firstTimer.writeCountDown(65, 2, Convert.ToInt32(time));

                // RESPAWN BLOCK!
                food.getPoint();

                if (wall.isHit(s) || s.isHitTail() || time + firstTimer.getSeconds() <= 0)
                {
                    potionTimer.Dispose();
                    if (time + firstTimer.getSeconds() <= 0)
                    {
                        firstTimer.writeCountDown(65, 2);
                    }
                    break;
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s.handleKeyArrow(key.Key);
                    for (int i = 0 + Wall.getStartPosition(); i <= height + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }
                }

                lock (potionTimer)
                {
                    Thread.Sleep(speed);
                }

            }

            TSnake.potionSymbolOfTSnakeClassToZero();
            GameOver.gameOver(length, height + Wall.getStartPosition());

        }

        private static void secondMode() {

            height = 27;
            length = 115;
            speed = 90;
            changeSpeedAfterEat = 2;

            Wall wall = new Wall(length, height);

            GetInformationPanel.inputTheGameInformation(length, height);

            Point p1 = new Point(2, 2 + Wall.getStartPosition(), '*');
            TSnake s1 = new TSnake(p1, 4, Direction.right);
            s1.getLine();
            Point p2 = new Point(length - 2, height - 2 + Wall.getStartPosition(), '#');
            TSnake s2 = new TSnake(p2, 4, Direction.left);
            s2.getLine();

            SpawnFood foodspawner = new SpawnFood(length, height + 1 + Wall.getStartPosition(), '$');
            Point firstFood = foodspawner.foodSP();
            firstFood.getPoint();
            Point secondFood = foodspawner.foodSP();
            secondFood.getPoint();

            while (true)
            {

                if (wall.isHit(s1) ||  wall.isHit(s2) || s1.isHitTail() || s2.isHitTail() || s1.IsHit(s2) || s2.IsHit(s1))
                {
                    break;
                }

                // for first snake
                if (s1.eat(firstFood))
                {
                    firstFood.getPoint('*');
                    firstFood = foodspawner.foodSP();
                    firstFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else if (s1.eat(secondFood))
                {
                    secondFood.getPoint('*');
                    secondFood = foodspawner.foodSP();
                    secondFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else
                {
                    s1.toDir();
                }

                // for second snake
                if (s2.eat(firstFood))
                {
                    firstFood.getPoint('#');
                    firstFood = foodspawner.foodSP();
                    firstFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(length, height);
                }
                else if (s2.eat(secondFood))
                {
                    secondFood.getPoint('#');
                    secondFood = foodspawner.foodSP();
                    secondFood.getPoint();
                    if (speed > 40) { speed -= changeSpeedAfterEat; }
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

                    // Осторожно, костыль!!!!!
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
            TSnake s = new TSnake(p, 4, Direction.right);
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
                    if (speed > 25) { speed -= (changeSpeedAfterEat - deltaChangeSpeedAfterEat); }
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

                    // Осторожно, костыль!!!!!
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
using System;
using System.Threading;

namespace Snake {

    class Program {

        private static int gameFiledLength;
        private static int gameFiledHeigth;
        private static int changeSpeedAfterEat;

        // Param gameSpeed named as gameSpeed because affect the game as a whole, not only snakes
        private static int gameSpeed;

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
                GameMenu.confirmContunation();
                if (GameMenu.getConfirmation() == 'Y' || GameMenu.getConfirmation() == 'y' || GameMenu.getConfirmation() == 'Н' || GameMenu.getConfirmation() == 'н') { }
                else if (GameMenu.getConfirmation() == 'N' || GameMenu.getConfirmation() == 'n') { break; }
                else break;

                GetInformationPanel.resetScoreToZero();
                Console.Clear();
            }

        }

        private static void fifthMode()
        {

            Random randomObject = new Random();
            TimeCountDown firstTimer = new TimeCountDown(0, 14);

            gameFiledLength = 115;
            gameFiledHeigth = 27;
            gameSpeed = 90;
            changeSpeedAfterEat = 2;

            Wall wall = new Wall(gameFiledLength, gameFiledHeigth);

            GetInformationPanel.inputTheGameInformation(gameFiledLength);

            // Set coords and snake symbol (*) to begin point for snake of first gamer
            Point beginSnakePoint_1 = new Point(2, 2 + Wall.getStartPosition(), '*');
            // Set initial length and direction after beginPoint
            TSnake firstSnake = new TSnake(beginSnakePoint_1, 4, Direction.right);
            firstSnake.getLine();

            // Set coords and snake symbol (#) to begin point for snake of second gamer
            Point beginSnakePoint_2 = new Point(gameFiledLength - 2, gameFiledHeigth - 2 + Wall.getStartPosition(), '#');
            // Set initial length and direction after beginPoint
            TSnake secondSnake = new TSnake(beginSnakePoint_2, 4, Direction.left);
            secondSnake.getLine();

            SpawnFood foodspawner = new SpawnFood(gameFiledLength, gameFiledHeigth + 1 + Wall.getStartPosition(), '$');
            Point firstFood = foodspawner.spawnFood();
            firstFood.getPoint();
            Point secondFood = foodspawner.spawnFood();
            secondFood.getPoint();

            DateTime beginTime = DateTime.Now;
            DateTime currentTime = new DateTime();

            SpawnPotions potions = new SpawnPotions(gameFiledLength, gameFiledHeigth);
            TimerCallback whenPotionGeneration = new TimerCallback(x => { potions.decisionToAddPotion(); });
            Timer potionTimer = new Timer(whenPotionGeneration, null, 0, 1000);
            char drinkedPotionSymbol = ' ';
            int potionNumberOnPotionList = -1;

            while (true)
            {

                currentTime = DateTime.Now;
                Int32 time = Convert.ToInt32((beginTime - currentTime).TotalSeconds);

                if (firstSnake.isHitPotion(potions, ref drinkedPotionSymbol, ref potionNumberOnPotionList) || secondSnake.isHitPotion(potions, ref drinkedPotionSymbol, ref potionNumberOnPotionList))
                {
                    if (drinkedPotionSymbol == 'D') { break; }
                    else if (drinkedPotionSymbol == 'T') { firstTimer.addSeconds(-2); potions.deactivatingPotion(potionNumberOnPotionList); }
                    else if (drinkedPotionSymbol == 'A') { firstTimer.addSeconds(2); potions.deactivatingPotion(potionNumberOnPotionList); }
                }

                if (wall.isHit(firstSnake) || wall.isHit(secondSnake) || firstSnake.isHitTail() || secondSnake.isHitTail() || firstSnake.IsHit(secondSnake) || secondSnake.IsHit(firstSnake) || time + firstTimer.getSeconds() <= 0)
                {
                    if (time + firstTimer.getSeconds() <= 0)
                    {
                        firstTimer.writeCountDown(gameFiledLength / 5, 2);
                    }
                    break;
                }

                // RESPAWN BLOCK!
                firstFood.getPoint();
                secondFood.getPoint();

                // for first snake
                if (firstSnake.eat(firstFood))
                {
                    firstFood.getPoint('*'); 
                    if (gameSpeed > 85)
                    {
                        firstFood = foodspawner.spawnFood(50, 10);
                    }
                    else
                    {
                        firstFood = foodspawner.spawnFood();
                    }
                    firstFood = foodspawner.spawnFood();
                    firstFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                    if (gameSpeed < 50) firstTimer.addSeconds(gameSpeed / 10 - 1);
                    else if (gameSpeed < 70 && gameSpeed >= 50) firstTimer.addSeconds(gameSpeed / 10 - 3);
                    else if (gameSpeed < 100 && gameSpeed >= 70) firstTimer.addSeconds(gameSpeed / 10 - 5);
                    else firstTimer.addSeconds(gameSpeed / 10);
                }
                else if (firstSnake.eat(secondFood))
                {
                    secondFood.getPoint('*');
                    if (gameSpeed > 85)
                    {
                        secondFood = foodspawner.spawnFood(50, 10);
                    }
                    else
                    {
                        secondFood = foodspawner.spawnFood();
                    }
                    secondFood = foodspawner.spawnFood();
                    secondFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                    if (gameSpeed < 50) firstTimer.addSeconds(gameSpeed / 10 - 1);
                    else if (gameSpeed < 70 && gameSpeed >= 50) firstTimer.addSeconds(gameSpeed / 10 - 3);
                    else if (gameSpeed < 100 && gameSpeed >= 70) firstTimer.addSeconds(gameSpeed / 10 - 5);
                    else firstTimer.addSeconds(gameSpeed / 10);
                }
                else
                {
                    firstSnake.toDirection();
                }

                // for second snake
                if (secondSnake.eat(firstFood))
                {
                    firstFood.getPoint('#');
                    if (gameSpeed > 85)
                    {
                        firstFood = foodspawner.spawnFood(10, gameFiledLength, gameFiledHeigth);
                    }
                    else
                    {
                        firstFood = foodspawner.spawnFood();
                    }
                    firstFood = foodspawner.spawnFood();
                    firstFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                    if (gameSpeed < 50) firstTimer.addSeconds(gameSpeed / 10 - 1);
                    else if (gameSpeed < 70 && gameSpeed >= 50) firstTimer.addSeconds(gameSpeed / 10 - 3);
                    else if (gameSpeed < 100 && gameSpeed >= 70) firstTimer.addSeconds(gameSpeed / 10 - 5);
                    else firstTimer.addSeconds(gameSpeed / 10);
                }
                else if (secondSnake.eat(secondFood))
                {
                    secondFood.getPoint('#');
                    if (gameSpeed > 85)
                    {
                        secondFood = foodspawner.spawnFood(10, gameFiledLength, gameFiledHeigth);
                    }
                    else
                    {
                        secondFood = foodspawner.spawnFood();
                    }
                    secondFood = foodspawner.spawnFood();
                    secondFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                    if (gameSpeed < 50) firstTimer.addSeconds(gameSpeed / 10 - 1);
                    else if (gameSpeed < 70 && gameSpeed >= 50) firstTimer.addSeconds(gameSpeed / 10 - 3);
                    else if (gameSpeed < 100 && gameSpeed >= 70) firstTimer.addSeconds(gameSpeed / 10 - 5);
                    else firstTimer.addSeconds(gameSpeed / 10);
                }
                else
                {
                    secondSnake.toDirection();
                }

                lock (potionTimer)
                {
                    Thread.Sleep(gameSpeed);
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    firstSnake.handleKeyArrow(key.Key);
                    secondSnake.handleKeyWASD(key.Key);

                    // Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= gameFiledHeigth + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }

                // Time block
                firstTimer.writeCountDown(gameFiledLength / 5, 2, Convert.ToInt32(time));

            }

            potionTimer.Dispose();
            GameOver.gameOver(gameFiledLength, gameFiledHeigth + Wall.getStartPosition());

        }

        private static void fourthMode()
        {
            Random randomObject = new Random();
            TimeCountDown firstTimer = new TimeCountDown(0, 6);

            gameFiledHeigth = 24;
            gameFiledLength = 75;
            gameSpeed = 80;
            changeSpeedAfterEat = 4;

            int deltaChangeSpeedAfterEat = 2;
            int initialSpeed = gameSpeed;

            Wall wall = new Wall(gameFiledLength, gameFiledHeigth);

            GetInformationPanel.inputTheGameInformation(gameFiledLength);

            Point beginSnakePoint = new Point(2, 2 + Wall.getStartPosition(), '*');
            TSnake snake = new TSnake(beginSnakePoint, 4, Direction.right);

            snake.getLine();

            SpawnFood foodspawner = new SpawnFood(gameFiledLength , gameFiledHeigth + 1 + Wall.getStartPosition() , '$');
            Point food = foodspawner.spawnFood(30, 10);
            food.getPoint();

            DateTime beginTime = DateTime.Now;
            DateTime currentTime = new DateTime();

            SpawnPotions potions = new SpawnPotions(gameFiledLength, gameFiledHeigth);
            TimerCallback whenPotionGeneration = new TimerCallback(x => { potions.decisionToAddPotion(); });
            Timer potionTimer = new Timer(whenPotionGeneration, null, 0, 1000);
            char potionSymbol=' ';
            int potionNumberOnPotionList = -1;

            while (true)
            {
                currentTime = DateTime.Now;
                Int32 time = Convert.ToInt32((beginTime - currentTime).TotalSeconds);

                if (snake.isHitPotion(potions, ref potionSymbol, ref potionNumberOnPotionList))
                {
                    if (potionSymbol == 'D') { break; }
                    else if (potionSymbol == 'T') { firstTimer.addSeconds(-2); potions.deactivatingPotion(potionNumberOnPotionList); }
                    else if (potionSymbol == 'A') { firstTimer.addSeconds( 2); potions.deactivatingPotion(potionNumberOnPotionList); }
                }

                if (snake.eat(food))
                {
                    // food logic
                    food.getPoint('*');
                    if (gameSpeed > 72)
                    {
                        food = foodspawner.spawnFood(30, 10);
                    }
                    else
                    {
                        food = foodspawner.spawnFood();
                    }
                    food.getPoint();
                    deltaChangeSpeedAfterEat = randomObject.Next(0, 2);
                    if (gameSpeed > 25) { gameSpeed -= (changeSpeedAfterEat - deltaChangeSpeedAfterEat); }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);

                    // changeTime logic
                    if (gameSpeed < 50) firstTimer.addSeconds(gameSpeed / 10);
                    else if (gameSpeed < 70 && gameSpeed >= 50) firstTimer.addSeconds(gameSpeed / 10 - 2);
                    else if (gameSpeed < 100 && gameSpeed >= 70) firstTimer.addSeconds(gameSpeed / 10 - 4);
                    else firstTimer.addSeconds(gameSpeed / 10);

                }
                else
                {
                    snake.toDirection();
                }

                // Time block
                firstTimer.writeCountDown(65, 2, Convert.ToInt32(time));

                // RESPAWN BLOCK!
                food.getPoint();

                if (wall.isHit(snake) || snake.isHitTail() || time + firstTimer.getSeconds() <= 0)
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
                    snake.handleKeyArrow(key.Key);
                    for (int i = 0 + Wall.getStartPosition(); i <= gameFiledHeigth + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }
                }

                lock (potionTimer)
                {
                    Thread.Sleep(gameSpeed);
                }

            }

            potionTimer.Dispose();
            GameOver.gameOver(gameFiledLength, gameFiledHeigth + Wall.getStartPosition());

        }

        private static void secondMode() {

            gameFiledHeigth = 27;
            gameFiledLength = 115;
            gameSpeed = 90;
            changeSpeedAfterEat = 2;

            Wall wall = new Wall(gameFiledLength, gameFiledHeigth);

            GetInformationPanel.inputTheGameInformation(gameFiledLength);

            Point beginSnakePoint_1 = new Point(2, 2 + Wall.getStartPosition(), '*');
            TSnake firstSnake = new TSnake(beginSnakePoint_1, 4, Direction.right);
            firstSnake.getLine();
            Point beginSnakePoint_2 = new Point(gameFiledLength - 2, gameFiledHeigth - 2 + Wall.getStartPosition(), '#');
            TSnake secondSnake = new TSnake(beginSnakePoint_2, 4, Direction.left);
            secondSnake.getLine();

            SpawnFood foodspawner = new SpawnFood(gameFiledLength, gameFiledHeigth + 1 + Wall.getStartPosition(), '$');
            Point firstFood = foodspawner.spawnFood();
            firstFood.getPoint();
            Point secondFood = foodspawner.spawnFood();
            secondFood.getPoint();

            while (true)
            {

                if (wall.isHit(firstSnake) ||  wall.isHit(secondSnake) || firstSnake.isHitTail() || secondSnake.isHitTail() || firstSnake.IsHit(secondSnake) || secondSnake.IsHit(firstSnake))
                {
                    break;
                }

                // for first snake
                if (firstSnake.eat(firstFood))
                {
                    firstFood.getPoint('*');
                    firstFood = foodspawner.spawnFood();
                    firstFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                }
                else if (firstSnake.eat(secondFood))
                {
                    secondFood.getPoint('*');
                    secondFood = foodspawner.spawnFood();
                    secondFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                }
                else
                {
                    firstSnake.toDirection();
                }

                // for second snake
                if (secondSnake.eat(firstFood))
                {
                    firstFood.getPoint('#');
                    firstFood = foodspawner.spawnFood();
                    firstFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                }
                else if (secondSnake.eat(secondFood))
                {
                    secondFood.getPoint('#');
                    secondFood = foodspawner.spawnFood();
                    secondFood.getPoint();
                    if (gameSpeed > 40) { gameSpeed -= changeSpeedAfterEat; }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                }
                else
                {
                    secondSnake.toDirection();
                }

                Thread.Sleep(gameSpeed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    firstSnake.handleKeyArrow(key.Key);
                    secondSnake.handleKeyWASD(key.Key);

                    // Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= gameFiledHeigth + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }

                // RESPAWN BLOCK!
                firstFood.getPoint();
                secondFood.getPoint();

            }

            GameOver.gameOver(gameFiledLength, gameFiledHeigth + Wall.getStartPosition());

        }
        
        private static void firstMode () {

            Random randomObject = new Random();
            gameFiledHeigth = 25;
            gameFiledLength = 75;
            gameSpeed = 80;
            changeSpeedAfterEat = 3;

            //      I left param "deltaChangeSpeedAfterEat" as it is therefore
            //      it was necessary to preserve the opportunity to copy/paste and configurate this method
            int deltaChangeSpeedAfterEat = 0;

            Wall wall = new Wall(gameFiledLength, gameFiledHeigth);

            GetInformationPanel.inputTheGameInformation(gameFiledLength);

            Point beginSnakePoint = new Point(2, 2 + Wall.getStartPosition(), '*');
            TSnake snake = new TSnake(beginSnakePoint, 4, Direction.right);
            snake.getLine();

            SpawnFood foodspawner = new SpawnFood(gameFiledLength, gameFiledHeigth + 1 + Wall.getStartPosition(), '$');
            Point food = foodspawner.spawnFood();
            food.getPoint();

            while (true)
            {
             
                if (wall.isHit(snake) || snake.isHitTail())
                {
                    break;
                }

                if (snake.eat(food))
                {
                    food.getPoint('*');
                    food = foodspawner.spawnFood();
                    food.getPoint();
                    deltaChangeSpeedAfterEat = randomObject.Next(0,2);
                    if (gameSpeed > 25) { gameSpeed -= (changeSpeedAfterEat - deltaChangeSpeedAfterEat); }
                    GetInformationPanel.inputTheGameInformation(gameFiledLength);
                }
                else
                {
                    snake.toDirection();
                }


                Thread.Sleep(gameSpeed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.handleKeyArrow(key.Key);

                    // Осторожно, костыль!!!!!
                    for (int i = 0 + Wall.getStartPosition(); i <= gameFiledHeigth + Wall.getStartPosition(); i++)
                    {
                        Point.drawTheNotIdentificatedPoint(0, i, '+');
                    }

                }

                // RESPAWN BLOCK!
                food.getPoint();

            }

            GameOver.gameOver(gameFiledLength, gameFiledHeigth + Wall.getStartPosition());

        }

    } 
} 
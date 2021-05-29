using System;

namespace Snake {

    class GameMenu {

        private static int gameMode;
        private static char confirmation;

        public static void gameMenu() {

            Console.WriteLine("Game have a 3 modes:" + "\n");
            Console.WriteLine("1. Single Mode.");
            Console.WriteLine("2. Command Mode.");
            Console.WriteLine("3. Server Command Mode.");
            Console.WriteLine("In the Single Mode you just control one snake.");
            Console.WriteLine("In the Command Mode you with your camrad control two snakes, everyone controls only one snake.");
            Console.WriteLine("The main task is to score the highest number of points for two,");
            Console.WriteLine("And not to crash into each other, into yourself, or into the wall.");
            Console.WriteLine("If at least one makes a mistake , the game ends.");
            Console.WriteLine("In second mode you and your camrad will control snakes on one computer (arrows (1) - WASD (2)),");
            Console.WriteLine("In the third - game from the Sevrer (arrows). \n\n");
            Console.WriteLine("Are you ready??? \n\n");
            Console.Write("Choise the game mode: ");
            gameMode = Convert.ToInt32(Console.ReadLine());
        }

        public static int getGameMode()
        {
            return gameMode;
        }

        public static void confirmationOfTheContinuation()
        {
            Console.WriteLine("Retry (Y) or no (N)?");

            confirmation = Convert.ToChar(Console.ReadLine());
        }

        public static char getConfirmation()
        {
            return confirmation;
        }

    }
}

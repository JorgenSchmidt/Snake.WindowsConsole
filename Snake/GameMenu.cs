using System;

namespace Snake {

    class GameMenu {

        private static int choiseGameMode;
        private static char confirmation;

        // Main game menu
        public static void gameMenu() {

            Console.WriteLine("Game have a 3 modes:" + "\n");
            Console.WriteLine("1. Single Mode.");
            Console.WriteLine("2. Command Mode.");
            Console.WriteLine("3. Server Command Mode. (In dev)" );
            Console.WriteLine("4. Single Mode With Time (original snake) and other.");
            Console.WriteLine("5. Command Mode With Time (original snake) and other.");
            Console.WriteLine("6. Competitive Mode. (In dev)");
            Console.WriteLine("\n");
            Console.WriteLine("In the Single Mode you just control one snake.");
            Console.WriteLine("In the Command Mode you with your camrad control two snakes, everyone controls only one snake.");
            Console.WriteLine("The main task is to score the highest number of points for two,");
            Console.WriteLine("And not to crash into each other, into yourself, or into the wall.");
            Console.WriteLine("If at least one makes a mistake , the game ends.");
            Console.WriteLine("In second mode you and your camrad will control snakes on one computer (arrows (1) - WASD (2)),");
            Console.WriteLine("In the third - game from the Sevrer (arrows).");
            Console.WriteLine("\n4-th and 5-th gamemodes have a countdown timer and potions: ");
            Console.WriteLine("(A) - adds 2 sec, (T) - deprives 2 sec, (D) - immediatelly kills a snakes");
            Console.WriteLine("\n\nAre you ready??? \n\n");
            Console.Write("Choise the game mode: ");
            try
            {
                choiseGameMode = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                choiseGameMode = 4;
            }
        }

        // For return choised game mode (using in Programm for launch target game mode)
        // Incorrected input calls fourth game mode
        public static int getGameMode()
        {
            return choiseGameMode;
        }

        // For confirm the contunation
        // Incorrected input will continue game menu cycle
        public static void confirmContunation()
        {
            Console.WriteLine("Retry (Y) or no (N)?");

            try
            {
                confirmation = Convert.ToChar(Console.ReadLine());
            }
            catch
            {
                confirmation = 'y';
            }
        }

        // Lets give user confirmation
        public static char getConfirmation()
        {
            return confirmation;
        }

    }
}

using System;

namespace Snake {

    class GameMenu {

        private static int choiseGameMode;
        private static char confirmation;

        // Main game menu
        public static void gameMenu() {

            Console.WriteLine("Game have a 3 modes:" + "\n");
            Console.WriteLine("1. Single Mode.");
            Console.WriteLine("2. Team Mode.");
            Console.WriteLine("3. Single Mode With Time (original snake) and other.");
            Console.WriteLine("4. Team Mode With Time (original snake) and other.");
            Console.WriteLine("5. Competitive Mode. (In dev)");
            Console.WriteLine("6. Server Command Mode. (In dev)");
            Console.WriteLine("\n");
            Console.WriteLine("In the Single Mode you will control one snake.");
            Console.WriteLine("In Team mode, you and your friend will control two snakes, each controls only one snake");
            Console.WriteLine("The main task is to score the highest number of points for two,");
            Console.WriteLine("and not to crash into each other, into yourself, or into the wall.");
            Console.WriteLine("If at least one makes a mistake , the game ends.");
            Console.WriteLine("In second mode you and your camrad will control snakes on one computer (arrows (1) - WASD (2)),");
            Console.WriteLine("\n3-rd and 4-th gamemodes have a countdown timer and potions: ");
            Console.WriteLine("(A) - will adds 2 sec, (T) - will deprives 2 sec, (D) - will immediatelly kills a snakes");
            Console.WriteLine("\n\nAre you ready??? \n\n");
            Console.Write("Choise the game mode: ");
            try
            {
                choiseGameMode = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                choiseGameMode = 3;
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

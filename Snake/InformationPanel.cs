using System;

namespace Snake {

    class InformationPanel {

        private static int score = -1;

        public static void changeInf() {

            score += 1;

        }

        public static void resetScoreToZero()
        {
            score = -1;
        }

        public static void inputTheGameInformation (int _lengthOfField) {

            changeInf();
            Console.SetCursorPosition(_lengthOfField / 2 - 7, 1);
            Console.Write("Your score: " + score + "  ");

        }

    }

}

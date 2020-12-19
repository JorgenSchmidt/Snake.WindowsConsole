using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {

    class GetInformationPanel {

        private static int score;

        public static void changeInf() {

            score += 1;

        }

        public static void inputTheGameInformation (int _lengthOfField, int _s) {

            changeInf();
            Console.SetCursorPosition(_lengthOfField / 2 - 7, 1);
            Console.Write("Your score: " + score);

        }

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {

    class GetInformationPanel {

        private static int score;

        public static void changeInf() {

            score += 1;

        }

        public static void inputTheGameInformation (int _lengthOfField, int heightOfFiled) {

            changeInf();
            Console.SetCursorPosition(_lengthOfField + 2, heightOfFiled / 2);
            Console.Write("Your score: " + score);

        }

    }

}

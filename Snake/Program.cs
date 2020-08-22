using System;

namespace Snake {
    class Program {
        static void Main(string[] args) {

            int x1 = 7;
            int y1 = 8;
            char sym1 = '#';
            setSymbol(x1,y1,sym1);

            Console.ReadLine();

            int x2 = 3;
            int y2 = 4;
            char sym2 = '*';
            setSymbol(x2,y2,sym2);

            Console.ReadLine();
        }

        static void setSymbol(int x, int y, char sym) {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
        }

    }
}
using System;
using System.Diagnostics.SymbolStore;

namespace Snake {
    class Program {
        static void Main(string[] args) {


            Point p1 = new Point(5, 5, '*');
            p1.getPoint();
            Console.ReadLine();

            Point p2 = new Point(3, 3, '#');
            p2.getPoint();
            Console.ReadLine();

            SnakeMoveH line = new SnakeMoveH(5, 9, 2, '%');
            line.getLine();
            Console.ReadLine();

            SnakeMoveV line2 = new SnakeMoveV(6, 2, 5, '$');
            line2.getLine();
            Console.ReadLine();
        }

    }
}
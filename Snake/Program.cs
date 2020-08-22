using System;
using System.Diagnostics.SymbolStore;

namespace Snake {
    class Program {
        static void Main(string[] args) {

            Point p1 = new Point(5,5,'*');
            p1.getPoint();

            Console.ReadLine();

            Point p2 = new Point(3,3,'#');
            p1.getPoint();

            Console.ReadLine();
        }

    }
}
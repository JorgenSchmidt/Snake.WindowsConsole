using System;
using System.Diagnostics.SymbolStore;
using System.Threading;

namespace Snake {
    class Program {

        private static int height;
        private static int length;
        private static int speed;

        static void Main(string[] args) {

            height = 28;
            length = 100;
            speed = 100;

            Horisontal hLine1 = new Horisontal(0, length, 0, '*');
            hLine1.getLine();
            Horisontal hLine2 = new Horisontal(0, length, height, '*');
            hLine2.getLine();
            Vertical vLine1 = new Vertical(0, 0, height, '*');
            vLine1.getLine();
            Vertical vLine2 = new Vertical(length, 0, height, '*');
            vLine2.getLine();

            Point p = new Point(2, 2, '*');
            Snake s = new Snake(p, 4, Direction.right);
            s.getLine();

            while (true) {

                
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s.handleKey(key.Key);
                }

                Thread.Sleep(speed);
                s.toDir();
            }

        }
    } 
} 
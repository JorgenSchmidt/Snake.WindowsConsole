using System;
using System.Diagnostics.SymbolStore;
using System.Threading;

namespace Snake {
    class Program {

        private static int height;
        private static int length;

        static void Main(string[] args) {

            height = 28;
            length = 100;

            SnakeMoveH hLine1 = new SnakeMoveH(0, length, 0, '*');
            hLine1.getLine();
            SnakeMoveH hLine2 = new SnakeMoveH(0, length, height, '*');
            hLine2.getLine();
            SnakeMoveV vLine1 = new SnakeMoveV(0, 0, height, '*');
            vLine1.getLine();
            SnakeMoveV vLine2 = new SnakeMoveV(length, 0, height, '*');
            vLine2.getLine();

            Point p = new Point(2, 2, '*');
            Snake s = new Snake(p, 4, Direction.right);
            s.getLine();
            for (int i = 0; i < 90; i++) {
                s.toDir();
                Thread.Sleep(500);
            }

        }
    } 
} 
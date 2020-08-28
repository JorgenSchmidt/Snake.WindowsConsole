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

            Wall wall = new Wall(length, height) ;

            Point p = new Point(2, 2, '*');
            Snake s = new Snake(p, 4, Direction.right);
            s.getLine();

            SpawnFood foodspawner = new SpawnFood(length, height, '$');
            Point food = foodspawner.foodSP();
            food.getPoint();

            while (true) {

                if (wall.isHit(s) || s.isHitTail()) {
                    break;
                }

                if (s.eat(food)) {
                    food = foodspawner.foodSP();
                    food.getPoint();
                } else {
                    s.toDir();
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    s.handleKey(key.Key);
                }
                wall = new Wall(length, height);
            }

            

        }
    } 
} 
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Snake {
    class Point{
        private int x;
        private int y;
        private char sym;

        public Point(int _x, int _y, char _sym) {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public void getPoint() {
            Console.SetCursorPosition(x,y);
            Console.WriteLine(sym);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Snake {
    class Point : Figure{
        private int x;
        private int y;
        public char sym;

        public Point(int _x, int _y, char _sym) {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p) {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void getPoint() {
            Console.SetCursorPosition(x,y);
            Console.WriteLine(sym);
        }

        public override string ToString() {
            return x + ", " + y + ", " + sym;
        }

        public void Move(int offset, Direction dir) {
            if (dir == Direction.right) {
                x += offset;
            }
            else if (dir == Direction.left) {
                x -= offset;
            }
            else if (dir == Direction.up) {
                y -= offset;
            }
            else if (dir == Direction.down) {
                y += offset;
            }
        }

        public void clear() {
            sym = ' ';
            getPoint();
        }

        public bool IsHit(Point _p) {
            return (_p.x == this.x) && (_p.y == this.y);
        }

        public static void drawTheNotIdentificatedPoint(int _x, int _y, char _sym)
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }

    }
}
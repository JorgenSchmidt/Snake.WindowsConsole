using System;

namespace Snake {
    public class Point : Figure{
        private int x;
        private int y;
        private char sym;
        private bool active;

        public Point(int _x, int _y, char _sym) {
            x = _x;
            y = _y;
            sym = _sym;
            active = true;
        }

        public Point(int _x, int _y, char _sym, bool _active)
        {
            x = _x;
            y = _y;
            sym = _sym;
            active = _active;
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

        public void getPoint(char _sym)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(_sym);
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

        public void pointDeactivate ()
        {
            active = false;
        }

        public bool pointDeactivated()
        {
            return active;
        }

        public bool IsHit(Point _p) {
            return (_p.x == x) && (_p.y == y);
        }

        public static void drawTheNotIdentificatedPoint(int _x, int _y, char _sym)
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }

        public void changePointSymbol(Point _targetPoint)
        {
            sym = _targetPoint.sym;
        }
        public char getPointSymbol()
        {
            return sym;
        }

    }
}
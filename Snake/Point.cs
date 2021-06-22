using System;

namespace Snake {

    public class Point : Figure {

        private int pointCoordX;
        private int pointCoordY;
        private char pointSymbol;
        private bool pointActive;

        public Point(int _x, int _y, char _sym) {
            pointCoordX = _x;
            pointCoordY = _y;
            pointSymbol = _sym;
            pointActive = true;
        }

        public Point(int _x, int _y, char _sym, bool _active)
        {
            pointCoordX = _x;
            pointCoordY = _y;
            pointSymbol = _sym;
            pointActive = _active;
        }

        public Point(Point _p) {
            pointCoordX = _p.pointCoordX;
            pointCoordY = _p.pointCoordY;
            pointSymbol = _p.pointSymbol;
        }

        public void getPoint() {
            Console.SetCursorPosition(pointCoordX,pointCoordY);
            Console.WriteLine(pointSymbol);
        }

        public void getPoint(char _sym)
        {
            Console.SetCursorPosition(pointCoordX, pointCoordY);
            Console.WriteLine(_sym);
        }

        public override string ToString() 
        {
            return pointCoordX + ", " + pointCoordY + ", " + pointSymbol;
        }

        public void move(int _offset, Direction _dir) 
        {
            if (_dir == Direction.right) {
                pointCoordX += _offset;
            }
            else if (_dir == Direction.left) {
                pointCoordX -= _offset;
            }
            else if (_dir == Direction.up) {
                pointCoordY -= _offset;
            }
            else if (_dir == Direction.down) {
                pointCoordY += _offset;
            }
        }

        public void clear() 
        {
            pointSymbol = ' ';
            getPoint();
        }

        public void pointDeactivate ()
        {
            pointActive = false;
        }

        public bool pointDeactivated()
        {
            return pointActive;
        }

        public bool isHit(Point _p) 
        {
            return (_p.pointCoordX == pointCoordX) && (_p.pointCoordY == pointCoordY);
        }

        public static void drawTheNotIdentificatedPoint(int _x, int _y, char _sym)
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }

        public void changePointSymbol(Point _targetPoint)
        {
            pointSymbol = _targetPoint.pointSymbol;
        }

        public char getPointSymbol()
        {
            return pointSymbol;
        }

    }
}
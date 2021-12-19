using System;

namespace Snake {

    public class Point : Figure {

        // Current point coordinates
        private int pointCoordX;
        private int pointCoordY;

        // Point symbol
        private char pointSymbol;

        // Toggler poing (use for showing/hiding point, also checks if the player can pick up a point, need for potions logic)
        private bool pointActive;

        // Simple point constructor
        public Point(int _x, int _y, char _sym) {
            pointCoordX = _x;
            pointCoordY = _y;
            pointSymbol = _sym;
            pointActive = true;
        }

        // Point constructor for target active status (using for potions)
        public Point(int _x, int _y, char _sym, bool _active)
        {
            pointCoordX = _x;
            pointCoordY = _y;
            pointSymbol = _sym;
            pointActive = _active;
        }

        // For copying target point to new point
        public Point(Point _p) {
            pointCoordX = _p.pointCoordX;
            pointCoordY = _p.pointCoordY;
            pointSymbol = _p.pointSymbol;
        }

        // Lets draws target point
        public void getPoint() {
            Console.SetCursorPosition(pointCoordX,pointCoordY);
            Console.WriteLine(pointSymbol);
        }

        // Lets draws target poing with transmitted character ("char _sym")
        public void getPoint(char _sym)
        {
            Console.SetCursorPosition(pointCoordX, pointCoordY);
            Console.WriteLine(_sym);
        }

        // For move the point without redrawing
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

        // For clear target clear
        // Important to know: using when snake moves after delete this point from main point list
        public void clear() 
        {
            pointSymbol = ' ';
            getPoint();
        }

        // For deactive point
        // Using for deactivate potion after giving
        public void pointDeactivate ()
        {
            pointActive = false;
        }

        // For cheking point by active
        public bool pointDeactivated()
        {
            return pointActive;
        }

        // For checking this point with target point by contact
        public bool isHit(Point _p) 
        {
            return (_p.pointCoordX == pointCoordX) && (_p.pointCoordY == pointCoordY);
        }

        // Using for redrawing wall after snake moves (watch "key aviable" fragment of game cycle). This is use for workaround in main program.
        public static void drawTheNotIdentificatedPoint(int _x, int _y, char _sym)
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }

        // For change point symbol. Using for change food point to snake point after when snake eats a food
        public void changePointSymbol(Point _targetPoint)
        {
            pointSymbol = _targetPoint.pointSymbol;
        }

        // For get point symbol. Using for change potion point to snake point after when snake drinks a dpotion
        public char getPointSymbol()
        {
            return pointSymbol;
        }

    }
}
using System.Collections.Generic;

namespace Snake{

    class Horisontal : Figure {

        // For initialization some horisontal figure (this methods cant draws figure)
        public Horisontal(int _leftBorderByX, int _rightBorderByX, int _y, char _sym) {

            pointList = new List<Point>();

            for (int x = _leftBorderByX; x <= _rightBorderByX; x++) {
                Point _point = new Point(x, _y, _sym);
                pointList.Add(_point);
            }

        }

    }

}
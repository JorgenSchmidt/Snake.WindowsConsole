using System.Collections.Generic;

namespace Snake {

    class Vertical : Figure {

        // For initialization some vertical figure (this methods cant draws figure)
        public Vertical(int _coordX, int _upperCoordY, int _lowerCoordY, char _symbol) {

            pointList = new List<Point>();

            for (int y = _upperCoordY; y <= _lowerCoordY; y++) {
                Point _point = new Point(_coordX, y, _symbol);
                pointList.Add(_point);
            }

        }

    }

}
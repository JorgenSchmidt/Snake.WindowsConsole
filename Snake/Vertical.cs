using System.Collections.Generic;

namespace Snake {
    class Vertical : Figure {
        public Vertical(int _coordX, int _upperCoordY, int _lowerCoordY, char _symbol) {

            pointList = new List<Point>();

            for (int y = _upperCoordY; y <= _lowerCoordY; y++) {
                point = new Point(_coordX, y, _symbol);
                pointList.Add(point);
            }

        }
    }
}
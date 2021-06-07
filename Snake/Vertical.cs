using System.Collections.Generic;

namespace Snake {
    class Vertical : Figure {
        public Vertical(int x, int upY, int downY, char sym) {

            pointList = new List<Point>();

            for (int y = upY; y <= downY; y++) {
                p = new Point(x, y, sym);
                pointList.Add(p);
            }

        }
    }
}
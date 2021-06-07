using System.Collections.Generic;

namespace Snake{
    class Horisontal : Figure {
        public Horisontal(int leftX, int rightX, int y, char sym) {

            pointList = new List<Point>();

            for (int x = leftX; x <= rightX; x++) {
                p = new Point(x, y, sym);
                pointList.Add(p);
            }

        }

    }

}

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake{
    class SnakeMoveH{
        private List<Point> pList;
        private Point p;
        public SnakeMoveH(int leftX, int rightX, int y, char sym) {

            pList = new List<Point>();

            for (int x = leftX; x <= rightX; x++) {
                p = new Point(x, y, sym);
                pList.Add(p);
            }

        }

        public void getLine() {
            foreach (Point p in pList) {
                p.getPoint();
            }
        }

    }

}

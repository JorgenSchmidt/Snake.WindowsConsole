using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake{
    class SnakeMove{
        List<Point> pList;

        public SnakeMove(int leftX, int rightX, int y, char sym) {

            pList = new List<Point>();
            Point p;

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

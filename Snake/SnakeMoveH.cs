using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake{
    class SnakeMoveH : Figure {
        public SnakeMoveH(int leftX, int rightX, int y, char sym) {

            pList = new List<Point>();

            for (int x = leftX; x <= rightX; x++) {
                p = new Point(x, y, sym);
                pList.Add(p);
            }

        }

    }

}

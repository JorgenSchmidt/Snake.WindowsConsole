using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Snake {
    class SnakeMoveV : Figure {
        public SnakeMoveV(int x, int upY, int downY, char sym) {

            pList = new List<Point>();

            for (int y = upY; y <= downY; y++) {
                p = new Point(x, y, sym);
                pList.Add(p);
            }

        }
    }
}
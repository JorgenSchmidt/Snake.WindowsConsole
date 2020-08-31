using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Snake {
    class Vertical : Figure {
        public Vertical(int x, int upY, int downY, char sym) {

            pList = new List<Point>();

            for (int y = upY; y <= downY; y++) {
                p = new Point(x, y, sym);
                pList.Add(p);
            }

        }
    }
}
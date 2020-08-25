using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure{

        protected List<Point> pList;
        protected Point p;

        public void getLine()
        {
            foreach (Point p in pList)
            {
                p.getPoint();
            }
        }
    }
    enum Direction { up,down,left,right }
}

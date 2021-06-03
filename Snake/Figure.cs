using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Figure{

        protected List<Point> pointList;
        protected Point p;

        public void getLine() {
            foreach (Point p in pointList) {
                p.getPoint();
            }
        }

        public void getLine(int _sleep)
        {
            foreach (Point p in pointList)
            {
                p.getPoint();
                Thread.Sleep(_sleep);
            }
        }

        internal bool IsHit(Figure _figure) {
            foreach (var _p in pointList) {
                if (_figure.IsHit(_p)) {
                    return true;
                }
            }
            return false;
        }

        private bool IsHit(Point _point) {
            foreach (var _p in pointList) {
                if (_p.IsHit(_point)) {
                    return true;
                }
            }
            return false;
        }

    }
    enum Direction { up,down,left,right }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure{

        protected List<Point> pList;
        protected Point p;

        public void getLine() {
            foreach (Point p in pList) {
                p.getPoint();
            }
        }

        internal bool IsHit(Figure _figure) {
            foreach (var _p in pList) {
                if (_figure.IsHit(_p)) {
                    return true;
                }
            }
            return false;
        }

        private bool IsHit(Point _point) {
            foreach (var _p in pList) {
                if (_p.IsHit(_point)) {
                    return true;
                }
            }
            return false;
        }

    }
    enum Direction { up,down,left,right }
}

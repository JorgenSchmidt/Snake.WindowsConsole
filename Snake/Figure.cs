using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    // Based class for operations with figures
    public abstract class Figure{

        protected List<Point> pointList;

        // This getLine() methods lets draw initialized point list
        // First method's override draws point list without delay
        // Second method's override draws point list with delay (using for drawing game walls)
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

        // This methods let checking to contact between different Figure objects
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
                if (_p.isHit(_point)) {
                    return true;
                }
            }
            return false;
        }

    }
    public enum Direction { up,down,left,right }
}
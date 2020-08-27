using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake : Figure {

        Direction dir;
        
        public Snake(Point tail, int length, Direction _dir) {

            pList = new List<Point>();
            dir = _dir;

            for (int i = 0; i < length; i++) {
                p = new Point(tail);
                p.Move(i, _dir);
                pList.Add(p);
            }

        }

        internal void toDir() {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = getMeNextPoint();
            pList.Add(head);
            tail.clear();
            head.getPoint();
        }

        public void handleKey(ConsoleKey key) {
            if (key == ConsoleKey.LeftArrow)
            {
                dir = Direction.left;
            }
            else if (key== ConsoleKey.RightArrow)
            {
                dir = Direction.right;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                dir = Direction.down;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                dir = Direction.up;
            }
        }

        public Point getMeNextPoint() {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, dir);
            return nextPoint;
        }

    }
}

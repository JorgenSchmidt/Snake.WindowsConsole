using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake {
    class TSnake : Figure {

        private static char potionSymbol;
        private Direction dir;
        
        public TSnake(Point _tail, int _length, Direction _dir) {

            pointList = new List<Point>();
            dir = _dir;

            for (int i = 0; i < _length; i++) {
                p = new Point(_tail);
                p.Move(i, _dir);
                pointList.Add(p);
            }

        }

        internal void toDir() {
            Point tail = pointList.First();
            pointList.Remove(tail);
            Point head = getMeNextPoint();
            pointList.Add(head);
            tail.clear();
            head.getPoint();
        }

        internal bool eat(Point _food) {
            Point head = getMeNextPoint();
            if (head.IsHit(_food)) 
            {
                _food.changePointSymbol(head);
                pointList.Add(_food);
                return true;
            }
            return false;
        }

        public void handleKeyArrow(ConsoleKey key) 
        {
            Direction _lastDirection = dir;
            if (key == ConsoleKey.LeftArrow)
            {
                if (_lastDirection != Direction.right)
                {
                    dir = Direction.left;
                }
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if (_lastDirection != Direction.left)
                {
                    dir = Direction.right;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (_lastDirection != Direction.up)
                {
                    dir = Direction.down;
                }
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if (_lastDirection != Direction.down)
                {
                    dir = Direction.up;
                }
            }

        }

        public void handleKeyWASD(ConsoleKey key)
        {
            Direction _lastDirection = dir;
            if (key == ConsoleKey.A)
            {
                if (_lastDirection != Direction.right)
                {
                    dir = Direction.left;
                }
            }
            else if (key == ConsoleKey.D)
            {
                if (_lastDirection != Direction.left)
                {
                    dir = Direction.right;
                }
            }
            else if (key == ConsoleKey.S)
            {
                if (_lastDirection != Direction.up)
                {
                    dir = Direction.down;
                }
            }
            else if (key == ConsoleKey.W)
            {
                if (_lastDirection != Direction.down)
                {
                    dir = Direction.up;
                }
            }

        }

        internal bool isHitTail() {

            var head = pointList.Last();
            for (int i = 0; i < pointList.Count - 2; i++) {
                if (head.IsHit(pointList[i])) {
                    return true;
                }
            }

            return false;
        }

        public bool isHitPotion (SpawnPotions _sp)
        {
            List<Point> potions = _sp.getPotionsList();
            var head = pointList.Last();
            foreach (var currentPotion in potions) 
            {
                if (head.IsHit(currentPotion))
                {
                    potionSymbol = currentPotion.getPointSymbol();
                    return true;
                }
            }
            return false;
        }

        public Point getMeNextPoint() {
            Point head = pointList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, dir);
            return nextPoint;
        }

        public static char getPotionSymbol()
        {
            return potionSymbol;
        }

    }
}

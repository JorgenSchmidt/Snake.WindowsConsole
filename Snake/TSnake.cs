using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake {

    class TSnake : Figure {

        private Direction currentDirection;
        
        // For initialization the snake
        public TSnake(Point _tail, int _length, Direction _dir) {

            pointList = new List<Point>();
            currentDirection = _dir;

            for (int i = 0; i < _length; i++) {
                Point point = new Point(_tail);
                point.move(i, _dir);
                pointList.Add(point);
            }

        }

        // For snake's move (snakes elements as queue)
        internal void toDirection() 
        {
            Point tail = pointList.First();
            pointList.Remove(tail);
            Point head = getMeNextPoint();
            pointList.Add(head);
            tail.clear();
            head.getPoint();
        }

        // Logic of consume the food by a snake
        internal bool eat(Point _food) {
            Point head = getMeNextPoint();
            if (head.isHit(_food)) 
            {
                _food.changePointSymbol(head);
                pointList.Add(_food);
                return true;
            }
            return false;
        }

        // Lets get new next point for snake
        public Point getMeNextPoint()
        {
            Point head = pointList.Last();
            Point nextPoint = new Point(head);
            nextPoint.move(1, currentDirection);
            return nextPoint;
        }

        // For change direction for snake
        public void handleKeyArrow(ConsoleKey key) 
        {
            Direction _lastDirection = currentDirection;
            if (key == ConsoleKey.LeftArrow)
            {
                if (_lastDirection != Direction.right)
                {
                    currentDirection = Direction.left;
                }
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if (_lastDirection != Direction.left)
                {
                    currentDirection = Direction.right;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (_lastDirection != Direction.up)
                {
                    currentDirection = Direction.down;
                }
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if (_lastDirection != Direction.down)
                {
                    currentDirection = Direction.up;
                }
            }

        }

        public void handleKeyWASD(ConsoleKey key)
        {
            Direction _lastDirection = currentDirection;
            if (key == ConsoleKey.A)
            {
                if (_lastDirection != Direction.right)
                {
                    currentDirection = Direction.left;
                }
            }
            else if (key == ConsoleKey.D)
            {
                if (_lastDirection != Direction.left)
                {
                    currentDirection = Direction.right;
                }
            }
            else if (key == ConsoleKey.S)
            {
                if (_lastDirection != Direction.up)
                {
                    currentDirection = Direction.down;
                }
            }
            else if (key == ConsoleKey.W)
            {
                if (_lastDirection != Direction.down)
                {
                    currentDirection = Direction.up;
                }
            }

        }

        // For checking first snakes element by contact with other elements
        internal bool isHitTail() {

            var head = pointList.Last();
            for (int i = 0; i < pointList.Count - 2; i++) {
                if (head.isHit(pointList[i])) {
                    return true;
                }
            }

            return false;
        }

        // Logic of consume potion by a snake
        public bool isHitPotion (SpawnPotions _sp, ref char _potionSymbol, ref int _potionNumber)
        {
            List<Point> potions = _sp.getPotionsList();
            var head = pointList.Last();
            var count = -1;
            foreach (var currentPotion in potions) 
            {
                count++;
                if (head.isHit(currentPotion) && currentPotion.pointDeactivated())
                {
                    _potionSymbol = currentPotion.getPointSymbol();
                    _potionNumber = count;
                    if (_potionNumber < 0) throw new Exception("Potion number was been less than zero");
                    return true;
                }
            }
            return false;
        }

    }
}

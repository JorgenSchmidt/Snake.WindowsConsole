using System;

namespace Snake
{
    class SpawnFood {

        protected int gameFiledLength;
        protected int gameFieldheight;
        protected char foodSymbol;
        private Random randomObject;

        public SpawnFood(int _length, int _height, char _sym) 
        {
            gameFiledLength = _length;
            gameFieldheight = _height;
            foodSymbol = _sym;
        }

        public Point spawnFood() 
        {
            randomObject = new Random();
            int x = randomObject.Next(2, (gameFiledLength - 1));
            int y = randomObject.Next(2 + Wall.getStartPosition(), (gameFieldheight - 1));
            return new Point(x, y, foodSymbol);

        }

        public Point spawnFood(int _xLimit, int _yLimit)
        {
            randomObject = new Random();
            int x = randomObject.Next(2, (gameFiledLength - 1) - _xLimit);
            int y = randomObject.Next(2 + Wall.getStartPosition(), (gameFieldheight - 1) - _yLimit);
            if (x <= 0 || y <= 0) throw new Exception("X or Y was been less than zero");
            return new Point(x, y, foodSymbol);

        }

        public Point spawnFood(int _delta, int _length, int _width)
        {
            randomObject = new Random();
            int x = randomObject.Next(_length / 2 + _delta, _length - 1);
            int y = randomObject.Next(_width / 2 + _delta + Wall.getStartPosition(), _width - 1);
            if (_length / 2 + _delta >= _length || _width / 2 + _delta + Wall.getStartPosition() >= _width) throw new Exception("X or Y was been less than zero");
            return new Point(x, y, foodSymbol);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class SpawnFood {

        protected int width;
        protected int height;
        protected char sym;

        public SpawnFood(int _width, int _height, char _sym) 
        {
            width = _width;
            height = _height;
            sym = _sym;
        }

        public Point foodSP() 
        {
            Random rnd = new Random();
            int x = rnd.Next(2, (width - 1));
            int y = rnd.Next(2 + Wall.getStartPosition(), (height - 1));
            return new Point(x, y, sym);

        }

        public Point foodSP(int _xLimit, int _yLimit)
        {
            Random rnd = new Random();
            int x = rnd.Next(2, (width - 1) - _xLimit);
            int y = rnd.Next(2 + Wall.getStartPosition(), (height - 1) - _yLimit);
            if (x <= 0 || y <= 0) throw new Exception("X or Y was been less than zero");
            return new Point(x, y, sym);

        }

        public Point foodSP(int _delta, int _length, int _width)
        {
            Random rnd = new Random();
            int x = rnd.Next(_length / 2 + _delta, _length - 1);
            int y = rnd.Next(_width / 2 + _delta + Wall.getStartPosition(), _width - 1);
            if (_length / 2 + _delta >= _length || _width / 2 + _delta + Wall.getStartPosition() >= _width) throw new Exception("X or Y was been less than zero");
            return new Point(x, y, sym);

        }

    }
}

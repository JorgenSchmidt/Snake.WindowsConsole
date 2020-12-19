using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class SpawnFood {

        private int width;
        private int height;
        private char sym;
        Random rnd = new Random();

        public SpawnFood(int _width, int _height, char _sym) {
            this.width = _width;
            this.height = _height;
            this.sym = _sym;
        }

        public Point foodSP() {

            int x = rnd.Next(2, (width - 1));
            int y = rnd.Next(2 + Wall.getStartPosition(), (height - 1));
            return new Point(x, y, sym);

        }

    }
}

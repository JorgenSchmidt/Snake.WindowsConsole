using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Wall{

        List<Figure> wallList;

        public Wall(int _length, int _height) {

            Horisontal hLine1 = new Horisontal(0, _length, 0, '+');
            hLine1.getLine();
            Horisontal hLine2 = new Horisontal(0, _length, _height, '+');
            hLine2.getLine();
            Vertical vLine1 = new Vertical(0, 0, _height, '+');
            vLine1.getLine();
            Vertical vLine2 = new Vertical(_length, 0, _height, '+');
            vLine2.getLine();



        }

    }
}

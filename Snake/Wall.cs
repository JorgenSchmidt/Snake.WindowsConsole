using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    
    class Wall{

        List<Figure> wallList;
        private int sleepWall1;
        private int sleepWall2;
        public Wall(int _length, int _height) {

            wallList = new List<Figure>();
            sleepWall1 = 6;
            sleepWall2 = 12;

            Horisontal hLine1 = new Horisontal(0, _length, 0, '+');
            hLine1.getLine(sleepWall1);
            Horisontal hLine2 = new Horisontal(0, _length, _height, '+');
            hLine2.getLine(sleepWall1);
            Vertical vLine1 = new Vertical(0, 0, _height, '+');
            vLine1.getLine(sleepWall2);
            Vertical vLine2 = new Vertical(_length, 0, _height, '+');
            vLine2.getLine(sleepWall2);

            wallList.Add(hLine1);
            wallList.Add(hLine2);
            wallList.Add(vLine1);
            wallList.Add(vLine2);

        }

        internal bool isHit(Figure _figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(_figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void getPoint() {
            foreach (var wall in wallList) {
                wall.getLine();
            }
        }

    }
}
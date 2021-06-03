using System.Collections.Generic;

namespace Snake {
    
    class Wall{

        private List<Figure> wallList;
        private int sleepWall1;
        private int sleepWall2;
        private static int startPosition;

        public Wall(int _length, int _height) {

            wallList = new List<Figure>();
            sleepWall1 = 6;
            sleepWall2 = 12;
            startPosition = 3;

            Horisontal hLine1 = new Horisontal(0, _length, startPosition, '+');
            hLine1.getLine(sleepWall1);
            Horisontal hLine2 = new Horisontal(0, _length, _height + startPosition, '+');
            hLine2.getLine(sleepWall1);
            Vertical vLine1 = new Vertical(0, startPosition, _height + startPosition, '+');
            vLine1.getLine(sleepWall2);
            Vertical vLine2 = new Vertical(_length, startPosition, _height + startPosition, '+');
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

        public static int getStartPosition() {

            return startPosition;

        }

    }
}
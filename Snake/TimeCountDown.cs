using System;
using System.Threading;

namespace Snake
{
    public class TimeCountDown
    {
        private int seconds;
        private int minutes;

        public int getSeconds () 
        {
            return minutes * 60 + seconds;
        }
        public void addSeconds (int _value)
        {
            seconds += _value;
        }

        public TimeCountDown ()
        {
            seconds = 0;
            minutes = 0;
        }
        public TimeCountDown (int _minutes, int _seconds)
        {
            minutes = _minutes;
            seconds = _seconds;
        }

        public void writeCountDown(int _x, int _y, int _lastedTime)
        {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(secondsToString(_lastedTime));
        }
        public void writeCountDown(int _x, int _y)
        {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine("0:00          ");
        }

        public string secondsToString (int _lastedTime)
        {
            int _time = _lastedTime + seconds + minutes * 60;
            int _minutes = _time / 60;
            int _seconds = _time % 60;
            if (_seconds < 10)
            {
                return _minutes.ToString() + ":0" + _seconds.ToString();
            }
            else return _minutes.ToString() + ":" + _seconds.ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyPredator2
{
    public class Position
    {
        private int _x;
        private int _y;


        public Position(int x, int y)
        {
            X= x;
            Y= y;
        }
      
        public int X
        {
            get { return _x; }
            set
            {
                if(value >= 0 &&  value <= 15)
                    _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if( value >= 0 && value <= 15)
                    _y = value;
            }
        }

        public void MoveUp()
        {
            if(_y > 0)
                _y--;
            
                
        }

        public void MoveDown()
        {
            if (_y < 15)
                _y++;
        }

        public void MoveLeft()
        {
            if(_x > 0)
                _x--;
        }

        public void MoveRight()
        {
            if( _x < 15)
                _x++;
        }

    }
}

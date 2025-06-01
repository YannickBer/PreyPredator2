using PreyPredator2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PreyPredator2
{
    public abstract class Animal : IAnimal
    {
        protected static Random _randomGenerator = new Random();
        protected int _age;
        protected int _maxAge;
        protected bool _IsDead;
        protected Color _color;
        protected Position _position;
        protected Canvas _canvas;
        protected Ellipse _ellipse;

        public virtual Position position
        {
            get { return _position;  }
        }

        public virtual bool IsDead
        {
            get { return _IsDead; }
            set { _IsDead = value;  }
        }

        public Animal(int maxAge, Color color)
        {
            _age = 0;
            _maxAge = maxAge;
            _color = color;
            int randomY = _randomGenerator.Next(0,16);
            int randomX = _randomGenerator.Next(0, 16);

            _position = new Position(randomX, randomY);
           
            _ellipse = new Ellipse()
            {
                Height = 5,
                Width = 5,
                Margin = new System.Windows.Thickness(randomX * 10, randomY * 10, 0, 0),
                Fill = new SolidColorBrush(_color)
            };

        }

        public Animal(int maxAge,Color color, Position position)
            : this(maxAge, color)
        {
            _position = position;
        }


        public void DisplayOn(Canvas canvas)
        {
            _canvas = canvas;
            canvas.Children.Add(_ellipse);
            
        }

        public void Move()
        {
            _age++;
            if(_age > _maxAge)
            {
                IsDead = true;
                StopDisplaying();
                return;
            }

            int direction = _randomGenerator.Next(0, 4);
            switch(direction)
            {
                case 0:_position.MoveUp();  UpdateDisplay(); break;
                case 1:_position.MoveDown(); UpdateDisplay(); break;
                case 2:_position.MoveLeft(); UpdateDisplay(); break;
                case 3:_position.MoveRight(); UpdateDisplay(); break;
            }

            UpdateDisplay();
        }

        public void StopDisplaying()
        {
            _canvas.Children.Remove(_ellipse);
        }

        public abstract IAnimal TryBreed();
        

        public void UpdateDisplay()
        {
            _ellipse.Margin = new System.Windows.Thickness(_position.X * 10, _position.Y * 10,0,0);
        }
    }
}

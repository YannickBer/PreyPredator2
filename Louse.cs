using PreyPredator2.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyPredator2
{
    public class Louse : Animal
    {
        private const int MAX_AGE = 6;

        public Louse()
            : base(MAX_AGE,Colors.GreenYellow)
        {
        }

        public override IAnimal TryBreed()
        {
            if(_age > 0 && _age % 2 == 0)
            {
                return new Louse();
            }else
            {
                return null;
            }
        }

    }
}

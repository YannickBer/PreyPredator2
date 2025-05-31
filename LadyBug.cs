using PreyPredator2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PreyPredator2
{
    public class LadyBug : Animal, IPredator
    {
        private const int MAX_AGE = 16;
        private int _daysWithNoFood;

        public LadyBug()
            : base(MAX_AGE, Colors.Red)
        {
        }

        
        public bool CanEat(IAnimal animal)
        {
            return animal is Louse && !animal.IsDead;
        }

        public void Hunt(IList<IAnimal> possibleVictims)
        {
            foreach(var victim in possibleVictims)
            {

                //De formule op de PDF
                double distance = Math.Sqrt(Math.Pow(_position.X - victim.position.X,2) + Math.Pow(_position.Y - victim.position.Y,2));

                if(distance <= 3)
                {
                    victim.StopDisplaying();
                    victim.IsDead = true;
                    _daysWithNoFood = 0;
                    return;
                }

                
            }

            
            _daysWithNoFood++;


            //Als het 3 dagen niet gegeten heeft dan sterft het.
            if (_daysWithNoFood == 3)
            {
                IsDead = true;
                StopDisplaying();
            }
            
        }


        //Om de 4 ronden kan de LadyBug zich voortplanten
        public override IAnimal TryBreed()
        {
            if(_age > 0 && _age % 4 == 0)
            {
                return new LadyBug();
            }else
            {
                return null;
            }
        }

    }
}

using PreyPredator2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PreyPredator2
{
    public class AnimalWorld : IAnimalWorld
    {
        private Canvas _canvas;
        private IList<IAnimal> _allAnimals = new List<IAnimal>();
        private int _currentRoundNumber = 0;

       
        public IList<IAnimal> AllAnimals => _allAnimals;
        public int CurrentRoundNumber => _currentRoundNumber;

        public AnimalWorld(Canvas canvas)
        {
            _canvas = canvas;
        }


        public void AddAnimal(IAnimal animal)
        {
            _allAnimals.Add(animal);    
            animal.DisplayOn(_canvas); 

        }

        public void ProcessRound()
        {
            IList<IAnimal> born = new List<IAnimal>();
            IList<IAnimal> died = new List<IAnimal>();
            _currentRoundNumber++;

            foreach (var animal in _allAnimals)
            {

                
                animal.Move();

                IAnimal baby = animal.TryBreed(); 

                if(baby != null)
                {
                    born.Add(baby);
                }

                if(animal is IPredator predator) 
                {
                    predator.Hunt(_allAnimals);

                }

                if (animal.IsDead) 
                {
                    died.Add(animal);
                }
            }

            foreach(var animal in born) //aparte lijst nieuwgeboren dieren
            {
                AddAnimal(animal);
            }

            foreach(var animal in died) // aparte lijst gestorven dieren
            {
                _allAnimals.Remove(animal);
                animal.StopDisplaying();
            }


        }
    }
}

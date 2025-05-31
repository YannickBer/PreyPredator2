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
            IList<IAnimal> geboren = new List<IAnimal>();
            IList<IAnimal> gestorven = new List<IAnimal>();


            foreach (var animal in _allAnimals)
            {

                _currentRoundNumber++; 
                animal.Move();

                IAnimal baby = animal.TryBreed(); 

                if(baby != null)
                {
                    geboren.Add(baby);
                }

                if(animal is IPredator predator) 
                {
                    predator.Hunt(_allAnimals);
                }

                if (animal.IsDead) 
                {
                    gestorven.Add(animal);
                }
            }

            foreach(var animal in geboren) //aparte lijst nieuwgeboren dieren
            {
                AddAnimal(animal);
            }

            foreach(var animal in gestorven) // aparte lijst gestorven dieren
            {
                _allAnimals.Remove(animal);
            }


        }
    }
}

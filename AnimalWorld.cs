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

                _currentRoundNumber++; // verhogen van een ronde
                animal.Move(); //dier bewegen

                IAnimal baby = animal.TryBreed(); // variabele tussenstap voor TryBreed();

                if(baby != null) //aparte lijst voor geboren dieren zoals gevraagd in PDF 
                {
                    geboren.Add(baby);
                }

                if(animal is IPredator predator) //controleren of het dier een roofdier is ( LadyBug ) 
                {
                    predator.Hunt(_allAnimals);
                }

                if (animal.IsDead) //aparte lijst voor gestorven dieren zoals gevraagd in PDF
                {
                    gestorven.Add(animal);
                }
            }

            foreach(var animal in geboren)
            {
                _allAnimals.Add(animal);
                animal.DisplayOn(_canvas);
            }

            foreach(var animal in gestorven)
            {
                _allAnimals.Remove(animal);
            }


        }
    }
}

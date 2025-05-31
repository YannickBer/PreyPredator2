using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyPredator2.Contracts
{
    public interface IPredator : IAnimal
    {
        bool CanEat(IAnimal animal);

        void Hunt(IList<IAnimal> possibleVictims);
    }
}

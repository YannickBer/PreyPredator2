using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyPredator2.Contracts
{
    public interface IAnimal : IDisplayable
    {

        //In de PDF wordt niet gesproken over een read only dus deze keer heb ik er een get + set van gemaakt.
        bool IsDead { get; set; }

        void Move();

        IAnimal TryBreed();

        Position position { get; }
    }
}

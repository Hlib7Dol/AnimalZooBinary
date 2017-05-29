using System;
using System.Collections.Generic;
using System.Text;
using AnimalZooBinary.Scope;

namespace AnimalZooBinary.Animals
{
    internal abstract class BaseAnimal
    {
        protected virtual string Name { get; set; }
        protected virtual int Health { get; set; }
        protected virtual string AnimalType { get; set; }
        protected virtual AnimalStateEnum AnimalState { get; set; }

        internal BaseAnimal()
        {
            AnimalState = AnimalStateEnum.Full;
        }

        internal virtual string GetAnimalName()
        {
            return Name;
        }

        internal virtual int GetAnimalHealth()
        {
            return Health;
        }

        internal virtual string GetAnimalType()
        {
            return AnimalType;
        }

        internal virtual void FeedAnimal()
        {
            if (AnimalState == AnimalStateEnum.Dead)
                return;

            if ((int)AnimalState < 3)
            AnimalState += 1;
        }

        internal virtual void IncreaseHealth()
        {

        }

        internal virtual void DecreaseHealth()
        {
            if (AnimalState == AnimalStateEnum.Dead)
                return;

            Health -= 1;
        }

        internal virtual void DecreaseAnimalState()
        {
            if (AnimalState == AnimalStateEnum.Dead)
                return;

            if(Health == 0)
            {
                AnimalState = AnimalStateEnum.Dead;

                Console.WriteLine(Name + " is dead, remove him");

                return; 
            }

            if (AnimalState == AnimalStateEnum.Sick)
            {
                Health -= 1;

                return;
            }                

            AnimalState -= 1;
        }

        internal virtual AnimalStateEnum GetAnimalState()
        {
            return AnimalState;
        }
    }
}

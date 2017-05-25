using System;
using System.Collections.Generic;
using System.Text;
using AnimalZooBinary.Animals;

namespace AnimalZooBinary.Scope
{
    internal class CreateAnimalFactory
    {
        internal static BaseAnimal CreateAnimal(string animalType, string name)
        {
            switch (animalType)
            {
                case "Bear":
                    return new Bear(name);
                case "Elephant":
                    return new Elephant(name);
                case "Fox":
                    return new Fox(name);
                case "Lion":
                    return new Lion(name);
                case "Tiger":
                    return new Tiger(name);
                case "Wolf":
                    return new Wolf(name);
            }

            throw new Exception();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Animals
{
    internal class Elephant : BaseAnimal
    {
        private const int _maxHealth = 7;

        internal Elephant(string name) : base()
        {
            Name = name;

            Health = _maxHealth;

            AnimalType = "Elephant";
        }

        internal override void IncreaseHealth()
        {
            base.IncreaseHealth();

            Health = Health + 1 >= _maxHealth ? _maxHealth : Health + 1;
        }
    }
}

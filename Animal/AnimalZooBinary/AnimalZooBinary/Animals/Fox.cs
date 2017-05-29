using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Animals
{
    internal class Fox : BaseAnimal
    {
        private const int _maxHealth = 3;

        internal Fox(string name) : base()
        {
            Name = name;

            Health = _maxHealth;

            AnimalType = "Fox";
        }

        internal override void IncreaseHealth()
        {
            base.IncreaseHealth();

            Health = Health + 1 >= _maxHealth ? _maxHealth : Health + 1;
        }
    }
}

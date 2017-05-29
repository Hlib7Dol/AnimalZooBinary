using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Animals
{
    internal class Bear : BaseAnimal
    {
        private const int _maxHealth = 6;

        internal Bear(string name) : base()
        {
            Name = name;

            Health = _maxHealth;

            AnimalType = "Bear";
        }

        internal override void IncreaseHealth()
        {
            base.IncreaseHealth();

            Health = Health + 1 >= _maxHealth ? _maxHealth : Health + 1;
        }
    }
}

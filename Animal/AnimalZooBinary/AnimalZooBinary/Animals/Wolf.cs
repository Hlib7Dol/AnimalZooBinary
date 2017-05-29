using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Animals
{
    internal class Wolf : BaseAnimal
    {
        private const int _maxHealth = 4;

        internal Wolf(string name) : base()
        {
            Name = name;

            Health = _maxHealth;

            AnimalType = "Wolf";
        }

        internal override void IncreaseHealth()
        {
            base.IncreaseHealth();

            Health = Health + 1 >= _maxHealth ? _maxHealth : Health + 1;
        }
    }
}

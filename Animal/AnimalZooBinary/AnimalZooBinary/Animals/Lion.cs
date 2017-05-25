using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Animals
{
    internal class Lion : BaseAnimal
    {
        private const int _maxHealth = 5;

        internal Lion(string name) : base()
        {
            Name = name;

            Health = _maxHealth;
        }

        internal override void IncreaseHealth()
        {
            base.IncreaseHealth();

            Health = Health + 1 >= _maxHealth ? _maxHealth : Health + 1;
        }
    }
}

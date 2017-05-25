using AnimalZooBinary.Animals;
using AnimalZooBinary.Scope;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Controller
{
    internal class ZooController
    {
        private List<BaseAnimal> _animals = null;

        internal ZooController()
        {
            _animals = new List<BaseAnimal>();
        }

        internal void ChangeAnimalState()
        {
            if (_animals.Count == 0)
                return;

            var randomAnimal = new Random().Next(0, _animals.Count - 1);

            _animals[randomAnimal].DecreaseAnimalState();

            if(_animals.FindAll(a => a.GetAnimalState() == AnimalStateEnum.Dead).Count == _animals.Count)
            {
                Environment.Exit(0);
            }
        }

        internal string AddAnimal(string type, string name)
        {
            try
            {
                _animals.Add(CreateAnimalFactory.CreateAnimal(type, name));

                return "Success, you have add " + type + " " +name;
            }
            catch
            {
                return "Sorry, wrong animal type";
            }
            
        }

        internal string FeedAnimal(string name)
        {
            try
            {
                var animal = _animals.Find(a => a.GetAnimalName() == name);

                animal.FeedAnimal();

                return "Success, you have feed " + name;
            }
            catch
            {
                return "Sorry, wrong animal name";
            }
           
        }

        internal string IncreaseHealth(string name)
        {
            try
            {
                var animal = _animals.Find(a => a.GetAnimalName() == name);

                animal.IncreaseHealth();

                return "Success, you have cured " + name;
            }
            catch
            {
                return "Sorry, wrong animal name";
            }
        }

        internal string DeleteAnimal(string name)
        {
            var animal = _animals.Find(a => a.GetAnimalName() == name);

            if(animal == null)
                return "Sorry, wrong animal name";

            if (animal.GetAnimalState() != AnimalStateEnum.Dead)
                return "Animal isn`t dead";

            _animals.Remove(animal);

            return "Success, you have removed " + name;
        }
    }
}

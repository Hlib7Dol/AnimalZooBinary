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
        private FindBy _groupOrFind = null;

        internal ZooController()
        {
            _animals = new List<BaseAnimal>();
            _groupOrFind = new FindBy();
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

        internal void GroupOrFindAnimals(string param)
        {
            try
            {
                var @params = param.Split(' ');

                switch (@params[0])
                {
                    case "1": _groupOrFind.GroupByType(_animals); break;
                    case "2": _groupOrFind.FindByState((AnimalStateEnum)Enum.Parse(typeof(AnimalStateEnum), @params[1]), _animals); break;
                    case "3": _groupOrFind.FindSickTigers(_animals); break;
                    case "4": _groupOrFind.FindElephantByName(@params[1], _animals); break;
                    case "5": _groupOrFind.FindAllWhichAreHungry(_animals); break;
                    case "6": _groupOrFind.MaxHealth(_animals); break;
                    case "7": _groupOrFind.FindAllDead(_animals); break;
                    case "8": _groupOrFind.FindWolfsAndBears(_animals); break;
                    case "9": _groupOrFind.FindMinMaxHealth(_animals); break;
                    case "10": _groupOrFind.FindAvarageHealthInZoo(_animals); break;
                    default: Console.WriteLine("Sorry, wrong params"); break;
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong, try again please");
            }
        }
    }
}

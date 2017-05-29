using AnimalZooBinary.Animals;
using AnimalZooBinary.Scope;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AnimalZooBinary.Controller
{
    internal class FindBy
    {
        internal void GroupByType(List<BaseAnimal> animals)
        {
            var groupedAnimals = animals.GroupBy(x => x.GetAnimalType()).SelectMany(g => g).ToList();

            foreach (var animal in groupedAnimals)
            { 
                Console.WriteLine("The animal is " + (animal as BaseAnimal).GetAnimalType() + " his name is " + (animal as BaseAnimal).GetAnimalName());
            }

            Console.WriteLine("Press / to refresh window");            
        }

        internal void FindByState(AnimalStateEnum state, List<BaseAnimal> animals)
        {           
            var groupedAnimals = animals.Where(animal => animal.GetAnimalState() == state);

            foreach (var animal in groupedAnimals)
            {
                Console.WriteLine("The animal`s state is " + animal.GetAnimalState() + " his name is " + animal.GetAnimalName());
            }

            Console.WriteLine("Press / to refresh window");            
        }

        internal List<BaseAnimal> FindSickTigers(List<BaseAnimal> animals)
        {
            animals = animals.FindAll(x => x.GetAnimalState() == AnimalStateEnum.Sick)
                .FindAll(x => x.GetAnimalType() == "Tiger")
                as List<BaseAnimal>;

            foreach (var animal in animals)
            {
                Console.WriteLine("The elephants " + animal.GetAnimalType() + "`s name is " + animal.GetAnimalName());
            }

            Console.WriteLine("Press / to refresh window");

            return animals;
        }

        internal List<BaseAnimal> FindElephantByName(string name, List<BaseAnimal> animals)
        {
            animals = animals.FindAll(x => x.GetAnimalType() == "Elephant")
                .FindAll(x => x.GetAnimalName() == name) as List<BaseAnimal>;
            
            Console.WriteLine("You have found the elephant " + animals[0].GetAnimalName());

            Console.WriteLine("Press / to refresh window");

            return animals;
        }

        internal List<BaseAnimal> FindAllWhichAreHungry(List<BaseAnimal> animals)
        {
            animals = animals.FindAll(x => x.GetAnimalState() == AnimalStateEnum.Hungry)
                .FindAll(x => x.GetAnimalType() == "Tiger")
                 as List<BaseAnimal>;

            foreach (var animal in animals)
            {
                Console.WriteLine("The hungry " + animal.GetAnimalType() +"`s name is " + animal.GetAnimalName());
            }

            Console.WriteLine("Press / to refresh window");

            return animals;  
        }

        internal List<BaseAnimal> FindAllDead(List<BaseAnimal> animals)
        {
            animals = animals.FindAll(x => x.GetAnimalState() == AnimalStateEnum.Dead)
                 .GroupBy(x => x.GetAnimalType())
                 as List<BaseAnimal>;

            foreach (var animal in animals)
            {
                Console.WriteLine("The dead animal name is " + animal.GetAnimalName());
            }

            Console.WriteLine("Press / to refresh window");

            return animals;
        }

        internal List<BaseAnimal> FindWolfsAndBears(List<BaseAnimal> animals)
        {
            var wolfs = animals.FindAll(x => x.GetAnimalType() == "Wolf");
            var bears = animals.FindAll(x => x.GetAnimalType() == "Bear");
            wolfs.AddRange(bears);
            wolfs = wolfs.FindAll(x => x.GetAnimalHealth() > 3)
                    as List<BaseAnimal>;

            foreach (var animal in wolfs)
            {
                Console.WriteLine("The " + animal.GetAnimalType() + " name is : " + animal.GetAnimalName());
            }

            Console.WriteLine("Press / to refresh window");

            return animals;
        }

        internal double FindAvarageHealthInZoo(List<BaseAnimal> animals)
        {
            Console.WriteLine("The avarage is : " + animals.Average(x => x.GetAnimalHealth()));

            Console.WriteLine("Press / to refresh window");

            return animals.Average(x => x.GetAnimalHealth());
        }

        internal void FindMinMaxHealth(List<BaseAnimal> animals)
        {
            var resList = new Tuple<int, int>(animals.Max(x => x.GetAnimalHealth()), animals.Min(x => x.GetAnimalHealth()));

            Console.WriteLine("Min:" + resList.Item2 + " Max:" + resList.Item2);

            Console.WriteLine("Press / to refresh window");
        }

        internal List<BaseAnimal> MaxHealth(List<BaseAnimal> animals)
        {
            var res = (from a in animals
                      group a by a.GetAnimalType() into gr
                      select gr.OrderBy(a => a.GetAnimalHealth()).Last()) as List<BaseAnimal>;

            foreach (var animal in animals)
            {
                Console.WriteLine("The " + animal.GetAnimalType() + " name is : " 
                    + animal.GetAnimalName() + " his health is " + animal.GetAnimalHealth());
            }

            Console.WriteLine("Press / to refresh window");

            return res;
        }
    }
}

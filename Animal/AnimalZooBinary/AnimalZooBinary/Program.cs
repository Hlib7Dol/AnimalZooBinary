using AnimalZooBinary.Controller;
using System;


namespace AnimalZooBinary
{
    class Program
    {
        private static ZooInteracter _interactor = new ZooInteracter();

        static void Main(string[] args)
        {
            _interactor.InitInteractor();

            Console.WriteLine(_interactor.AddAnimal("Fox", "Foxy"));
            Console.WriteLine(_interactor.AddAnimal("Lion", "Lion"));
            Console.WriteLine(_interactor.AddAnimal("Elephant", "Elli"));
            
            while (true)
            {
                HandleConsole(Console.ReadLine());                 
            }
        }

        private static void HandleConsole(string key)
        {
            if (key.ToLower().Contains("add"))
            {
                var keyArr = key.Split(' ');

                Console.WriteLine(_interactor.AddAnimal(keyArr[1], keyArr[2]));
            }
            else if (key.ToLower().Contains("feed"))
            {
                var keyArr = key.Split(' ');

                Console.WriteLine(_interactor.FeedAnimal(keyArr[1]));
            }
            else if (key.ToLower().Contains("cure") || key.Contains("health"))
            {
                var keyArr = key.Split(' ');

                Console.WriteLine(_interactor.IncreaseHealth(keyArr[1]));
            }
            else if (key.ToLower().Contains("kill"))
            {
                var keyArr = key.Split(' ');

                Console.WriteLine(_interactor.DeleteAnimal(keyArr[1]));
            }
        }
    }
}
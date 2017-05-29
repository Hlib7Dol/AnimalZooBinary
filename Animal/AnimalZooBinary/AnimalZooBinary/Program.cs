using AnimalZooBinary.Controller;
using System;


namespace AnimalZooBinary
{
    class Program
    {
        private static ZooInteracter _interactor = new ZooInteracter();

        internal static int OpNumber = 0;

        static void Main(string[] args)
        {
            _interactor.InitInteractor();

            Console.WriteLine(_interactor.AddAnimal("Fox", "Foxy"));
            Console.WriteLine(_interactor.AddAnimal("Lion", "Lion"));
            Console.WriteLine(_interactor.AddAnimal("Elephant", "Elli"));

            Console.WriteLine("Choose option:");
            Console.WriteLine("z1 - Animal operations");
            Console.WriteLine("z2 - Find or group animals");

            while (true)
            {
                HandleConsole(Console.ReadLine());                 
            }
        }

        private static void HandleConsole(string key)
        {
            if(OpNumber == 1)
            {
                HandleConsoleOperations(key);

                return;
            }
            else if (OpNumber == 2)
            {
                HandleFindOrGroup(key);

                return;
            }

            if (key.Contains("z1"))
            {      
                OpNumber = 1;
            }
            else if (key.Contains("z2"))
            {
                HandleConsoleFindBy(key);

                OpNumber = 2;
            }
            else
            {
                Console.WriteLine("Sorry, try again");

                OpNumber = 0;
            }
        }
        private static void HandleFindOrGroup(string key)
        {
            _interactor.FindOrGroupAnimals(key);
        }

        private static void HandleConsoleFindBy(string key)
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Group animals by type");
            Console.WriteLine("2 - Group by state");
            Console.WriteLine("3 - Sick tigers");
            Console.WriteLine("4 - Elephant with name");
            Console.WriteLine("5 - Hungry animals");
            Console.WriteLine("6 - Most healthy");
            Console.WriteLine("7 - Dead animals");
            Console.WriteLine("8 - Wolfs and Bears, more then 3 health");
            Console.WriteLine("9 - Max/min health");
            Console.WriteLine("10 - Health avarage of animals");
        }

        private static void HandleConsoleOperations(string key)
        {
            var keyArr = key.Split(' ');

            if (key.ToLower().Contains("add"))
            {              
                Console.WriteLine(_interactor.AddAnimal(keyArr[1], keyArr[2]));
            }
            else if (key.ToLower().Contains("feed"))
            {
                Console.WriteLine(_interactor.FeedAnimal(keyArr[1]));
            }
            else if (key.ToLower().Contains("cure") || key.Contains("health"))
            {
                Console.WriteLine(_interactor.IncreaseHealth(keyArr[1]));
            }
            else if (key.ToLower().Contains("kill"))
            {
                Console.WriteLine(_interactor.DeleteAnimal(keyArr[1]));
            }
        }
    }
}
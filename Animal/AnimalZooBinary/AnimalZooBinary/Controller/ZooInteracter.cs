using AnimalZooBinary.Scope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AnimalZooBinary.Controller
{
    internal class ZooInteracter
    {
        private ZooController _controller = null;
        private Timer _animalActionTimer = null;

        internal ZooInteracter()
        {
            _controller = new ZooController();
        }

        internal void InitInteractor()
        {
            CreateTimer();
        }

        internal string FeedAnimal(string name)
        {
            return _controller.FeedAnimal(name);
        }

        internal string AddAnimal(string type, string name)
        {
            return _controller.AddAnimal(type, name);
        }

        internal string IncreaseHealth(string name)
        {
            return _controller.IncreaseHealth(name);
        }

        internal string DeleteAnimal(string name)
        {
            return _controller.DeleteAnimal(name);
        }

        private void CreateTimer()
        {
            TimerCallback tm = new TimerCallback(AnimalTimerCallBack);

            _animalActionTimer = new Timer(tm, 0, 0, 5000);
        }

        private void AnimalTimerCallBack(object obj)
        {
            _controller.ChangeAnimalState();
        }
    }
}

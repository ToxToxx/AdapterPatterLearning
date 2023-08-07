using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatterLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Player player =  new Player();
           //running
           Running run = new Running();
           player.Move(run);

           Horse horse = new Horse();
           IMovement horseTransport = new HorseToMovementAdapter(horse);
           player.Move(horseTransport);

           Console.ReadKey();

        }
    }
    interface IMovement
    {
        void Run();
    }
    // clas of running 
    class Running : IMovement
    {
        public void Run()
        {
            Console.WriteLine("Player running");
        }
    }
    class Player
    {
        public void Move(IMovement movement)
        {
            movement.Run();
        }
    }
    // transport interface
    interface ITransport
    {
        void Ride();
    }
    // horse class
    class Horse : ITransport
    {
        private int _speed;
        public void Ride()
        {
            _speed = 6;
            Console.WriteLine("Player riding a horse with speed " + _speed + " km/h");
        }
    }
    // Adapter from Horse to Movement
    class HorseToMovementAdapter : IMovement
    {
        private Horse _horse;
        public HorseToMovementAdapter(Horse horse)
        {
            _horse = horse;
        }

        public void Run()
        {
            _horse.Ride();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace horse_race_simulation
{

    class Horseman
    {
        private static Random rnd = new Random();
        public readonly string Name;
        public readonly int Skill; // additional factor that affects horse's performance in the race
        public readonly Horse Horse;
        private bool isRunning;
        public int _totalDistance = 0;
        public event EventHandler<MoveEventArgs> Move;

        public int Distance
        {
            get => _totalDistance;
            private set => _totalDistance = value;
        }

        public Horseman(string name, int skill, Horse horse)
        {
            Name = name;
            Skill = skill;
            Horse = horse;
        }

        public void Run(object sender, EventArgs e)
        {
            Console.WriteLine("Horseman ready to race");
            int TrackLength = (sender as Race).track.Length;
            isRunning = true;
            while(isRunning && Distance < TrackLength)
            {
                Thread.Sleep(1000);
                int distThisTick = rnd.Next(1, this.Horse.Speed);
                Move(this, new MoveEventArgs(distThisTick));
                Distance += distThisTick;
                // to do: implement energy logic
            }
            Console.WriteLine($"Horseman {Name} has finished the Race!");
        }
    }


    class Horse
    {
        public readonly int Id;
        public readonly int Stamina; //defines energy loss rate
        public int Speed; 
        public int Energy = 100; // when falls to 0, speed is decreased by half for a while


        public Horse(int id, int stamina, int speed)
        {
            Id = id;
            Stamina = stamina;
            Speed = speed;
        }
    }
   
}

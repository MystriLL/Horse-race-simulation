using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace horse_race_simulation
{

    class MoveEventArgs: EventArgs
    {
        public readonly int move;
        public MoveEventArgs(int m) => move = m;
    }

    class Race
    {
        public int distance = 1000;
        private EventHandler run = null;
        private Dictionary<string,int> position = new Dictionary<string, int>();

        public event EventHandler Run
        {
            add
            {
                run += value;
                var rider = value.Target as Horseman;
                position[rider.Name] = 0;
                rider.Move += this.Move;
            }
            remove
            {
                run -= value;
            }
        }

        public void Start(List<Horseman> participants)
        {
            WriteLine("Race is about to start");
            foreach (var p in participants)
                this.Run += p.Run;
            Thread.Sleep(1000);
            WriteLine("The race has started!");
            Task[] riders = new Task[run.GetInvocationList().Length];
            int i = 0;
            foreach(EventHandler rider in run.GetInvocationList())
                riders[i++] = Task.Run(() => rider(this, EventArgs.Empty));
            Task.WaitAll(riders);
        }


        public void Move(object sender, EventArgs e)
        {
            var rider = sender as Horseman;
            position[rider.Name] = rider.DistanceTravelled;  // Updating current position of Horseman
            if (position[rider.Name] < distance)
                WriteLine($"Horseman {rider.Name} has travelled {position[rider.Name]} metres so far");
            else
            {
                WriteLine($"Horseman {rider.Name} has finished the race");
            }

        }


    }
}

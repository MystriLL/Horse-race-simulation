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
        public MoveEventArgs(int meters) => move = meters;
    }

    class Race
    {
        private EventHandler run = null;
        private Dictionary<string,int> position = new Dictionary<string, int>();
        public Track track;
        public int participantsNumber;
        public int eventsReceived;
        public Mutex mutex = new Mutex();
        public Race(Track track, int participantsNumber) { 
            this.track = track;
            this.participantsNumber = participantsNumber;
        }

        public int SimulationTime
        {
            get => eventsReceived / participantsNumber;
        }

        public event EventHandler Run
        {
            add
            {
                run += value;
                var rider = value.Target as Horseman;
                position[rider.Name] = 0;
                rider.Move += this.RiderMoved;
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
            track.CreateGrid();
            track.PrintTrack();
            Task.WaitAll(riders);
        }


        public void RiderMoved(object sender, EventArgs args)
        {
            eventsReceived++;
            var rider = sender as Horseman;
            position[rider.Name] = rider.Distance;  // Updating current position of Horseman
            if (position[rider.Name] < track.Length)
            {
                if (mutex.WaitOne())
                {
                    try
                    {
                        WriteLine($"Horseman {rider.Name} has travelled {position[rider.Name]} metres so far");
                        track.RefreshScreen(rider);
                    }
                    finally 
                    {
                        mutex.ReleaseMutex();
                    } 
                }
                
            }      
            else
            {
                WriteLine($"Horseman {rider.Name} has finished the race");
            }
            if (eventsReceived%participantsNumber == 0)
            {
                //problem jest z obliczeniem czasu i jednoczesnym sprawdzaniem ilości koni które przesłały event żeby wywołać odświeżenie planszy
                // Bo jak któryś koń skończy jazdę to się obliczenia czasu sypną potencjalnie
            }
        }


    }
}

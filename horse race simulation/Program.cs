using System;
using static System.Console;
using System.Threading;
using System.Collections.Generic;
namespace horse_race_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to horse race simulator! \n\n");
            Thread.Sleep(1500);
            WriteLine("Specify number participants between 2 and 5: ");
            int participantsNumber = Convert.ToInt32(ReadLine());
            
            List<Horseman> Participants = CreateParticipants(participantsNumber);
            foreach(var p in Participants)
            {
                Thread.Sleep(500);
                WriteLine($"Hi! My name is {p.Name}, My skill level is {p.Skill}. My horse has {p.Horse.Speed} speed and {p.Horse.Stamina} stamina");
            }
        }

        public static List<Horseman> CreateParticipants(int n)
        {
            Random rnd = new Random();
            List<Horseman> participants = new List<Horseman>();
            List<Horse> horses = new List<Horse>();

            for (int i = 0; i<n; i++)
            { 
                horses.Add(new Horse(i, rnd.Next(1,11), rnd.Next(1,11)));
                participants.Add(new Horseman("Rider " + (i+1), rnd.Next(1, 11), horses[i]));
            }
            return participants;
        }
    }
}

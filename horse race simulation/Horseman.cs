using System;
using System.Collections.Generic;
using System.Text;

namespace horse_race_simulation
{

    class Horseman
    {
        public readonly string Name;
        public readonly int Skill; // additional factor that affects horse's performance in the race
        public readonly Horse Horse;

        public Horseman(string name, int skill, Horse horse)
        {
            Name = name;
            Skill = skill;
            Horse = horse;
        }
    }


    class Horse
    {
        public readonly int Id;
        public readonly string Name;
        public readonly int Stamina; //defines energy loss rate
        public int Speed; 
        public int Energy = 100; // when falls to 0, speed is decreased by 50% for a while


        public Horse(int id, int stamina, int speed)
        {
            Id = id;
            Stamina = stamina;
            Speed = speed;
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace horse_race_simulation
{
    class Horse
    {
        public readonly int Id;
        public readonly string Name;
        public readonly int Stamina; //defines energy loss rate
        public int Speed; 
        public int Energy = 100; // when falls to 0, speed is decreased by 50% for a while


        public Horse(int id, string name, int stamina, int speed)
        {
            Id = id;
            Name = name;
            Stamina = stamina;
            Speed = speed;
        }
    }
   
}

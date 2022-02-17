using System;
using System.Collections.Generic;
using System.Text;

namespace horse_race_simulation
{
    class Track
    {
        private string[,] TrackGrid;
        private int _length;
        private int Width;

        public int Length { get => _length; }

        public Track(int length, int participantsNumber)
        {
            _length = length;
            Width = participantsNumber;
            TrackGrid = new string[length+1, 2*Width+1];
        }

        public void CreateGrid()
        {
            for(int i =0; i < 2*Width+1; i++)
            {
                for(int j=0; j<Length; j++)
                {
                    TrackGrid[j,i] = i % 2 == 0 ? "=" : " ";
                }
            }
        }

        public void RefreshScreen(Horseman horseman)
        {
            for(int i =0; i<Length; i++) TrackGrid[i, horseman.Horse.Id * 2 + 1] = " ";
            TrackGrid[horseman.Distance, horseman.Horse.Id * 2 + 1] = "x";
            Console.Clear();
            PrintTrack();
        }

        public void PrintTrack()
        {
            for (int i = 0; i < 2*Width+1; i++)
            {
                if (i % 2 != 0) Console.Write($"{Math.Ceiling((double)i / 2)}:  ");
                else Console.Write("    ");
               
                for (int j = 0; j < Length; j++)
                {
                    Console.Write(TrackGrid[j,i]);
                }
                Console.WriteLine();
            }
        }
    }
}

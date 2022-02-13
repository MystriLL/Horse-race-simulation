using System;
using System.Collections.Generic;
using System.Text;

namespace horse_race_simulation
{
    class Track
    {
        private string[] TrackGrid;
        private int _length;
        private int Width;

        public int Length { get => _length; }

        public Track(int length, int participantsNumber)
        {
            _length = length;
            Width = participantsNumber;
        }
    }
}

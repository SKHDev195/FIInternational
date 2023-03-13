using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Track
    {

        public string Name { get; private set; }

        public string TrackCountry { get; private set; }

        public Track(string trackName, string country)
        {
            Name = trackName;
            TrackCountry = country;
        }

    }
}

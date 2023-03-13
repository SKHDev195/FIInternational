using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Weather
    {
        public bool IsRaining { get; private set; }

        public bool IsHot { get; private set; }

        public bool IsWindy { get; private set; }

        public Weather(bool isRaining, bool isHot, bool isWindy) 
        {

            IsRaining = isRaining;

            IsHot = isHot;

            IsWindy = isWindy;

        }

    }
}

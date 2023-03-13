using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Race
    {
        public Track RaceTrack { get; private set; }

        public Weather RaceWeather { get; private set; }

        public int ChanceOfJoker { get; private set; }

        /// <summary>
        /// Calculates the chance of something really unexpected occuring at a given race.
        /// </summary>
        public void CalculateWeightedJoker()
        {
            int chance = GameController.random.Next(100);

            switch (chance)
            {
                case int cs when cs <= 70:
                    ChanceOfJoker = 0;
                    break;

                case int cs when (cs > 70 && cs <= 90):
                    ChanceOfJoker = 1;
                    break;

                case int cs when (cs > 90 && cs <= 98):
                    ChanceOfJoker = 2;
                    break;

                default:
                    ChanceOfJoker = 3;
                    break;
            }
        }

        public Race(Track raceTrack, Weather raceWeather) 
        {
            RaceTrack = raceTrack;
            RaceWeather = raceWeather;
        }

    }
}

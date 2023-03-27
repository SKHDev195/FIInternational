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
                case int cs when cs <= 60:
                    ChanceOfJoker = 0;
                    break;

                case int cs when (cs > 60 && cs <= 80):
                    ChanceOfJoker = 1;
                    break;

                case int cs when (cs > 80 && cs <= 95):
                    ChanceOfJoker = 2;
                    break;

                default:
                    ChanceOfJoker = 3;
                    break;
            }
        }

        /// <summary>
        /// Generates a status report about the weather conditions in a race.
        /// </summary>
        /// <returns>A string with the race weather status report.</returns>
        public string GenerateWeatherStatus()
        {
            List<string> weatherStatus = new List<string>();

            string precipitation = (this.RaceWeather.IsRaining) ? "Rain is forecasted for this race!" : "This race promises to be dry!";

            string wind = (this.RaceWeather.IsWindy) ? "This race promises to be windy!" : "Calmn winds are forecasted for this race!";

            string temperature = (this.RaceWeather.IsHot) ? "High temperatures are forecasted for this race!" : "This race promises to have moderate temperatures!";

            weatherStatus.Add(precipitation);

            weatherStatus.Add(wind);

            weatherStatus.Add(temperature);

            return string.Join(' ', weatherStatus);
        }

        public Race(Track raceTrack, Weather raceWeather) 
        {
            RaceTrack = raceTrack;
            RaceWeather = raceWeather;
        }

    }
}

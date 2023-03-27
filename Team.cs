using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Team
    {

        public string Name { get; private set; }

        public List<Driver> RacingDrivers { get; set; }

        public float WinProbabilityTeam { get; private set; }

        public float SecondToTenthProbabilityTeam { get; private set; }

        public float DnfProbabilityTeam { get; private set; }

        public int CurrentPoints { get; set; } = 0;

        public int TotalPoints { get; set; } = 0;

        /// <summary>
        /// Calculates the slightly randomized payout odds for one driver of a team finishing in a certain position in a given race.
        /// </summary>
        /// <param name="race">The race to calculate the payout rates for.</param>
        /// <param name="position">The position to calculate the payout rates for.</param>
        /// <returns>A <c>float</c> representing the number by which the bid amount has to be multiplied in case of a win.</returns>
        public float CalculatePayoutOddsTeam(Race race, int position)
        {
            List<float> payoutJokers = Driver.CalculateMiniJoker(3);

            if (position == 1) return (1.0f / this.WinProbabilityTeam + payoutJokers[0]);

            else if (position > 1 && position <= 10) return (1.0f / this.SecondToTenthProbabilityTeam + payoutJokers[1]);

            else if (position > 10 && position <= 20) return (1.0f / (1 - (this.DnfProbabilityTeam + Math.Clamp(payoutJokers[2], 0.01f, 0.02f))));

            else return (1.0f / this.DnfProbabilityTeam + Math.Clamp(payoutJokers[2], 0.01f, 0.02f));
        }

        public Team(string name, Driver driverOne, Driver driverTwo)
        {
            Name = name;

            RacingDrivers = new List<Driver>();
            
            RacingDrivers.Add(driverOne);

            driverOne.RacingTeam = this;

            RacingDrivers.Add(driverTwo);

            driverTwo.RacingTeam = this;

            WinProbabilityTeam = 1 - ((1 - RacingDrivers[0].WinProbability) * (1 - RacingDrivers[1].WinProbability));

            SecondToTenthProbabilityTeam = 1 - ((1 - RacingDrivers[0].SecondToTenthProbability) * (1 - RacingDrivers[1].WinProbability));

            DnfProbabilityTeam = 1 - ((1 - RacingDrivers[0].DnfProbability) * (1 - RacingDrivers[1].DnfProbability));
        }


    }
}

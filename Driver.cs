using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class Driver
    {

        public string Name { get; private set; }

        public Team RacingTeam { get; set; }

        internal float WinProbability { get; set; }

        internal float SecondToTenthProbability { get; set; }

        internal float DnfProbability { get; set; }

        internal float RainModifier { get; set; }

        internal float DryModifier { get; set; }

        internal float CalmModifier { get;  set; }

        internal float WindModifier { get; set; }

        internal float HeatModifier { get; set; }

        internal float ColdModifier { get; set; }

        internal DriverOutcome ResultInCurrentRace { get; set; }

        internal int CurrentPoints { get; set; } = 0;

        internal int TotalPoints { get; set; } = 0;

        /// <summary>
        /// Calculates the possible finishing place of the driver in a given race.
        /// </summary>
        /// <param name="race">The race in which the driver is participating.</param>
        /// <returns>The <c>DriverOutcome</c> representing the driver's finishing place.</returns>
        public DriverOutcome CalculatePossiblePlace(Race race)
        {

            float chanceToDnf = CalculateMiniJokerDnf();

            if ((float)GameController.random.NextDouble() <= chanceToDnf) return DriverOutcome.DNF;

            else
            {
                List<float> miniJokerModifiers = CalculateMiniJoker(6);

                float weatherModifierPrecipitation = (race.RaceWeather.IsRaining) ? RainModifier + miniJokerModifiers[0] : DryModifier + miniJokerModifiers[0];

                float weatherModifierTemperature = (race.RaceWeather.IsHot) ? HeatModifier + miniJokerModifiers[1] : ColdModifier + miniJokerModifiers[1];

                float weatherModifierWind = (race.RaceWeather.IsWindy) ? WindModifier + miniJokerModifiers[2] : CalmModifier + miniJokerModifiers[2];

                float finalWinProbability = WinProbability + miniJokerModifiers[3];

                float finalSecondToTenthProbability = WinProbability + miniJokerModifiers[4];

                float finalScore = (8.0f * finalWinProbability) + (9.0f * finalSecondToTenthProbability) + (5.0f * weatherModifierPrecipitation) + (0.5f * weatherModifierTemperature) + (0.5f * weatherModifierWind);

                int possiblePlace = 20 - (int)finalScore;

                return (DriverOutcome)possiblePlace;
            }

        }

        /// <summary>
        /// Calculates the possible finishing place of the driver in a given race but all modifiers are random floats. Necessary to account for 'crazy' races.
        /// </summary>
        /// <returns>The <c>DriverOutcome</c> representing the driver's finishing place.</returns>
        public DriverOutcome ApplyJoker()
        {

            float chanceToDnf = CalculateMiniJokerDnf();

            if ((float)GameController.random.NextDouble() <= chanceToDnf) return DriverOutcome.DNF;

            else
            {
                float finalScore = (8.0f * (float)GameController.random.NextDouble()) + (9.0f * (float)GameController.random.NextDouble()) + (5f * (float)GameController.random.NextDouble()) + (0.5f * (float)GameController.random.NextDouble()) + (0.5f * (float)GameController.random.NextDouble());

                int possiblePlace = 20 - (int)finalScore;



                return (DriverOutcome)possiblePlace;
            }

        }

        /// <summary>
        /// Calculates some small probability that a driver is going to be a bit 'off' or 'on point' during a race.
        /// </summary>
        /// <returns></returns>
        public List<float> CalculateMiniJoker(int length)
        {
            List<float> miniJokerModifiers = new List<float>();

            while (miniJokerModifiers.Count < length)
            {
                float modifierToAdd = (GameController.random.Next(2) == 0) ? 0.1f : -0.1f;
                
                miniJokerModifiers.Add(modifierToAdd);
            }

            return miniJokerModifiers;
        }

        /// <summary>
        /// Calculates a driver's chances to retire in a given race.
        /// </summary>
        /// <returns>The driver's chance to retire.</returns>
        public float CalculateMiniJokerDnf()
        {
            int chance = GameController.random.Next(100);

            int direction = GameController.random.Next(2);

            int dnfFactor;

            switch (chance)
            {
                case int cs when cs <= 83:
                    dnfFactor = 1;
                    break;

                case int cs when (cs > 84 && cs <= 90):
                    dnfFactor = 2;
                    break;

                case int cs when (cs > 90 && cs <= 98):
                    dnfFactor = 3;
                    break;

                default:
                    dnfFactor = 4;
                    break;
            }

            float finalDnfProbability = (direction == 0) ? DnfProbability * dnfFactor : DnfProbability / dnfFactor;

            return finalDnfProbability; 
        }

        /// <summary>
        /// Calculates the slightly randomized payout odds for a driver finishing in a certain position in a given race.
        /// </summary>
        /// <param name="race">The race to calculate the payout rates for.</param>
        /// <param name="position">The position to calculate the payout rates for.</param>
        /// <returns>A <c>float</c> representing the number by which </returns>
        public float CalculatePayoutOdds(Race race, int position) 
        {
            List<float> payoutJokers = CalculateMiniJoker(3);

            if (position == 1) return (1.0f / this.WinProbability + payoutJokers[0]);

            else if (position > 1 && position <= 10) return (1.0f / this.SecondToTenthProbability + payoutJokers[1]);

            else if (position > 10 && position <= 20) return (1.0f / (1 - (this.DnfProbability + Math.Clamp(payoutJokers[2], 0.01f, 0.02f))));

            else return (1.0f / this.DnfProbability + Math.Clamp(payoutJokers[2], 0.01f, 0.02f));
        }

        public Driver(string name, float winProbability, float secondToTenthProbability, float dnfProbability, float rainModifier, float dryModifier, float windModifier, float calmModifier, float heatModifier, float coldModifier)
        {
            Name = name;

            WinProbability = winProbability;

            SecondToTenthProbability = secondToTenthProbability;

            DnfProbability = dnfProbability;

            RainModifier = rainModifier;

            DryModifier= dryModifier;

            WindModifier = windModifier;

            CalmModifier = calmModifier;

            HeatModifier = heatModifier;

            ColdModifier = coldModifier;
        }
    }
}

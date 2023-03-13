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

        /// <summary>
        /// Calculates the possible finishing place of the driver in a given race.
        /// </summary>
        /// <param name="race">The race in which the driver is participating.</param>
        /// <returns>The <c>DriverOutcome</c> representing the driver's finishing place.</returns>
        public DriverOutcome CalculatePossiblePlace(Race race)
        {

            List<float> miniJokerModifiers = CalculateMiniJoker();

            float weatherModifierPrecipitation = (race.RaceWeather.IsRaining) ? RainModifier + miniJokerModifiers[0] : DryModifier + miniJokerModifiers[0];

            float weatherModifierTemperature = (race.RaceWeather.IsHot) ? HeatModifier + miniJokerModifiers[1]  : ColdModifier + miniJokerModifiers[1];

            float weatherModifierWind = (race.RaceWeather.IsWindy) ? WindModifier + miniJokerModifiers[2]  : CalmModifier + miniJokerModifiers[2];

            float finalWinProbability = WinProbability + miniJokerModifiers[3];

            float finalSecondToTenthProbability = WinProbability + miniJokerModifiers[4];

            float finalDnfProbability = DnfProbability + miniJokerModifiers[5];

            float finalScore = (9.2f * WinProbability) + (8.0f * SecondToTenthProbability) + (-2.0f * DnfProbability) + (4.5f * weatherModifierPrecipitation) + (1.0f * weatherModifierTemperature) + (0.5f * weatherModifierWind);

            int possiblePlace = 20 - (int)finalScore;

            return (DriverOutcome)possiblePlace;

        }

        /// <summary>
        /// Calculates the possible finishing place of the driver in a given race but all modifiers are random floats. Necessary to account for 'crazy' races.
        /// </summary>
        /// <returns>The <c>DriverOutcome</c> representing the driver's finishing place.</returns>
        public DriverOutcome ApplyJoker()
        {
            float finalScore = (10.0f * (float)GameController.random.NextDouble()) + (8.0f * (float)GameController.random.NextDouble()) + (-2.0f * (float)GameController.random.NextDouble()) + (2.5f * (float)GameController.random.NextDouble()) + (1.0f * (float)GameController.random.NextDouble()) + (0.3f * (float)GameController.random.NextDouble());

            int possiblePlace = 20 - (int)finalScore;

            return (DriverOutcome)possiblePlace;
        }

        /// <summary>
        /// Calculates some small probability that a driver is going to be a bit 'off' or 'on point' during a race.
        /// </summary>
        /// <returns></returns>
        public List<float> CalculateMiniJoker()
        {
            List<float> miniJokerModifiers = new List<float>();

            while (miniJokerModifiers.Count < 7)
            {
                float modifierToAdd = (GameController.random.Next(2) == 0) ? 0.1f : -0.1f;
                
                miniJokerModifiers.Add(modifierToAdd);
            }

            return miniJokerModifiers;
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

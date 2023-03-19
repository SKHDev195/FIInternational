using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FIConsole
{
    public class GameController
    {

        public static Random random = new Random();

        public List<Track> TrackList = new List<Track>()
        {
            new Track("Albert Park Circuit", "Australia"),
            new Track("Autódromo Hermanos Rodríguez", "Mexico"),
            new Track("Autodromo José Carlos Pace", "Brazil"),
            new Track("Autodromo Nazionale di Monza", "Italy"),
            new Track("Bahrain International Circuit", "Bahrain"),
            new Track("Baku City Circuit", "Azerbaijan"),
            new Track("Circuit de Barcelona-Catalunya", "Spain"),
            new Track("Circuit de Monaco", "Monaco"),
            new Track("Circuit de Spa-Francorchamps", "Belgium"),
            new Track("Circuit Gilles-Villeneuve", "Canada"),
            new Track("Circuit of the Americas", "USA"),
            new Track("Circuit Zandvoort", "Netherlands"),
            new Track("Hungaroring", "Hungary"),
            new Track("Marina Bay Street Circuit", "Singapore"),
            new Track("Red Bull Ring", "Austria"),
            new Track("Silverstone Circuit ", "United Kingdom"),
            new Track("Suzuka International Racing Course", "Japan"),
            new Track("Yas Marina Circuit", "Abu Dhabi"),
            new Track("Autódromo do Estoril", "Portugal"),
            new Track("Kyalami Grand Prix Circuit", "South Africa"),

        };

        public List<Driver> DriverList = new List<Driver>()
        {
            new Driver("Maximum Dutch", 0.9f, 0.9f,  0.03f, 0.6f, 0.8f, 0.7f, 0.9f, 0.7f, 0.8f),
            new Driver("Antonio Bestteammate", 0.7f, 0.04f, 0.3f, 0.7f, 0.7f, 0.8f, 0.7f, 0.7f, 0.8f),
            new Driver("Monegasque Jemapelle", 0.8f, 0.9f, 0.05f, 0.7f, 0.7f, 0.4f, 0.8f, 0.6f, 0.8f),
            new Driver("Sancho Junior", 0.7f, 0.8f, 0.06f, 0.6f, 0.8f, 0.8f, 0.7f, 0.9f, 0.7f),
            new Driver("Sir Winalotton", 0.9f, 0.8f, 0.03f, 0.9f, 0.8f, 0.6f, 0.7f, 0.7f, 0.7f),
            new Driver("Philipp S. Crowe", 0.6f, 0.8f, 0.04f, 0.7f, 0.7f, 0.8f, 0.7f, 0.6f, 0.9f),
            new Driver("Jacque Instagrammue", 0.7f, 0.7f, 0.97f, 0.8f, 0.7f, 0.8f, 0.7f, 0.8f, 0.7f),
            new Driver("Andre Papiermache", 0.5f, 0.7f, 0.07f, 0.6f, 0.7f, 0.8f, 0.7f, 0.7f, 0.7f),
            new Driver("Jack Streamer", 0.68f, 0.7f, 0.05f, 0.7f, 0.7f, 0.8f, 0.8f, 0.7f, 0.9f),
            new Driver("Bafta Pastani", 0.6f, 0.6f, 0.07f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f),
            new Driver("Zhen Ryuki", 0.4f, 0.5f, 0.11f, 0.7f, 0.8f, 0.7f, 0.9f, 0.6f, 0.7f),
            new Driver("Tartu Makkinen", 0.6f, 0.7f, 0.08f, 0.5f, 0.7f, 0.7f, 0.7f, 0.6f, 0.9f),
            new Driver("Estebano Spygato", 0.9f, 0.6f, 0.05f, 0.8f, 0.7f, 0.7f, 0.7f, 0.9f, 0.8f),
            new Driver("James Walker", 0.3f, 0.5f, 0.07f, 0.4f, 0.7f, 0.6f, 0.7f, 0.7f, 0.7f),
            new Driver("Dane Bigussen", 0.4f, 0.4f, 0.08f, 0.6f, 0.6f,  0.7f, 0.7f, 0.5f, 0.8f),
            new Driver("Rico Greenberg", 0.4f, 0.5f, 0.06f, 0.7f, 0.6f, 0.7f, 0.6f, 0.6f, 0.6f),
            new Driver("Rin Takeuchi", 0.3f, 0.3f, 0.08f, 0.6f, 0.6f, 0.6f, 0.7f, 0.5f, 0.5f),
            new Driver("Jack du Pint", 0.3f, 0.3f, 0.08f, 0.6f, 0.6f, 0.7f, 0.6f, 0.6f, 0.5f),
            new Driver("Jackson Captainwell", 0.15f, 0.06f, 0.6f, 0.5f, 0.5f, 0.6f, 0.5f, 0.5f, 0.6f),
            new Driver("Damon Goataon", 0.15f, 0.3f, 0.07f, 0.6f, 0.6f, 0.7f, 0.6f, 0.7f, 0.5f)

        };

        public Dictionary<DriverOutcome, int> Points = new Dictionary<DriverOutcome, int>() {

            { DriverOutcome.First, 25 },
            { DriverOutcome.Second, 18 },
            { DriverOutcome.Third, 15 },
            { DriverOutcome.Fourth, 12 },
            { DriverOutcome.Fifth, 10 },
            { DriverOutcome.Sixth, 8 },
            { DriverOutcome.Seventh, 6 },
            { DriverOutcome.Eighth, 4 },
            { DriverOutcome.Ninth, 2 },
            { DriverOutcome.Tenth, 1 },
 
        };

        public List<Driver> SortedDriversList { get; private set; }

        public List<Team> TeamsList { get; private set; }

        public List<Race> RaceList { get; private set; }

        /// <summary>
        /// Generates a list of teams with pre-defined drivers.
        /// </summary>
        public void GenerateTeams()
        {
            TeamsList = new List<Team>()
            {
                new Team("Crimson Taurus", DriverList[0], DriverList[1]),
                new Team("Prancing Sause", DriverList[2], DriverList[3]),
                new Team("Silber Pumpernickel", DriverList[4], DriverList[5]),
                new Team("Renette", DriverList[6], DriverList[7]),
                new Team("Stiff Upperlip", DriverList[8], DriverList[9]),
                new Team("Beta Juliet", DriverList[10], DriverList[11]),
                new Team("Gaston Green", DriverList[12], DriverList[13]),
                new Team("Freedom Fries", DriverList[14], DriverList[15]),
                new Team("Smaller Taurus", DriverList[16], DriverList[17]),
                new Team("Frillians", DriverList[18], DriverList[19])
            };
        }

        /// <summary>
        /// Generates a list of races for pre-defined tracks; weather is random.
        /// </summary>
        public void GenerateRaces()
        {

            RandomizeTrackList();

            RaceList = new List<Race>();

            foreach (Track track in TrackList)
            {
                bool rain = (random.Next(1) == 0) ? false : true;

                bool heat = (random.Next(1) == 0) ? false : true;

                bool wind = (random.Next(1) == 0) ? false : true;

                Weather raceWeather = new Weather(rain, heat, wind);

                Race currentRace = new Race(track, raceWeather);

                currentRace.CalculateWeightedJoker();

                RaceList.Add(currentRace);
            }

        }

        /// <summary>
        /// Randomizes the list of tracks so that each new season feels fresh.
        /// </summary>
        public void RandomizeTrackList()
        {

            int numberOfTracks = TrackList.Count;

            while (numberOfTracks > 1)
            {
                numberOfTracks--;

                int numberOfTrackToReplace = random.Next(numberOfTracks + 1);

                Track currentTrack = TrackList[numberOfTrackToReplace];

                TrackList[numberOfTrackToReplace] = TrackList[numberOfTracks];

                TrackList[numberOfTracks] = currentTrack;

            }

        }

        /// <summary>
        /// Identifies the indexes of the drivers to which a joker is applied.
        /// </summary>
        /// <param name="race">The race for which joker drivers are identified.</param>
        public List<int> IdentifyJokerDrivers(Race race)
        {
            int numberOfJokerDrivers = 2;

            switch (race.ChanceOfJoker)
            {
                case 0:
                    numberOfJokerDrivers = 3;
                    break;

                case 1:
                    numberOfJokerDrivers = 4;
                    break;

                case 2:
                    numberOfJokerDrivers = 5;
                    break;

                case 3:
                    numberOfJokerDrivers = 6;
                    break;
            }

            List<int> driverIndices = new List<int>();

            while (driverIndices.Count <= numberOfJokerDrivers)
            {
                driverIndices.Add(random.Next(20 - driverIndices.Count));
            }

            return driverIndices;
        }

        /// <summary>
        /// Runs a race by assigning each participating driver a finishing place.
        /// </summary>
        /// <param name="race">The race to run.</param>
        public void RunRace(Race race)
        {
            List<int> jokerDriverIndices = IdentifyJokerDrivers(race);

            for (int i = 0; i < 20; i++)
            {
                if (jokerDriverIndices.Contains(i)) DriverList[i].ResultInCurrentRace = DriverList[i].ApplyJoker();

                else DriverList[i].ResultInCurrentRace = DriverList[i].CalculatePossiblePlace(race);

            }

            DriverComparerByPlace comparer = new DriverComparerByPlace();

            DriverList.Sort(comparer);

            PrettifyFinishingPlaces();

            AllocatePoints();

        }

        public void RunChampionship()
        {
            GenerateRaces();

            GenerateTeams();

            for (int i = 0; i < 20; i++)
            {
                if (i == 0) Console.WriteLine("This is the start of a new Formula International championship!");

                Console.WriteLine($"The current race is the {RaceList[i].RaceTrack.TrackCountry} GP! It is held at {RaceList[i].RaceTrack.Name}.");

                Console.WriteLine("Do you want to run this race? Type Y or y.");

                char input = Console.ReadKey().KeyChar;

                while (input != 'Y' && input != 'y') 
                {
                    Console.WriteLine($"{Environment.NewLine}You have chosen not to run the race or have entered an invalid value. Please type Y when you are ready to race!");
                    input = Console.ReadKey().KeyChar;
                }

                if (input == 'Y' || input == 'y')
                {
                    
                    Console.WriteLine(Environment.NewLine);

                    RunRace(RaceList[i]);

                    Console.WriteLine(GenerateStatus());

                    Console.WriteLine(Environment.NewLine);
                }

            }
        }

        /// <summary>
        /// Makes it so that each driver has a unique finishing place in a given race.
        /// </summary>
        public void PrettifyFinishingPlaces()
        {

            for (int i = 0; i < 20; i++)
            {
                if (DriverList[i].ResultInCurrentRace != DriverOutcome.DNF && DriverList[i].ResultInCurrentRace != DriverOutcome.Twentienth)
                {
                    DriverList[i].ResultInCurrentRace = (DriverOutcome)i;
                }

            }
        }

        /// <summary>
        /// Allocates points after each given race.
        /// </summary>
        public void AllocatePoints()
        {
            foreach (Driver driver in DriverList)
            {
                if (Points.ContainsKey(driver.ResultInCurrentRace)) driver.CurrentPoints += Points[driver.ResultInCurrentRace];
            }

            foreach (Team team in TeamsList)
            {
                team.CurrentPoints = team.RacingDrivers[0].CurrentPoints + team.RacingDrivers[1].CurrentPoints;
            }
        }

        /// <summary>
        /// Generates a string outlining the basic results of the current race.
        /// </summary>
        /// <returns></returns>
        public string GenerateStatus()
        {
            List<string> finishReports = new List<string>();

            foreach (Driver driver in DriverList)
            {
                if (driver.ResultInCurrentRace == DriverOutcome.DNF) finishReports.Add($"{driver.Name} did not finish!");

                else finishReports.Add($"{driver.Name} finished {driver.ResultInCurrentRace}!");
            }

            return string.Join(Environment.NewLine, finishReports);
        }

        public string GenerateChampionshipStatus()
        {
            throw new NotImplementedException();
        }

    }
}

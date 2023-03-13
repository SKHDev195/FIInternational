using FIConsole;

class Program
{
    public static void Main(string[] args)
    {
        GameController gameController = new GameController();

        gameController.GenerateTeams();

        gameController.GenerateRaces();

        Console.WriteLine($"The current race is {gameController.RaceList[0].RaceTrack.Name}");

        gameController.RunRace(gameController.RaceList[0]);

        Console.WriteLine(gameController.GenerateStatus());

    }
}
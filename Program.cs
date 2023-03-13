using FIConsole;

class Program
{
    public static void Main(string[] args)
    {
        GameController gameController = new GameController();

        gameController.GenerateTeams();

        gameController.GenerateRaces();

        gameController.RunRace(gameController.RaceList[0]);

        Console.WriteLine(gameController.GenerateStatus());

    }
}